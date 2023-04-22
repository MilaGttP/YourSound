using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class Recent
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int SingerSongID { get; set; }

        public virtual Account Account { get; set; }
        public virtual SingerSong SingerSong { get; set; }

        public Recent()
        {
            ID = 0;
            AccountID = 0;
            SingerSongID = 0;
            Account = new Account();
            SingerSong = new SingerSong();
        }

    }
}
