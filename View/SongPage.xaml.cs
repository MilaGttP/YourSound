
using System.Windows;
using System.Windows.Controls;

namespace YourSound
{
    public partial class SongPage : UserControl
    {
        private Navigation navigation;
        static private Song selectedSong;
        public SongPage(Navigation navigation, Song selected)
        {
            InitializeComponent();
            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;
            selectedSong = selected;
            DataContext = selectedSong;
        }
    }
}
