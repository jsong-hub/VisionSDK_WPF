using System.Windows.Media.Imaging;
using VisionSDK_WPF.Common;

namespace VisionSDK_WPF.Models
{
    public class SelectedImageModel : CommonBase
    {
        private string _selectedImagePath;
        public string SelectedImagePath
        {
            get => _selectedImagePath;
            set
            {
                _selectedImagePath = value;
                OnPropertyChanged(nameof(SelectedImagePath));
            }
        }
    }
}