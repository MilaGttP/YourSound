
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSound
{
    public static class SingerOperations
    {
        public static async Task<List<Album>> GetSingerAlbums(string singerName)
        {
            using (var dbContext = new DBContext())
            {
                var albums = await dbContext.SingerSong
                    .Where(ss => ss.Singer.Name == singerName)
                    .Select(ss => ss.Album)
                    .ToListAsync();

                return albums;
            }
        }
        public static async Task<List<Song>> GetSingerSongs(string singerName)
        {
            using (var dbContext = new DBContext())
            {
                var songs = await dbContext.SingerSong
                    .Where(ss => ss.Singer.Name == singerName)
                    .Select(ss => ss.Song)
                    .ToListAsync();

                return songs;
            }
        }
    }
}
