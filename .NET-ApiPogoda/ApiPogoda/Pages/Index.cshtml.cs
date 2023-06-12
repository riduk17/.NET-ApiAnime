using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace ApiPogoda.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AnimeDB _DB;

        public IndexModel(ILogger<IndexModel> logger, AnimeDB DB)
        {
            _logger = logger;
            _DB = DB;
        }

        public IActionResult OnGet()
        {
            if(!StringValues.IsNullOrEmpty(Request.Query["q"]))
            {
                var temp_quotes = _DB.Quotes.Where(Quote => Quote.Character.ToLower().Contains(Request.Query["q"].ToString().Trim().ToLower())).ToList();
                var r = new Random();
                if(temp_quotes.Count > 0)
                {
                    var temp_quote = temp_quotes[r.Next(temp_quotes.Count)];
                    return Redirect("AnimeQuotes/Details?id=" + temp_quote.Id);
                }
                //_logger.LogInformation(Request.Query["q"]);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostApi(string q)
        {
            //_logger.LogInformation("Dziala");
            string api = "https://animechan.vercel.app/api/quotes/character?name=" + q;
            //_logger.LogInformation(Request.Query["q"]);
            //_logger.LogInformation(call);
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(api);
            List<AnimeQuote> Kuotes = JsonConvert.DeserializeObject<List<AnimeQuote>>(response);
            //_logger.LogInformation(Kuote.Quote);
            _DB.Quotes.AddRange(Kuotes);
            _DB.SaveChanges();

            
            if (q != null)
            {
                var temp_quotes = _DB.Quotes.Where(Quote => Quote.Character.ToLower().Contains(q.Trim().ToLower())).ToList();
                var r = new Random();
                if (temp_quotes.Count > 0)
                {
                    var temp_quote = temp_quotes[r.Next(temp_quotes.Count)];
                    return Redirect("AnimeQuotes/Details?id=" + temp_quote.Id);
                }
                //_logger.LogInformation(Request.Query["q"]);
            }
            return Page();

        }
    }
}