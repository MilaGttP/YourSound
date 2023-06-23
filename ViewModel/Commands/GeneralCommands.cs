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
        }
    }
}
