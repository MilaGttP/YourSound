
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class Home : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel generalViewModel { get; set; }
        private GeneralCommands generalCommands { get; set; }
        private SongAndSinger searched { get; set; }
        public Home(Navigation navigation)
        {
            InitializeComponent();

            generalViewModel = new GeneralViewModel();
            this.DataContext = generalViewModel;

            this.navigation = navigation;
            this.generalCommands = new GeneralCommands(navigation, generalViewModel);

            TunerBtn.Click += generalCommands.TunerBtn_Click;
            ChordLib_Btn.Click += generalCommands.ChordLibBtn_Click;
            MusicLifeBtn.Click += MusicLifeBtn_Click;
        }
        private void MusicLifeBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://soundcloud.com/bmrg69p5xbsv";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        public void SongPage_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            generalViewModel.SelectedSongAndAuthor = button.DataContext as SongAndSinger;

            SongPage songPage = new SongPage(navigation, generalViewModel, generalViewModel.SelectedSongAndAuthor);
            navigation.ShowUserControl(songPage);
        }
        public void MoodBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            CurrentMoodOrGenre currentMoodOrGenre = new CurrentMoodOrGenre(navigation, generalViewModel, button.Name);
            navigation.ShowUserControl(currentMoodOrGenre);
        }
        public void LikeBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            SongAndSinger selected = button.DataContext as SongAndSinger;
            SongOperations.IncreasePopularity(selected.Song.ID);
        }
        public void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            SongAndSinger selected = button.DataContext as SongAndSinger;
            Process.Start(new ProcessStartInfo(selected.Song.Url) { UseShellExecute = true });
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
