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

        private List<string> LoadedImageList = new List<string>();

        private ObservableCollection<ImageListModel> _imageCollection;

        public ObservableCollection<ImageListModel> ImageCollection
        {
            get => _imageCollection;
            set
            {
                _imageCollection = value;
                OnPropertyChanged(nameof(ImageCollection));
            }
        }

        private string _selectedFolderPath = "Folder Path";

        public string SelectedFolderPath
        {
            get => _selectedFolderPath;
            set
            {
                _selectedFolderPath = value;
                OnPropertyChanged(nameof(SelectedFolderPath));
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                ChangeSelectedItemPath();
            }
        }

        public ICommand SelectFolderCommand => new RelayCommand(SelectFolder);
        public ICommand SelectFileCommand => new RelayCommand(SelectFile);

        public void SelectFolder(object o)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = fbd.SelectedPath;
                    GetImageFiles(selectedPath);
                }
            }
        }

        public void SelectFile(object o)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = ofd.FileName;
                    GetImageFile(selectedFile);
                }
            }
        }

        public void GetImageFiles(string folderPath)
        {
            foreach (var fileName in Directory.GetFiles(folderPath))
            {
                LoadedImageList.Add(fileName);
                if (Regex.IsMatch(fileName, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    ImageListModel data = new ImageListModel();
                    data.Format = Path.GetExtension(fileName);
                    data.Name = Path.GetFileNameWithoutExtension(fileName);
                    data.Size = FormatBytes(new FileInfo(fileName).Length);
                    
                    GSingleton<ObjectManager>.Instance().ImageListCollectionModel.Add(data);
                }
            }

            ImageCollection = GSingleton<ObjectManager>.Instance().ImageListCollectionModel;
        }

        public void GetImageFile(string filePath)
        {
            LoadedImageList.Add(filePath);
            if (Regex.IsMatch(filePath, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
            {
                ImageListModel data = new ImageListModel();
                data.Format = Path.GetExtension(filePath);
                data.Name = Path.GetFileNameWithoutExtension(filePath);
                data.Size = FormatBytes(new FileInfo(filePath).Length);

                GSingleton<ObjectManager>.Instance().ImageListCollectionModel.Add(data);
            }
        }

        private void ChangeSelectedItemPath()
        {
            GSingleton<ObjectManager>.Instance().TargetImageModel.IsApplied = false;
            GSingleton<ObjectManager>.Instance().TargetImageModel.OriginBitmap 
                = new Bitmap(LoadedImageList[SelectedIndex]);
            GSingleton<ObjectManager>.Instance().TargetImageModel.SelectedImagePath = LoadedImageList[SelectedIndex];
        }

        public string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = { "GB", "MB", "KB", "Bytes" };
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