using System.Windows.Controls;
using VisionSDK_WPF.Viewmodels;

namespace VisionSDK_WPF.Views
{
    public partial class ucImageDisplayView : UserControl
    {
        public ucImageDisplayView()
        {
            InitializeComponent();

            DataContext = new ucImageDisplayViewModel();
        }
    }
}