using Microsoft.EntityFrameworkCore;

namespace ApiPogoda
{
        public class AnimeDB : DbContext
        {
            public virtual DbSet<AnimeQuote> Quotes { get; set; }
            public AnimeDB(DbContextOptions<AnimeDB> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlite(@"Data Source=Anime.db");
        }
}
