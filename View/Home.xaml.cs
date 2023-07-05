
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
        public GeneralViewModel generalViewModel { get; set; }
        public Home(Navigation navigation)
        {
            InitializeComponent();

            generalViewModel = new GeneralViewModel();
            this.DataContext = generalViewModel;

            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);

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

            SongPage songPage = new SongPage(navigation, generalViewModel.SelectedSongAndAuthor);
            navigation.ShowUserControl(songPage);
        }
        public void MoodBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            CurrentMoodOrGenre currentMoodOrGenre = new CurrentMoodOrGenre(navigation, button.Name, generalViewModel);
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
    }
}
