
using System.Windows.Controls;

namespace YourSound
{
    public class Navigation
    {
        private Frame mainFrame;

        public Navigation(Frame frame)
        {
            mainFrame = frame;
        }

        public void ShowUserControl(UserControl userControl)
        {
            mainFrame.Content = userControl;
        }
    }
}
