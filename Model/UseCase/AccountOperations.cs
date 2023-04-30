using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace YourSound
{
    public static class AccountOperations
    {
        public static List<Song> GetSavedSongs (Account account)
        {
            //if ( || ) do checking (if in account, if saved exist)
            // else return new Song[0];
            using (var dbContext = new DBContext())
            {
                var savedList = dbContext.Saved
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
                    .ToList();

                return savedList;
            }
        }
        public static List<Song> GetRecent(Account account)
        {
            //if ( || ) do checking (if in recent, if saved exist)
            // else return new Song[0];
            using (var dbContext = new DBContext())
            {
                var savedList = dbContext.Recent
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
                    .ToList();

                return savedList;
            }
        }
    }
}
