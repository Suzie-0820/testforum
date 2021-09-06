using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using testholger;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace testholger.Pages
{
    public class ForumStartPageModel : PageModel
    {
        private readonly ForumContext _context;
        public List<Topics> ForumTopics = new List<Topics>();
        public string Username { get; set; }


        public ForumStartPageModel(ForumContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            Username = HttpContext.Session.GetString("_User"); //Hämtar användarnamnet för den inloggade user, och tilldelar värdet tills en lokala variabel

            if (Username == null) //Är man inte inloggad, kan man inte se Forumet öht även om man skulle tex försöka komma åt direkt från url fältet.
                                  //Sätter först så att info från databasen hämtas aldrig om inte inloggad för att spara resurser
            {
                return RedirectToPage("./Error");
            }

            ForumTopics = _context.Topics.ToList();
            return Page();
        }

        [BindProperty]
        public Topics Topics { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostCreate() //Omdirigerar användaren som vill skapa en ny Topic till den Create sidan
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Create");
        }

        public IActionResult OnPost() //Omdirigerar användaren som vill läsa en Topic till den PostPage sidan (med id i URL:et för att visa rätt information på sidan)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./PostPage");
        }
    }
}
