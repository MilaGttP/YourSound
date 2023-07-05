using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YourSound
{
    public class GeneralCommands
    {
        private Navigation navigation;
        public GeneralCommands(Navigation navigation)
        {
            this.navigation = navigation;
        }
        public void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(navigation);
            navigation.ShowUserControl(home);
        }
        public void ChordLibBtn_Click(object sender, RoutedEventArgs e)
        {
            ChordLibrary chordLibrary = new ChordLibrary(navigation);
            navigation.ShowUserControl(chordLibrary);
        }
        public void TunerBtn_Click(object sender, RoutedEventArgs e)
        {
            Tuner tuner = new Tuner(navigation);
            navigation.ShowUserControl(tuner);
        }
        public void LikeBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            SongAndSinger selected = button.DataContext as SongAndSinger;
            SongOperations.IncreasePopularity(selected.Song.ID);
        }
        public void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            SongAndSinger selected = button.DataContext as SongAndSinger;
            Process.Start(new ProcessStartInfo(selected.Song.Url) { UseShellExecute = true });
        }
    }
}
