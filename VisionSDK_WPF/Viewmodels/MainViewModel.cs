using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using VisionSDK_WPF.Common;

namespace VisionSDK_WPF.Viewmodels
{
    public class MainViewModel : CommonBase
    {
        private ucImageListViewModel _ucImageListViewModel;

        public MainViewModel()
        {
            _ucImageListViewModel = new ucImageListViewModel();
        }

        public ICommand SelectFolderCommand => new RelayCommand(ExecuteSelectFolder);

        private void ExecuteSelectFolder(object o)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // _ucImageListViewModel.GetImageFiles(fbd.SelectedPath);
                }
            }
        }
    }
}