using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSound
{
    public class Singer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public Singer() 
        { 
            ID = 0;
            Name = string.Empty;
            Description = string.Empty;
            Image = new byte[0];
        }

        public Singer(int id, string name, string description, byte[] image)
        {
            ID = id;
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
