
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace YourSound
{
    public partial class Home : UserControl
    {
        private Navigation navigation;
        public GeneralViewModel generalViewModel { get; set; }
        public Home(Navigation navigation)
        {
            InitializeComponent();

            generalViewModel = new GeneralViewModel();
            this.DataContext = generalViewModel;

            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);

            TunerBtn.Click += generalCommands.TunerBtn_Click;
            ChordLib_Btn.Click += generalCommands.ChordLibBtn_Click;
            MusicLifeBtn.Click += MusicLifeBtn_Click;
        }
        private void MusicLifeBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://soundcloud.com/bmrg69p5xbsv";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
