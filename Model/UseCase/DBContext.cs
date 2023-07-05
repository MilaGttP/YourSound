
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace YourSound
{
    public class DBContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Chord> Chord { get; set; }
        public DbSet<Singer> Singer { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<SingerSong> SingerSong { get; set; }
        public DbSet<ChordsSong> ChordsSong { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
