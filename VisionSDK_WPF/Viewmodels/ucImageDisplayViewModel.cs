using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using System.Windows.Input;
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
            SelectedImageName = Path.GetFileName(SelectedImageModel.SelectedImagePath);
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

        private string _selectedImageName;

        public string SelectedImageName
        {
            get => _selectedImageName;
            set
            {
                _selectedImageName = value;
                OnPropertyChanged(nameof(SelectedImageName));
            }
        }

        public ICommand SaveFileCommand => new RelayCommand(SaveFile);

        private void SaveFile(object o)
        {
            string saveFileName = null;
            
            using (var sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = @"C:";
                sfd.Filter = "JPEG File(*.jpg)|*.jpg|Bitmap File(*.bmp)|*.bmp|PNG File(*.png)|*.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    saveFileName = sfd.FileName;
                    //TODO: 알고리즘이 적용된 이미지를 ObjectManager에서 관리하여 저장해야함.
                }
            }
        }
    }
}