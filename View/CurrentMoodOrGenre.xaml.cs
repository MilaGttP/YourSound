
using System.Windows.Controls;

namespace YourSound
{
    public partial class CurrentMoodOrGenre : UserControl
    {
        private Navigation navigation;
        public CurrentMoodOrGenre(Navigation navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;
        }
    }
}
