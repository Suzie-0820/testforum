using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testholger.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ForumContext _context;
        public const string SessionKeyName = "_User";
        public string ErrorMessage { get; set; } = "";
        public string SuccessMessage { get; set; } = "";

        public IndexModel(ILogger<IndexModel> logger, ForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Users Users { get; set; }


        public IActionResult OnGet()
        {
            return Page();

        } 
        public IActionResult OnPostLogin() //Vid försök att logga in
        {
            var userToFind = _context.Users.SingleOrDefault(users => users.Username == Users.Username); //Försöker hitta användarnamnet i databasen

            if (userToFind != null) //Om användarnamnet hittats så...
            {
                if (userToFind.Password == Users.Password) //Om lösenordet matchar, tar användaren till forum startsida
                {
                    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
                    {
                        HttpContext.Session.SetString(SessionKeyName, Users.Username); //Genom att använda httpcontext skrivs inte ut känslig info i adressfältet men jag kan nå den information ifrån hela applikation
                    }

                    return RedirectToPage("./ForumStartPage");
                }

                else //Om inte, skriv ut felmeddelande på sidan
                {
                    ErrorMessage += "Fel lösenord";
                    return Page();
                }
            }

            ErrorMessage += "Okänt användarnamn"; //Om användarnamn hittades inte i databasen
            return Page();

        }

        public async Task<IActionResult> OnPostCreate() //Jag är medveten att det inte finns någon slags kod som kollar om användaren har fyllt i alla fält öht just nu.
        {
            try
            {
                _context.Users.Add(Users);
                await _context.SaveChangesAsync();

                SuccessMessage += "Kontot skapat. Vänligen logga in";
                return Page();
            }

            catch(Exception)
            {
                SuccessMessage += "Någonting gick fel, försök igen";
                return Page();
            }

        }
    }
}
