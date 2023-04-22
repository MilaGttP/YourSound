using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class Chord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public Chord()
        {
            ID = 0;
            Name = string.Empty;
            Image = new byte[0];
        }

        public Chord(int id, string name, byte[] image)
        {
            ID = id;
            Name = name;
            Image = image;
        }
    }
}
