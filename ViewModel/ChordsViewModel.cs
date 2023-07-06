
using System.Collections.Generic;
using System.ComponentModel;

namespace YourSound
{
    public class ChordsViewModel : INotifyPropertyChanged
    {
        public ChordsViewModel() 
        {
            GetAllChords();
        }

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
        private Chord chord;
        public Chord Chord
        {
            get { return chord; }
            set
            {
                chord = value;
                OnPropertyChanged(nameof(Chord));
            }
        }
        private async void GetAllChords()
        {
            Chords = await ChordOperations.GetAllChords();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
