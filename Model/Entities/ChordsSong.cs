using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class ChordsSong
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int ChordID { get; set; }

        public ChordsSong()
        {
            ID = 0;
            SongID = 0;
            ChordID = 0;
        }
    }
}
