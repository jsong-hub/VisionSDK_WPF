using System.Windows.Controls;
using VisionSDK_WPF.Viewmodels;

namespace VisionSDK_WPF.Views
{
    public partial class ucAlgorithmListView : UserControl
    {
        public ucAlgorithmListView()
        {
            InitializeComponent();

            DataContext = new ucAlgorithmListViewModel();
        }
    }
}