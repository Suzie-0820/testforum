using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using testholger;

namespace testholger.Pages
{
    public class PostPageModel : PageModel
    {
        private readonly testholger.ForumContext _context;
        public Topics MainPost { get; set; }
        public List<Posts> Replies = new List<Posts>();
        public string Username { get; set; }


        [BindProperty(SupportsGet = true)] //Hämtar postID från url fältet, för att sedan kunna hämta rätt info beroende på vilken topic man vill läsa
        public int PostId { get; set; }


        public PostPageModel(testholger.ForumContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Username = HttpContext.Session.GetString("_User"); //Hämtar användarnamnet för den inloggade user, och tilldelar värdet tills en lokala variabel

            if (Username == null) //Är man inte inloggad, kan man inte se Forumet öht även om man skulle tex försöka komma åt direkt från url fältet. Sätter först så att info från databasen hämtas aldrig om inte inloggad
            {
                return RedirectToPage("./Error");
            }

            var allreplies = _context.Posts.ToList(); //Hämtar alla Posts från databasen
            MainPost =_context.Topics.Find(PostId); //Hittar den Topic som matchar den ID från url:et

           foreach(Posts post in allreplies) //Loopar igenom Posts listan och sätter de som tillhör den valt Topic i den Replies lista, om de inte blev raderade. 
            {
                if (post.Topic == MainPost && post.DeletedAt == null)
                {
                    Replies.Add(post); 
                }
            } 

            return Page();
        }

        [BindProperty]
        public Posts Posts { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /// <summary>
        /// Skapar en ny Post objekt i databasen baserat på User input
        /// </summary>
        /// <returns>Task</returns>
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Hämtar och tilldelar övriga info för den nya Posts objekt innan den sparas i databasen.
            var Username = HttpContext.Session.GetString("_User");
            Posts.user = _context.Users.SingleOrDefault(users => users.Username == Username); //Hämtar användaren från User databas som matchar användarnament
            Posts.Author = Username;
            Posts.CreatedAt = DateTime.Now;
        

            MainPost = _context.Topics.Find(PostId);
            MainPost.NumberComments++; //+1 antal kommentarer 
            Posts.Topic = MainPost;

            _context.Posts.Add(Posts); //Skapar och sparar nya Post objekt
            _context.Topics.Update(MainPost); //Updaterar Topic objekt med den nya NumberComments

            await _context.SaveChangesAsync();
            return RedirectToPage("./ForumStartPage");


        }
        /// <summary>
        /// "Raderar" en Post för användararna, genom att sätta en DeletedAt datum i databasen.
        /// </summary>
        /// <param name="CommentId">Id av Post som ska "raderas"</param>
        /// <returns>Task</returns>
        public async Task<IActionResult> OnPostDeleteAsync(int CommentId)
        {
            var postToDelete = _context.Posts.Find(CommentId); //Hittar den Post med den ID, raderar den
            postToDelete.DeletedAt = DateTime.Now;
            _context.Posts.Update(postToDelete);

            MainPost = _context.Topics.Find(PostId); //Hittar den Topic den raderade Post var länkt till, antal kommentarer minskar med 1
            MainPost.NumberComments--;
            _context.Topics.Update(MainPost);


            await _context.SaveChangesAsync(); 

            return RedirectToPage("./ForumStartPage");
        }
        /// <summary>
        /// Updaterar antal Likes en Post har i databasen
        /// </summary>
        /// <param name="CommentId">Post id som fick en Like</param>
        /// <returns>Task</returns>
        public async Task<IActionResult> OnPostLikeAsync(int CommentId)
        {
            var postToLike = _context.Posts.Find(CommentId); //Hittar Post i databasen, ++ Like och uppdaterar den. 
            postToLike.PostLikes++;
            _context.Posts.Update(postToLike);
            await _context.SaveChangesAsync(); 

            return RedirectToPage("./ForumStartPage");
        }

    }
}
