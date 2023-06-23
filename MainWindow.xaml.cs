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
    public partial class MainWindow : Window
    {
        private Navigation navigation;
        public MainWindow()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            this.Width = screenWidth * 0.65; 
            this.Height = screenHeight * 0.7;
            navigation = new Navigation(mainFrame);
            Home home = new Home(navigation);
            navigation.ShowUserControl(home);
        }
    }
}
