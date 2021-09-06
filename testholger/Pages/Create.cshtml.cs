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
    public class CreateModel : PageModel
    {
        private readonly ForumContext _context;
        public string Username { get; set; }

        public CreateModel(ForumContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Username = HttpContext.Session.GetString("_User"); //Hämtar användarnamnet för den inloggade user, och tilldelar värdet tills en lokala variabel

            if (Username == null) //Är man inte inloggad, kan man inte se Forumet öht även om man skulle tex försöka komma åt direkt från url fältet. 
            {
                return RedirectToPage("./Error");
            }

            return Page();
        }

        [BindProperty]
        public Topics Topic { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Fyller på med de attributer som inte fyllts av användaren
            Topic.NumberComments = 0;
            Topic.CreatedAt = DateTime.Now;
            var Username = HttpContext.Session.GetString("_User"); //Hämtar namnet av användaren som är inloggat och skapar topic

            var postingUser = _context.Users.SingleOrDefault(users => users.Username == Username); //Hämtar användaren från User databas som matchar användarnament
            Topic.User = postingUser;
            Topic.Author = Username;

            _context.Topics.Add(Topic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ForumStartPage");
        }
    }
}
