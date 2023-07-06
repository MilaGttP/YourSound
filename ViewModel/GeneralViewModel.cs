
using System.Collections.Generic;
using System.ComponentModel;

namespace YourSound
{
    public class GeneralViewModel : INotifyPropertyChanged
    {
        public GeneralViewModel() 
        {
            GetSongs();
        }

        private List<SongAndSinger> topSongs;
        public List<SongAndSinger> TopSongs
        {
            get { return topSongs; }
            set
            {
                topSongs = value;
                OnPropertyChanged(nameof(TopSongs));
            }
        }

        private List<SongAndSinger> youWillLikeSongs;
        public List<SongAndSinger> YouWillLikeSongs
        {
            get { return youWillLikeSongs; }
            set
            {
                youWillLikeSongs = value;
                OnPropertyChanged(nameof(YouWillLikeSongs));
            }
        }

        private List<SongAndSinger> playerSongs;
        public List<SongAndSinger> PlayerSongs
        {
            get { return playerSongs; }
            set
            {
                playerSongs = value;
                OnPropertyChanged(nameof(PlayerSongs));
            }
        }

        private SongAndSinger selectedSongAndAuthor;
        public SongAndSinger SelectedSongAndAuthor
        {
            get { return selectedSongAndAuthor; }
            set
            {
                selectedSongAndAuthor = value;
                OnPropertyChanged(nameof(SelectedSongAndAuthor));
            }
        }

        private async void GetSongs()
        {
            TopSongs = await SongOperations.GetForTopSongsBorder(10);
            YouWillLikeSongs = await SongOperations.GetRandomSongs(3);
            PlayerSongs = await SongOperations.GetRandomSongs(9);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
