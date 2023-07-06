
using System;
using System.Windows;

namespace YourSound
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SplashScreen splashScreen = new SplashScreen("\\Assets\\logo.png");
            splashScreen.Show(false);
            splashScreen.Close(TimeSpan.FromSeconds(2));
        }
    }
}
