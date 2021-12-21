using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Input;
using VisionSDK_WPF.Common;
using VisionSDK_WPF.Converters;
using VisionSDK_WPF.Models;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ObjectManager = VisionSDK_WPF.Models.ObjectManager;

namespace VisionSDK_WPF.Viewmodels
{
    public class ucAlgorithmListViewModel : CommonBase
    {
        public TargetImageModel TargetImageModel { get; set; }
        public DataConverter DataConverter { get; set; }
        
        public ImageProcessor ImageProcessor { get; set; }
        
        public ucAlgorithmListViewModel()
        {
            ImageProcessor = new ImageProcessor();
            AlgorithmCollection = new ObservableCollection<string>();
            LoadAlgorithmList();
        }

        public ICommand ApplyCommand => new RelayCommand(Apply);

        private ObservableCollection<string> _algorithmCollection;

        public ObservableCollection<string> AlgorithmCollection
        {
            get => _algorithmCollection;
            set
            {
                _algorithmCollection = value; 
                OnPropertyChanged(nameof(AlgorithmCollection));
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                SetPropertyGrid();
                // OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private void SetPropertyGrid()
        {

        }
        
        private void Apply(object o)
        {
            Mat inputMat = BitmapConverter.ToMat(GSingleton<ObjectManager>.Instance().TargetImageModel
                .OriginBitmap);
            Mat grayMat = new Mat();
            Mat outputMat = new Mat();

            PixelFormat pf;
            switch (inputMat.Channels())
            {
                case 1:
                    pf = PixelFormat.Format8bppIndexed; break;
                case 3:
                    pf = PixelFormat.Format24bppRgb; break;
                case 4:
                    pf = PixelFormat.Format32bppArgb; break;
                default:
                    throw new ArgumentException("Number of channels must be 1, 3 or 4.", nameof(inputMat));
            }
            switch (SelectedIndex)
            {
                case 0:
                    outputMat = ImageProcessor.RunColorToGrayscale(inputMat);
                    break;
                case 1:
                    //Threshold
                    break;
                case 2:
                    outputMat = ImageProcessor.RunAdaptiveOtsuThreshold(inputMat);
                    break;
                case 3:
                    //blur
                    break;
                case 4:
                    //sharpen
                    break;
                case 5:
                    outputMat = ImageProcessor.RunHoughCircleDetection(inputMat);
                    break;
                case 6:
                    //3pointcircle
                default:
                    throw new ArgumentException("", nameof(SelectedIndex));
            }
            // if (pf == PixelFormat.Format8bppIndexed)
            // {
            //
            //     
            //     // Cv2.Threshold(inputMat, outputMat, 0, 255, ThresholdTypes.Otsu);
            // }
            // else
            // {
            //     
            // }

            Bitmap outputImage = BitmapConverter.ToBitmap(outputMat);
            GSingleton<ObjectManager>.Instance().TargetImageModel.IsApplied = true;
            GSingleton<ObjectManager>.Instance().TargetImageModel.ProcessedBitmap = new Bitmap(outputImage);
        }

        private void LoadAlgorithmList()
        {
            foreach (var enumItem in Enum.GetValues(typeof(EAlgorithms)))
            {
                AlgorithmCollection.Add(enumItem.ToString());
            }
        }

        enum EAlgorithms
        {
            Grayscale,
            Threshold,
            AdaptiveOtsu,
            GaussianBlur,
            Sharpen,
            HoughCircleDetection,
            ThreePointCircle
        }
    }
}