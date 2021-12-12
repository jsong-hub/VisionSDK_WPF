using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisionSDK_WPF.Common;
using VisionSDK_WPF.Models;

namespace VisionSDK_WPF.Viewmodels
{
    public class ucImageListViewModel : CommonBase
    {

        public ucImageListViewModel()
        {
            Items = new ObservableCollection<ImageListModel>();
        }
        
        public static List<string> ImageFileList { get; set; }

        public ObservableCollection<ImageListModel> Items { get; }


        public void GetImageFiles(string folderPath)
        {
            ImageFileList = new List<string>();

            foreach (var fileName in Directory.GetFiles(folderPath))
            {
                if (Regex.IsMatch(fileName, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    ImageFileList.Add(fileName);
                    
                    Bitmap src = new Bitmap(fileName);
                    
                    Items.Add(new ImageListModel()
                    {
                        Format = Path.GetExtension(fileName),
                        Resolution = src.Width + "x" + src.Height,
                        Name = Path.GetFileNameWithoutExtension(fileName)
                    });
                }
            }
        }

        public bool? IsAllItemsSelected
        {
            get
            {
                var selected = Items.Select(item => item.IsSelected).Distinct().ToList();
                return selected.Count == 1 ? selected.Single() : (bool?) null;
            }
            set
            {
                if (value.HasValue)
                {
                    SelectAll(value.Value, Items);
                    OnPropertyChanged();
                }
            }
        }
        
        private static void SelectAll(bool select, IEnumerable<ImageListModel> models)
        {
            foreach (var model in models)
            {
                model.IsSelected = select;
            }
        }

        public void RefreshImageList()
        {
            foreach (var image in Items)
            {
                image.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == nameof(ImageListModel.IsSelected))
                        OnPropertyChanged(nameof(IsAllItemsSelected));
                };
            }
        }
        
        private static ObservableCollection<ImageListModel> CreateData(string fileName)
        {
            return new ObservableCollection<ImageListModel>
            {
                
                new ImageListModel
                {

                }
            };
        }
    }
}