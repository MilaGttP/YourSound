
using System.Windows.Controls;

namespace YourSound
{
    public partial class SongPage : UserControl
    {
        private Navigation navigation;
        public SongPage(Navigation navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;
        }
    }
}
