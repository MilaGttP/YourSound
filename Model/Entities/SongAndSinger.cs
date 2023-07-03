
namespace YourSound
{
    public class SongAndSinger
    {
        public Song Song { get; set; }
        public Singer Singer { get; set; }

        public SongAndSinger()
        {
            Song = new Song();
            Singer = new Singer();
        }
        public SongAndSinger(Song song, Singer singer)
        {
            Song = song;
            Singer = singer;
        }
    }
}
