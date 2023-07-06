
using System.Collections.Generic;
using System.ComponentModel;

namespace YourSound
{
    public class SingerViewModel : INotifyPropertyChanged
    {
        public SingerViewModel(Singer singer) 
        {
            Singer = singer;
            GetAll();
        }
        private Singer singer;
        public Singer Singer
        {
            get { return singer; }
            set
            {
                singer = value;
                OnPropertyChanged(nameof(Singer));
            }
        }

        private List<SongAndSinger> songsAndSingers;
        public List<SongAndSinger> SongsAndSingers
        {
            get { return songsAndSingers; }
            set
            {
                songsAndSingers = value;
                OnPropertyChanged(nameof(SongsAndSingers));
            }
        }

        public async void GetAll()
        {
            List<Song> songs = await SingerOperations.GetAllSingerSongs(Singer);
            SongsAndSingers = await SingerOperations.GetSongAuthorPairs(songs);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
