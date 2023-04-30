
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSound
{
    public static class SongOperations
    {

        public static async Task<List<Chord>> GetAllChordsForSong(string songName)
        {
            using (DBContext dbContext = new DBContext())
            {
                var chords = await dbContext.ChordsSong
                    .Where(cs => cs.Song.Name == songName)
                    .Join(dbContext.Chord,
                        cs => cs.ChordID,
                        c => c.ID,
                        (cs, c) => c)
                    .ToListAsync();

                return chords;
            }
        }
        public static async Task<List<Singer>> GetAllSongSingers(string songName)
        {
            using (var dbContext = new DBContext())
            {
                var singers = await dbContext.SingerSong
                    .Include(ss => ss.Singer)
                    .Include(ss => ss.Song)
                    .Where(ss => ss.Song.Name == songName)
                    .Select(ss => ss.Singer)
                    .ToListAsync();

                return singers;
            }
        }
        public static async Task<Singer> GetSongSinger(Song song)
        {
            using (var dbContext = new DBContext())
            {
                var singerSong = await dbContext.SingerSong
                    .Include(ss => ss.Singer)
                    .FirstOrDefaultAsync(ss => ss.SongID == song.ID);

                return singerSong?.Singer;
            }
        }
        public static async Task<Album> GetSongAlbum(string songName)
        {
            using (var dbContext = new DBContext())
            {
                var album = await dbContext.SingerSong
                    .Where(ss => ss.Song.Name == songName)
                    .Select(ss => ss.Album)
                    .FirstOrDefaultAsync();

                return album;
            }
        }
        public static async Task<List<Song>> GetSongsByMoodOrGenre(string moodOrGenre)
        {
            using (var dbContext = new DBContext())
            {
                var songs = await dbContext.Song
                    .Where(s => s.Mood == moodOrGenre)
                    .ToListAsync();

                return songs;
            }
        }
        public static async Task<List<Song>> GetTopSongs(int quantity)
        {
            DBContext dBContext = new DBContext();
            List<int> topSongIds = new List<int>();

            List<int> savedSongIds = await dBContext.Saved.GroupBy(x => x.SongID)
                                                   .Select(g => new { SongId = g.Key, Count = g.Count() })
                                                   .OrderByDescending(x => x.Count)
                                                   .Take(quantity)
                                                   .Select(x => x.SongId)
                                                   .ToListAsync();

            List<int> recentSongIds = await dBContext.Recent.GroupBy(x => x.SongID)
                                                     .Select(g => new { SongId = g.Key, Count = g.Count() })
                                                     .OrderByDescending(x => x.Count)
                                                     .Take(quantity)
                                                     .Select(x => x.SongId)
                                                     .ToListAsync();

            topSongIds.AddRange(savedSongIds);
            topSongIds.AddRange(recentSongIds);

            List<Song> topSongs = await dBContext.Song.Where(s => topSongIds.Contains(s.ID)).ToListAsync();

            return topSongs;
        }
    }
}
