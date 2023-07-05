
using System.Collections.Generic;
using System.ComponentModel;

namespace YourSound
{
    public class SongAndSinger : INotifyPropertyChanged
    {
        public Song Song { get; set; }
        public Singer Singer { get; set; }

        private List<Chord> chords;
        public List<Chord> Chords
        {
            get { return chords; }
            set
            {
                chords = value;
                OnPropertyChanged(nameof(Chords));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
