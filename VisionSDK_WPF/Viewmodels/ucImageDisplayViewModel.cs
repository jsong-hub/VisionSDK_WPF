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
        public TargetImageModel TargetImageModel { get; set; }
        public DataConverter DataConverter { get; set; }

        public ucImageDisplayViewModel()
        {
            this.DataConverter = new DataConverter();

            TargetImageModel = GSingleton<ObjectManager>.Instance().TargetImageModel;
            TargetImageModel.PropertyChanged += SelectedImageModelOnPropertyChanged;
        }

        private void SelectedImageModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (TargetImageModel.IsApplied)
            {
                SelectedImageSource = DataConverter.BitmapToImageSource(TargetImageModel.ProcessedBitmap);
                TargetImageResolution 
                    = TargetImageModel.ProcessedBitmap.Width + "x" + TargetImageModel.ProcessedBitmap.Height;
                TargetImagePixelFormat = TargetImageModel.ProcessedBitmap.PixelFormat.ToString();
            }
            else
            {
                SelectedImageSource = DataConverter.BitmapToImageSource(TargetImageModel.OriginBitmap);
                TargetImageResolution =
                    TargetImageModel.OriginBitmap.Width + "x" + TargetImageModel.OriginBitmap.Height;
                TargetImagePixelFormat = TargetImageModel.OriginBitmap.PixelFormat.ToString();
            }
            SelectedImageSource 
                = DataConverter.BitmapToImageSource(TargetImageModel.IsApplied ? TargetImageModel.ProcessedBitmap : TargetImageModel.OriginBitmap);
            SelectedImageName = Path.GetFileName(TargetImageModel.SelectedImagePath);
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

        private string _selectedImageName = "Image Name";

        public string SelectedImageName
        {
            get => _selectedImageName;
            set
            {
                _selectedImageName = value;
                OnPropertyChanged(nameof(SelectedImageName));
            }
        }

        private string _targetImageResolution;

        public string TargetImageResolution
        {
            get => _targetImageResolution;
            set
            {
                _targetImageResolution = value;
                OnPropertyChanged(nameof(TargetImageResolution));
            }
        }

        private string _targetImagePixelFormat;

        public string TargetImagePixelFormat
        {
            get => _targetImagePixelFormat;
            set
            {
                _targetImagePixelFormat = value;
                OnPropertyChanged(nameof(TargetImagePixelFormat));
            }
        }

        private void SetDisplayImageProperties()
        {

        }


        private void SetSelectedImageInObjectManager()
        {
            
        }

        public ICommand SaveFileCommand => new RelayCommand(SaveFile);
        public ICommand OverwriteImageCommand => new RelayCommand(OverwriteImage);

        private void SaveFile(object o)
        {
            if (GSingleton<ObjectManager>.Instance().TargetImageModel.ProcessedBitmap != null)
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = @"D:";
                    sfd.Filter = "PNG File(*.png)|*.png|Bitmap File(*.bmp)|*.bmp|JPEG File(*.jpg)|*.jpg";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var saveFileName = sfd.FileName;
                        var targetImage = GSingleton<ObjectManager>.Instance().TargetImageModel.ProcessedBitmap;
                        targetImage.Save(saveFileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Any processing did not applied.");
            }
        }
        
        private void OverwriteImage(object o)
        {
            if (TargetImageModel.IsApplied)
            {
                GSingleton<ObjectManager>.Instance().TargetImageModel.OriginBitmap = TargetImageModel.ProcessedBitmap;
            }
        }
    }
}