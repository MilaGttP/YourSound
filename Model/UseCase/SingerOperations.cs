
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
        public static async Task<List<Song>> GetSingerSongs(string singerName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
                return null;
            }
        }
    }
}
