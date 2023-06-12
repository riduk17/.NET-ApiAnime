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
    public class IndexModel : PageModel
    {
        private readonly ApiPogoda.AnimeDB _context;

        public IndexModel(ApiPogoda.AnimeDB context)
        {
            _context = context;
        }

        public IList<AnimeQuote> AnimeQuote { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Quotes != null)
            {
                AnimeQuote = await _context.Quotes.ToListAsync();
            }
        }
    }
}
