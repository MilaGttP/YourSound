
using System.Windows.Controls;

namespace YourSound
{
    public partial class SingerPage : UserControl
    {
        private Navigation navigation;
        public SingerPage(Navigation navigation)
        {
            InitializeComponent();

            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);

            HomeBtn.Click += generalCommands.HomeBtn_Click;
        }
    }
}
