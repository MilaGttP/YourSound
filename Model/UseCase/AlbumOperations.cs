
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace YourSound
{
    public static class AlbumOperations
    {
        public static async Task<List<Album>> GetAlbumsByGenre(string genre)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var albums = await dbContext.Album
                        .Where(al => al.Genre == genre)
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
    }
}
