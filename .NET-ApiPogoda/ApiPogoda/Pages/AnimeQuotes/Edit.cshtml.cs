using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiPogoda;

namespace ApiPogoda.Pages.AnimeQuotes
{
    public class EditModel : PageModel
    {
        private readonly ApiPogoda.AnimeDB _context;

        public EditModel(ApiPogoda.AnimeDB context)
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

            var animequote =  await _context.Quotes.FirstOrDefaultAsync(m => m.Id == id);
            if (animequote == null)
            {
                return NotFound();
            }
            AnimeQuote = animequote;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AnimeQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeQuoteExists(AnimeQuote.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AnimeQuoteExists(int id)
        {
          return (_context.Quotes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
