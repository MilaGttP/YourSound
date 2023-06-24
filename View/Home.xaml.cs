
using System.Windows.Controls;

namespace YourSound
{
    public partial class Home : UserControl
    {
        private Navigation navigation;
        public Home(Navigation navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);

            TunerBtn.Click += generalCommands.TunerBtn_Click;
            ChordLib_Btn.Click += generalCommands.ChordLibBtn_Click;
        }
    }
}
