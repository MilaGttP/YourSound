
namespace YourSound
{
    public class ChordsSong
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int ChordID { get; set; }

        public virtual Song Song { get; set; }
        public virtual Chord Chord { get; set; }

        public ChordsSong()
        {
            ID = 0;
            SongID = 0;
            ChordID = 0;
            Song = new Song();
            Chord = new Chord();
        }
    }
}
