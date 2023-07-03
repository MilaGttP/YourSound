using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YourSound
{
    public class SongCommands
    {
        public void LikeBtn_Click(object sender, RoutedEventArgs e)
        {
            // передача current song та виклик методу SongOperations.IncreasePopularity
        }
    }
}
