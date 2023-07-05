
namespace YourSound
{
    public class SingerSong
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int SingerID { get; set; }
        public int AlbumID { get; set; }

        public virtual Song Song { get; set; }
        public virtual Singer Singer { get; set; }
        public virtual Album Album { get; set; }

        public SingerSong()
        {
            ID = 0;
            SongID = 0;
            SingerID = 0;
            AlbumID = 0;
            Song = new Song();
            Singer = new Singer();
            Album = new Album();
        }
    }
}