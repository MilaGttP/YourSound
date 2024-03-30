
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
            string connectionString = "Data Source=sql.bsite.net\\MSSQL2016;User ID=milagttp_YourSound;Password=y0ur_s0und_s0ngs;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
