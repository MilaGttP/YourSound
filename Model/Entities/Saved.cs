using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class Saved
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int UserID { get; set; }

        public virtual Song Song { get; set; }
        public virtual Account Account { get; set; }

        public Saved() 
        { 
            ID = 0;
            SongID = 0;
            UserID = 0;
            Song = new Song();
            Account = new Account();
        }
    }
}
