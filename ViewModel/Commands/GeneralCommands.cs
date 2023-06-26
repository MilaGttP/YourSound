using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            //CurrentMoodOrGenre currentMoodOrGenre = new CurrentMoodOrGenre(navigation);
            //navigation.ShowUserControl(currentMoodOrGenre);

            //SingerPage singer = new SingerPage(navigation);
            //navigation.ShowUserControl(singer);

            //SongPage songPage = new SongPage(navigation);
            //navigation.ShowUserControl(songPage);
        }
        public void TunerBtn_Click(object sender, RoutedEventArgs e)
        {
            Tuner tuner = new Tuner(navigation);
            navigation.ShowUserControl(tuner);
        }
    }
}
