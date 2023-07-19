
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class Tuner : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        private string appPath, parentDirectory, soundFilePath;
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

            appPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            parentDirectory = Directory.GetParent(appPath).Parent.Parent.Parent.FullName;

            ELowTunerBtn.Click += ELowTunerBtn_Click;
            ATunerBtn.Click += ATunerBtn_Click;
            DTunerBtn.Click += DTunerBtn_Click;
            GTunerBtn.Click += GTunerBtn_Click;
            BTunerBtn.Click += BTunerBtn_Click;
            EHighTunerBtn.Click += EHighTunerBtn_Click;
        }

        public void ELowTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            soundFilePath = Path.Combine(parentDirectory, "Assets\\Sounds\\E2.mp3");
            player.URL = soundFilePath;
            player.controls.play();
        }
        public void ATunerBtn_Click(object sender, RoutedEventArgs e)
        {
            soundFilePath = Path.Combine(parentDirectory, "Assets\\Sounds\\A.mp3");
            player.URL = soundFilePath;
            player.controls.play();
        }
        public void DTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            soundFilePath = Path.Combine(parentDirectory, "Assets\\Sounds\\D.mp3");
            player.URL = soundFilePath;
            player.controls.play();
        }
        public void GTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            soundFilePath = Path.Combine(parentDirectory, "Assets\\Sounds\\G.mp3");
            player.URL = soundFilePath;
            player.controls.play();
        }
        public void BTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            soundFilePath = Path.Combine(parentDirectory, "Assets\\Sounds\\B.mp3");
            player.URL = soundFilePath;
            player.controls.play();
        }
        public void EHighTunerBtn_Click(object sender, RoutedEventArgs e)
        {
            soundFilePath = Path.Combine(parentDirectory, "Assets\\Sounds\\E4.mp3");
            player.URL = soundFilePath;
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
