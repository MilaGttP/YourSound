
using System.Windows;
using System.Windows.Controls;

namespace YourSound
{
    public partial class CurrentMoodOrGenre : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel generalViewModel;
        public CurrentMoodOrGenre(Navigation navigation, string moodOrGenreName, GeneralViewModel viewModel)
        {
            InitializeComponent();

            this.navigation = navigation;
            this.generalViewModel = viewModel;

            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;

            MoodOrGenreViewModel moodOrGenreViewModel = new MoodOrGenreViewModel(moodOrGenreName);
            DataContext = moodOrGenreViewModel;
        }
        public void SongPage_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            generalViewModel.SelectedSongAndAuthor = button.DataContext as SongAndSinger;

            SongPage songPage = new SongPage(navigation, generalViewModel.SelectedSongAndAuthor);
            navigation.ShowUserControl(songPage);
        }
    }
}
