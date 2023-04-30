using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class SingerSong
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int SingerID { get; set; }
        public int AlbumID { get; set; }

        public SingerSong()
        {
            ID = 0;
            SongID = 0;
            SingerID = 0;
            AlbumID = 0;
        }
    }
}
