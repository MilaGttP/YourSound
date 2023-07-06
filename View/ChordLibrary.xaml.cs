
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class ChordLibrary : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        private GeneralCommands generalCommands;
        private ChordsViewModel chordsViewModel;
        public ChordLibrary(Navigation navigation, GeneralViewModel generalViewModel)
        {
            InitializeComponent();
            this.navigation = navigation;
            viewModel = generalViewModel;

            this.generalCommands = new GeneralCommands(navigation, generalViewModel);
            HomeBtn.Click += generalCommands.HomeBtn_Click;

            this.chordsViewModel = new ChordsViewModel();
            DataContext = chordsViewModel;
        }
        private void SearchingTB_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                generalCommands.SearchingTB_Enter_Handle(SearchingTB.Text);
            }
        }

        private void CurrentChordPage(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Chord selected = button.DataContext as Chord;
            chordsViewModel.Chord = selected;

            CurrentChord currentChord = new CurrentChord(navigation, viewModel, chordsViewModel);
            navigation.ShowUserControl(currentChord);
        }
    }
}
