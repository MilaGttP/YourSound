using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public class SongCommands
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        public SongCommands() 
        {
            navigation = null;
            viewModel = null;
        }
        public SongCommands(Navigation navigation, GeneralViewModel viewModel)
        {
            this.navigation = navigation;
            this.viewModel = viewModel;
        }

        
        public void LikeBtn_Click(object sender, RoutedEventArgs e)
        {
            // передача current song та виклик методу SongOperations.IncreasePopularity
        }
    }
}
