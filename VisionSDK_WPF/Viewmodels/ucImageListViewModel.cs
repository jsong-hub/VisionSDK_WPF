using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using VisionSDK_WPF.Common;
using VisionSDK_WPF.Models;

namespace VisionSDK_WPF.Viewmodels
{
    public class ucImageListViewModel : CommonBase
    {
        public ucImageListViewModel()
        {
            // Test();
            // GetImageFiles();
        }

        private ObservableCollection<ImageListModel> _items;

        public ObservableCollection<ImageListModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public ICommand SelectFolderCommand => new RelayCommand(SelectFolder);

        public void SelectFolder(object o)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    GSingleton<ObjectManager>.Instance().SelectedFolderPath = fbd.SelectedPath;
                    string selectedPath = GSingleton<ObjectManager>.Instance().SelectedFolderPath;
                    GetImageFiles(selectedPath);
                }
            }
        }

        public void GetImageFiles(string selectedPath)
        {
            List<ImageListModel> ImageList = new List<ImageListModel>();

            foreach (var fileName in Directory.GetFiles(selectedPath))
            {
                if (Regex.IsMatch(fileName, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    Bitmap src = new Bitmap(fileName);

                    ImageListModel data = new ImageListModel();
                    data.Format = Path.GetExtension(fileName);
                    data.Resolution = src.Width + "x" + src.Height;
                    data.Name = Path.GetFileNameWithoutExtension(fileName);
                    data.Size = FormatBytes(new FileInfo(fileName).Length);

                    GSingleton<ObservableCollection<ImageListModel>>.Instance().Add(data);
                }
            }

            Items = GSingleton<ObservableCollection<ImageListModel>>.Instance();
        }
        
        public string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }
    }
}