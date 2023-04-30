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
        public int AccountID { get; set; }

        public Saved() 
        { 
            ID = 0;
            SongID = 0;
            AccountID = 0;
        }
    }
}
