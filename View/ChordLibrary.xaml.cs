
using System.Windows.Controls;

namespace YourSound
{
    public partial class ChordLibrary : UserControl
    {
        private Navigation navigation;
        public ChordLibrary(Navigation navigation)
        {
            InitializeComponent();
            this.navigation = navigation;

            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;

            ChordsViewModel chordsViewModel = new ChordsViewModel();
            DataContext = chordsViewModel;
        }
    }
}
