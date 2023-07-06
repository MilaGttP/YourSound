
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class Tuner : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        private GeneralCommands generalCommands { get; set; }
        WMPLib.WindowsMediaPlayer player;
        public Tuner(Navigation navigation, GeneralViewModel generalViewModel)
        {
            InitializeComponent();
            this.navigation = navigation;
            player = new WMPLib.WindowsMediaPlayer();
            viewModel = generalViewModel;

            this.generalCommands = new GeneralCommands(navigation, generalViewModel);
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
