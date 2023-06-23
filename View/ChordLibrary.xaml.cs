using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YourSound
{
    public partial class ChordLibrary : UserControl
    {
        private Navigation navigation;
        public ChordLibrary(Navigation navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            GeneralCommands generalCommands = new GeneralCommands(navigation);
            HomeBtn.Click += generalCommands.HomeBtn_Click;
        }
    }
}
