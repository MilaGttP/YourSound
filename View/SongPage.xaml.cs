
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;

namespace YourSound
{
    public partial class SongPage : UserControl
    {
        private Navigation navigation;
        private SongAndSinger songAndSinger;
        public SongPage(Navigation navigation, SongAndSinger selected)
        {
            InitializeComponent();

            this.navigation = navigation;
            songAndSinger = selected;
            songAndSinger.Chords = new List<Chord>();

            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;
            LikeBtn.Click += generalCommands.LikeBtn_Click;
            PlayBtn.Click += generalCommands.PlayBtn_Click;

            this.DataContext = songAndSinger;
            StrumOrParts.Text = songAndSinger.Song.IsStrum ? "Бій" : "Перебір";

            GetChordsForSelectedSong();
        }

        private async void GetChordsForSelectedSong()
        {
            songAndSinger.Chords = await SongOperations.GetAllChordsForSong(songAndSinger.Song.Name);
        }

        private void ChordClick(object sender, RoutedEventArgs e)
        {
            ChordLibrary chordLibrary = new ChordLibrary(navigation);
            navigation.ShowUserControl(chordLibrary);
        }
    }
}
