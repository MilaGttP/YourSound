using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSound
{
    public static class ChordOperations
    {
        public static async Task<List<Chord>> GetAllChords()
        {
            using (DBContext dbContext = new DBContext())
            {
                return await dbContext.Chord.ToListAsync();
            }
        }
    }
}
