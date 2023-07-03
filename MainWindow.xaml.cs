
using System.Windows;

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
