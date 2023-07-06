
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class SingerPage : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        private GeneralCommands generalCommands;
        private SingerViewModel singerViewModel;
        public SingerPage(Navigation navigation, GeneralViewModel generalViewModel, Singer current)
        {
            InitializeComponent();

            this.navigation = navigation;
            viewModel = generalViewModel;
            this.generalCommands = new GeneralCommands(navigation, generalViewModel);
            HomeBtn.Click += generalCommands.HomeBtn_Click;

            singerViewModel = new SingerViewModel(current);
            DataContext = singerViewModel;
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
        public void SongPage_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            viewModel.SelectedSongAndAuthor = button.DataContext as SongAndSinger;

            SongPage songPage = new SongPage(navigation, viewModel, viewModel.SelectedSongAndAuthor);
            navigation.ShowUserControl(songPage);
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
