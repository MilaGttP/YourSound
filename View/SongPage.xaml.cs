
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace YourSound
{
    public partial class SongPage : UserControl
    {
        private Navigation navigation;
        private SongAndSinger songAndSinger;
        private GeneralViewModel viewModel;
        private GeneralCommands generalCommands { get; set; }
        public SongPage(Navigation navigation, GeneralViewModel generalViewModel, SongAndSinger selected)
        {
            InitializeComponent();

            this.navigation = navigation;
            songAndSinger = selected;

            songAndSinger.Chords = new List<Chord>();
            viewModel = generalViewModel;

            this.generalCommands = new GeneralCommands(navigation, generalViewModel);
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
            ChordLibrary chordLibrary = new ChordLibrary(navigation, viewModel);
            navigation.ShowUserControl(chordLibrary);
        }
        private void SearchingTB_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                generalCommands.SearchingTB_Enter_Handle(SearchingTB.Text);
            }
        }
    }
}
