
namespace YourSound
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Year { get; set; }

        public Album() 
        { 
            ID = 0;
            Name = string.Empty;
            Image = new byte[0];
            Year = 0;
        }
    }
}
