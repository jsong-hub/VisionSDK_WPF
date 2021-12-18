using System.ComponentModel;
using System.Drawing;
using System.Windows.Media.Imaging;
using VisionSDK_WPF.Common;
using VisionSDK_WPF.Models;
using VisionSDK_WPF.Converters;

namespace VisionSDK_WPF.Viewmodels
{
    public class ucImageDisplayViewModel : CommonBase
    {
        public SelectedImageModel SelectedImageModel { get; set; }
        public DataConverter DataConverter { get; set; }

        public ucImageDisplayViewModel()
        {
            this.DataConverter = new DataConverter();
            
            SelectedImageModel = GSingleton<ObjectManager>.Instance().SelectedImageModel;
            SelectedImageModel.PropertyChanged += SelectedImageModelOnPropertyChanged;
        }

        private void SelectedImageModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            SelectedImageSource = DataConverter.BitmapToImageSource(new Bitmap(SelectedImageModel.SelectedImagePath));
        }

        private BitmapImage _selectedImageSource;

        public BitmapImage SelectedImageSource
        {
            get => _selectedImageSource;
            set
            {
                _selectedImageSource = value;
                OnPropertyChanged(nameof(SelectedImageSource));
            }
        }
    }
}