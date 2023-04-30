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
        public int SongID { get; set; }

        public Recent()
        {
            ID = 0;
            AccountID = 0;
            SongID = 0;
        }
    }
}
