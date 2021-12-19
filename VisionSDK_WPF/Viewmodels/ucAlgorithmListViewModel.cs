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
            Bitmap inputImage = GSingleton<ObjectManager>.Instance().TargetImageModel.OriginBitmap;
            // // Bitmap bmpData = inputImage.LockBits(new Rectangle(0, 0, inputImage.Width, inputImage.Height),
            // //     ImageLockMode.ReadWrite, inputImage.PixelFormat);
            // Bitmap outputImage = Grayscale.CommonAlgorithms.BT709.Apply(inputImage);
            //
            // GSingleton<ObjectManager>.Instance().TargetImageModel.ProcessedBitmap = new Bitmap(outputImage);
            // GSingleton<ObjectManager>.Instance().TargetImageModel.IsApplied = true;
            
            // inputImage.UnlockBits(bmpData);
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