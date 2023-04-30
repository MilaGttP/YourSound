
namespace YourSound
{
    public class Song
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Genre { get; set; }
        public string Mood { get; set; }
        public bool IsStrum { get; set; }
        public string StrumOrParts { get; set; }
        public string Url { get; set; }
        public byte[] Image { get; set; }

        public Song()
        {
            ID = 0;
            Name = string.Empty;
            Text = string.Empty;
            Genre = string.Empty;
            Mood = string.Empty;
            IsStrum = false;
            StrumOrParts = string.Empty;
            Url = string.Empty;
            Image = new byte[0];
        }
    }
}
