using System.Windows.Controls;
using VisionSDK_WPF.Viewmodels;

namespace VisionSDK_WPF.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
    }
}