
using System.Collections.Generic;
using System.ComponentModel;

namespace YourSound 
{
    public class MoodOrGenreViewModel : INotifyPropertyChanged
    {
        public MoodOrGenreViewModel (string name)
        {
            Name = name;
            GetAll();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private List<SongAndSinger> songsSingers;
        public List<SongAndSinger> SongsSingers
        {
            get { return songsSingers; }
            set
            {
                songsSingers = value;
                OnPropertyChanged(nameof(SongsSingers));
            }
        }

        private async void GetAll()
        {
            List<Song> moodSongs = await SongOperations.GetSongsByMoodOrGenre(Name);
            SongsSingers = await SingerOperations.GetSongAuthorPairs(moodSongs);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
