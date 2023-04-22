using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public Album() 
        { 
            ID = 0;
            Name = string.Empty;
            Image = new byte[0];
        }

        public Album(int id, string name, byte[] image)
        {
            ID = id;
            Name = name;
            Image = image;
        }
    }
}
