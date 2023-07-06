
using System.Windows.Controls;
using System.Windows.Input;

namespace YourSound
{
    public partial class SingerPage : UserControl
    {
        private Navigation navigation;
        private GeneralViewModel viewModel;
        private GeneralCommands generalCommands { get; set; }
        public SingerPage(Navigation navigation, GeneralViewModel generalViewModel, Singer current)
        {
            InitializeComponent();

            this.navigation = navigation;
            viewModel = generalViewModel;
            this.generalCommands = new GeneralCommands(navigation, generalViewModel);

            HomeBtn.Click += generalCommands.HomeBtn_Click;
        }
        private void SearchingTB_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                generalCommands.SearchingTB_Enter_Handle(SearchingTB.Text);
            }
        }
    }
}
