
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class CurrentMoodOrGenre : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        private GeneralCommands generalCommands { get; set; }

        public CurrentMoodOrGenre(Navigation navigation, GeneralViewModel viewModel, string moodOrGenreName)
        {
            InitializeComponent();

            this.navigation = navigation;
            this.viewModel = viewModel;

            this.generalCommands = new GeneralCommands(navigation, viewModel);
            HomeBtn.Click += generalCommands.HomeBtn_Click;

            MoodOrGenreViewModel moodOrGenreViewModel = new MoodOrGenreViewModel(moodOrGenreName);
            DataContext = moodOrGenreViewModel;
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
