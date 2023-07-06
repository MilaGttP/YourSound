
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace YourSound
{
    public class GeneralCommands
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        private SongAndSinger searched { get; set; }
        public GeneralCommands(Navigation navigation, GeneralViewModel generalViewModel)
        {
            this.navigation = navigation;
            viewModel = generalViewModel;
        }
        public void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(navigation);
            navigation.ShowUserControl(home);
        }
        public void ChordLibBtn_Click(object sender, RoutedEventArgs e)
        {
            ChordLibrary chordLibrary = new ChordLibrary(navigation, viewModel);
            navigation.ShowUserControl(chordLibrary);
        }
        public void TunerBtn_Click(object sender, RoutedEventArgs e)
        {
            Tuner tuner = new Tuner(navigation, viewModel);
            navigation.ShowUserControl(tuner);
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
        public async void SearchingTB_Enter_Handle(string text)
        {
            this.searched = await SongOperations.GetObjectsForSearching(text);

            if (searched.Song == null && searched.Singer == null)
            {
                MessageBox.Show("Не знайдено у базі даних :( Але я обов'язково з часом додам цю пісню чи цього автора!");
            }
            else if (searched.Song == null)
            {
                SingerPage singerPage = new SingerPage(navigation, viewModel, searched.Singer);
                navigation.ShowUserControl(singerPage);
            }
            else if (searched.Singer == null)
            {
                SongAndSinger songAndSinger = await SingerOperations.GetSongSinger(searched.Song);
                SongPage songPage = new SongPage(navigation, viewModel, songAndSinger);
                navigation.ShowUserControl(songPage);
            }
        }
    }
}
