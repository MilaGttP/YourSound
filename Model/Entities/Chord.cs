
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
    }
}
