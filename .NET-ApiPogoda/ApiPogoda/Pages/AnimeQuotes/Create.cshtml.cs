using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiPogoda;

namespace ApiPogoda.Pages.AnimeQuotes
{
    public class CreateModel : PageModel
    {
        private readonly ApiPogoda.AnimeDB _context;

        public CreateModel(ApiPogoda.AnimeDB context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AnimeQuote AnimeQuote { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Quotes == null || AnimeQuote == null)
            {
                return Page();
            }

            _context.Quotes.Add(AnimeQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
