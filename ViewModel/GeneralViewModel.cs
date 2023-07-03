using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

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

        static private Song selectedSong;
        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                selectedSong = value;
                OnPropertyChanged(nameof(SelectedSong));
            }
        }

        private async void GetSongs()
        {
            TopSongs = await SongOperations.GetForTopSongsBorder(6);
            YouWillLikeSongs = await SongOperations.GetRandomSongs(2);
            PlayerSongs = await SongOperations.GetRandomSongs(5);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
