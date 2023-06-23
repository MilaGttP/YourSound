
using System.Windows;
using System.Windows.Controls;

namespace YourSound
{
    public partial class Tuner : UserControl
    {
        private Navigation navigation;
        WMPLib.WindowsMediaPlayer player;
        public Tuner(Navigation navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            player = new WMPLib.WindowsMediaPlayer();
            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;

            ELowTunerBtn.Click += ELowTunerBtn_Click;
            ATunerBtn.Click += ATunerBtn_Click;
            DTunerBtn.Click += DTunerBtn_Click;
            GTunerBtn.Click += GTunerBtn_Click;
            BTunerBtn.Click += BTunerBtn_Click;
            EHighTunerBtn.Click += EHighTunerBtn_Click;
        }

        public void ELowTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            player.URL = "E2.mp3";
            player.controls.play();
        }
        public void ATunerBtn_Click(object sender, RoutedEventArgs e)
        {
            player.URL = "A.mp3";
            player.controls.play();
        }
        public void DTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            player.URL = "D.mp3";
            player.controls.play();
        }
        public void GTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            player.URL = "G.mp3";
            player.controls.play();
        }
        public void BTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            player.URL = "B.mp3";
            player.controls.play();
        }
        public void EHighTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            player.URL = "E4.mp3";
            player.controls.play();
        }
    }
}
