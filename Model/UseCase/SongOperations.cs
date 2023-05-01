
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
        public static async Task<List<Singer>> GetAllSongSingers(string songName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<Singer> GetSongSinger(string songName)
        {
            try
            {
                Album songAlbum = await GetSongAlbum(songName);
                using (var dbContext = new DBContext())
                {
                    var singerSong = await dbContext.SingerSong
                        .Include(ss => ss.Singer)
                        .FirstOrDefaultAsync(ss => ss.AlbumID == songAlbum.ID);

                    return singerSong?.Singer;
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
                        .Where(s => s.Mood == moodOrGenre)
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
        public static async Task<List<Song>> GetSongsByQuantity(int quantity)
        {
            try
            {
                DBContext dBContext = new DBContext();
                var songs = await dBContext.Song.OrderByDescending(s => s.ID).Take(quantity).ToListAsync();
                return songs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
    }
}
