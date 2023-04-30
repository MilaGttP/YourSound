using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YourSound
{
    public static class AccountOperations
    {
        public static async Task<List<Song>> GetSaved (Account account)
        {
            //if ( || ) do checking (if in account, if saved exist)
            // else return new Song[0];
            using (var dbContext = new DBContext())
            {
                var savedList = await dbContext.Saved
                    .Include(s => s.Song)
                    .Include(s => s.Account)
                    .Where(s => s.AccountID == account.ID)
                    .Select(s => new Song
                    {
                        ID = s.Song.ID,
                        Name = s.Song.Name,
                        Text = s.Song.Text,
                        Genre = s.Song.Genre,
                        Mood = s.Song.Mood,
                        IsStrum = s.Song.IsStrum,
                        StrumOrParts = s.Song.StrumOrParts,
                        Url = s.Song.Url,
                        Image = s.Song.Image
                    })
                    .ToListAsync();

                return savedList;
            }
        }

        public static async Task<List<Song>> GetRecent (Account account)
        {
            //if ( || ) do checking (if in account, if saved exist)
            // else return new Song[0];
            using (var dbContext = new DBContext())
            {
                var savedList = await dbContext.Recent
                    .Include(s => s.Song)
                    .Include(s => s.Account)
                    .Where(s => s.AccountID == account.ID)
                    .Select(s => new Song
                    {
                        ID = s.Song.ID,
                        Name = s.Song.Name,
                        Text = s.Song.Text,
                        Genre = s.Song.Genre,
                        Mood = s.Song.Mood,
                        IsStrum = s.Song.IsStrum,
                        StrumOrParts = s.Song.StrumOrParts,
                        Url = s.Song.Url,
                        Image = s.Song.Image
                    })
                    .ToListAsync();

                return savedList;
            }
        }
    }
}
