
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace YourSound
{
    public static class SingerOperations
    {
        public static async Task<List<Album>> GetSingerAlbums(string singerName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<Singer> GetSingerByName(string name)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singer = await dbContext.Singer
                        .Where(s => s.Name.ToLower() == name.ToLower())
                        .FirstOrDefaultAsync();

                    return singer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<SongAndSinger> GetSongSinger(Song song)
        {
            try
            {
                SongAndSinger songAndSinger = new SongAndSinger();
                using (var dbContext = new DBContext())
                {
                    Singer singer = await dbContext.Singer.FirstOrDefaultAsync(s => s.ID == song.SingerID);
                    songAndSinger.Song = song;
                    songAndSinger.Singer = singer;
                    return songAndSinger;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
        public static async Task<List<SongAndSinger>> GetSongAuthorPairs(List<Song> songs)
        {
            try
            {
                List<SongAndSinger> pairs = new List<SongAndSinger>();
                using (var dbContext = new DBContext())
                {
                    pairs = await dbContext.Song
                        .Join(dbContext.Singer,
                            song => song.SingerID,
                            singer => singer.ID,
                            (song, singer) => new SongAndSinger { Song = song, Singer = singer })
                        .Where(pair => songs.Contains(pair.Song))
                        .ToListAsync();
                }
                return pairs;
            }
            catch (Exception ex)
            {
                Console.Write($"Помилка: {ex.Message}");
                return null;
            }
        }
    }
}
