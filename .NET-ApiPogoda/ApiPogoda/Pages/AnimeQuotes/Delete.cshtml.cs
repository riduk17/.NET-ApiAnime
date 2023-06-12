using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApiPogoda;

namespace ApiPogoda.Pages.AnimeQuotes
{
    public class DeleteModel : PageModel
    {
        private readonly ApiPogoda.AnimeDB _context;

        public DeleteModel(ApiPogoda.AnimeDB context)
        {
            _context = context;
        }

        [BindProperty]
      public AnimeQuote AnimeQuote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var animequote = await _context.Quotes.FirstOrDefaultAsync(m => m.Id == id);

            if (animequote == null)
            {
                return NotFound();
            }
            else 
            {
                AnimeQuote = animequote;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }
            var animequote = await _context.Quotes.FindAsync(id);

            if (animequote != null)
            {
                AnimeQuote = animequote;
                _context.Quotes.Remove(AnimeQuote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
