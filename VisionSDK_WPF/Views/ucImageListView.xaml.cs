using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using VisionSDK_WPF.Common;
using VisionSDK_WPF.Models;
using VisionSDK_WPF.Viewmodels;
using UserControl = System.Windows.Controls.UserControl;

namespace VisionSDK_WPF.Views
{
    public partial class ucImageListView : UserControl
    {
        public ucImageListView()
        {
            InitializeComponent();

            // DataContext = new ucImageListViewModel(null);
        }

        public List<ImageListModel> ImageList { get; set; }

        private void SelectFolderPathButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    GetImageFiles(fbd.SelectedPath);
                }
            }
        }
        
        public void GetImageFiles(string folderPath)
        {
            ImageList = new List<ImageListModel>();
            
            foreach (var fileName in Directory.GetFiles(folderPath))
            {
                if (Regex.IsMatch(fileName, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    Bitmap src = new Bitmap(fileName);

                    ImageListModel data = new ImageListModel();
                    data.Format = Path.GetExtension(fileName);
                    data.Resolution = src.Width + "x" + src.Height;
                    data.Name = Path.GetFileNameWithoutExtension(fileName);
                    
                    GSingleton<ObservableCollection<ImageListModel>>.Instance().Add(data);
                    
                    ImageList.Add(new ImageListModel()
                    {
                        Format = Path.GetExtension(fileName),
                        IsSelected = false,
                        Name = Path.GetFileNameWithoutExtension(fileName),
                        Resolution = src.Width + "x" + src.Height,
                        Size = new FileInfo(fileName).Length.ToString()
                    });
                }
            }

            ImageListView.ItemsSource = ImageList;
            // Items = GSingleton<ObservableCollection<ImageListModel>>.Instance();
        }
    }
}