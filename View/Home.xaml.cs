
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class Home : UserControl
    {
        private Navigation navigation;
        private SongCommands songCommands;
        public GeneralViewModel generalViewModel { get; set; }
        public Home(Navigation navigation)
        {
            InitializeComponent();

            generalViewModel = new GeneralViewModel();
            this.DataContext = generalViewModel;

            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);
            songCommands = new SongCommands(navigation, generalViewModel);

            TunerBtn.Click += generalCommands.TunerBtn_Click;
            ChordLib_Btn.Click += generalCommands.ChordLibBtn_Click;
            MusicLifeBtn.Click += MusicLifeBtn_Click;
        }
        private void MusicLifeBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://soundcloud.com/bmrg69p5xbsv";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        public void SongPage_Click(object sender, MouseButtonEventArgs e)
        {
            var temp = sender as ListView;
            var temp2 = temp.SelectedItems as Song;

            if (generalViewModel.SelectedSong == null) MessageBox.Show("Ну бл пздц.");
            else MessageBox.Show(generalViewModel.SelectedSong.Name);

            SongPage songPage = new SongPage(navigation, generalViewModel.SelectedSong);
            navigation.ShowUserControl(songPage);
        }

    }
}
