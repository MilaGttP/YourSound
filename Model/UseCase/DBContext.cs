
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
            string connectionString = "Server=sql.bsite.net\\MSSQL2016;Database=milagttp_YourSound;User Id=milagttp_YourSound;Password=yoursound_p@ssw0rd;Trusted_Connection=True;Encrypt=False;Integrated Security=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
