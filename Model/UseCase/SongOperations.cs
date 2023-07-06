
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace YourSound
{
    public static class SongOperations
    {
        public static async Task<List<Chord>> GetAllChordsForSong(string songName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<Album> GetSongAlbum(string songName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<List<Song>> GetSongsByMoodOrGenre(string moodOrGenre)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var songs = await dbContext.Song
                        .Where(s => s.Mood == moodOrGenre || s.Genre == moodOrGenre)
                        .ToListAsync();

                    return songs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<Song> GetSongByName(string name)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var song = await dbContext.Song
                        .Where(s => s.Name.ToLower() == name.ToLower())
                        .FirstOrDefaultAsync();

                    return song;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }

        public static async Task<List<Song>> GetTopSongs(int quantity)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var topSongs = await dbContext.Song
                        .OrderByDescending(s => s.Popularity)
                        .Take(quantity)
                        .ToListAsync();

                    return topSongs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<List<Song>> GetSongsByQuantity(int quantity, bool isFirst)
        {
            try
            {
                DBContext dBContext = new DBContext();
                List<Song> songs = new List<Song>(); 
                if (isFirst) songs = await dBContext.Song.OrderBy(s => s.ID).Take(quantity).ToListAsync();
                else songs = await dBContext.Song.OrderByDescending(s => s.ID).Take(quantity).ToListAsync();
                return songs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static void IncreasePopularity(int songId)
        {
            using (var dbContext = new DBContext())
            {
                var song = dbContext.Song.FirstOrDefault(s => s.ID == songId);
                if (song != null)
                {
                    song.Popularity++;
                    dbContext.SaveChanges();
                }
            }
        }
        public static bool CheckPopularSongsExist()
        {
            using (var dbContext = new DBContext())
            {
                int count = dbContext.Song.Count(s => s.Popularity > 0);
                return count >= 8;
            }
        }
        public static async Task<List<Song>> GetLastSongs(int quantity)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var lastSongs = await dbContext.Song
                        .OrderByDescending(s => s.ID)
                        .Take(quantity)
                        .ToListAsync();

                    return lastSongs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }

        public static async Task<List<SongAndSinger>> GetFirstSongs(int quantity)
        {
            try
            {
                List<SongAndSinger> songAndSingers = new List<SongAndSinger>();
                List<Song> songs = await GetSongsByQuantity(quantity, true);
                songAndSingers = await SingerOperations.GetSongAuthorPairs(songs);
                return songAndSingers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<List<SongAndSinger>> GetRandomSongs(int quantity)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    Random random = new Random();
                    List<int> randomSongIDs = Enumerable.Range(1, 89).OrderBy(x => random.Next()).Take(quantity).ToList();

                    List<Song> randomSongs = await dbContext.Song
                        .Where(song => randomSongIDs.Contains(song.ID))
                        .ToListAsync();

                    List<SongAndSinger> songAndSingers = await SingerOperations.GetSongAuthorPairs(randomSongs);

                    return songAndSingers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<List<SongAndSinger>> GetForTopSongsBorder(int quantity)
        {
            try
            {
                List<SongAndSinger> songAndSingers = new List<SongAndSinger>();
                List<Song> songs = new List<Song>();

                if (CheckPopularSongsExist() == true) songs = await GetTopSongs(quantity);
                else songs = await GetLastSongs(quantity);

                songAndSingers = await SingerOperations.GetSongAuthorPairs(songs);
                return songAndSingers;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }

        public static async Task<SongAndSinger> GetObjectsForSearching(string text)
        {
            try
            {
                SongAndSinger songAndSinger = new SongAndSinger();
                songAndSinger.Song = await GetSongByName(text);
                songAndSinger.Singer = await SingerOperations.GetSingerByName(text);

                return songAndSinger;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
    }
}
