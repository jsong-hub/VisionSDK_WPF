using System.Drawing;
using System.Windows.Automation.Peers;
using System.Windows.Media.Imaging;
using VisionSDK_WPF.Common;

namespace VisionSDK_WPF.Models
{
    public class TargetImageModel : CommonBase
    {
        private Bitmap _originBitmap;

        public Bitmap OriginBitmap
        {
            get => _originBitmap;
            set
            {
                _originBitmap = value;
                OnPropertyChanged(nameof(OriginBitmap));
            }
        }

        private Bitmap _processedBitmap;
        public Bitmap ProcessedBitmap
        {
            get => _processedBitmap;
            set
            {
                _processedBitmap = value;
                OnPropertyChanged(nameof(ProcessedBitmap));
            }
        }
        
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

        private bool _isApplied;

        public bool IsApplied
        {
            get => _isApplied;
            set => _isApplied = value;
        }
    }
}