using System.Windows.Controls;
using VisionSDK_WPF.Viewmodels;

namespace VisionSDK_WPF.Views
{
    public partial class ucImageListView : UserControl
    {
        public ucImageListView()
        {
            InitializeComponent();

            DataContext = new ucImageListViewModel();
        }
    }
}