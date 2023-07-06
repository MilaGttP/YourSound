using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace YourSound
{
    public static class ChordOperations
    {
        public static async Task<List<Chord>> GetAllChords()
        {
            try
            {
                using (DBContext dbContext = new DBContext())
                {
                    return await dbContext.Chord.ToListAsync();
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
