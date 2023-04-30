using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public static class SongOperations
    {
        public static async Task<List<Chord>> GetAllChordsForSongAsync(string songName)
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
    }
}
