using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Controls;
using System.Windows.Input;
using VisionSDK_WPF.Common;
using Accord;
using Accord.Imaging;
using Accord.Imaging.Filters;
using VisionSDK_WPF.Converters;
using VisionSDK_WPF.Models;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace VisionSDK_WPF.Viewmodels
{
    public class ucAlgorithmListViewModel : CommonBase
    {
        public TargetImageModel TargetImageModel { get; set; }
        public DataConverter DataConverter { get; set; }
        
        public ucAlgorithmListViewModel()
        {

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
            
            if (pf == PixelFormat.Format8bppIndexed)
            {
                Cv2.Threshold(inputMat, outputMat, 0, 255, ThresholdTypes.Otsu);
            }
            else
            {
                
            }

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
            Threshold,
            Otsu,
            GaussianBlur,
            Sharpen,
            Grayscale
        }
    }
}