using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using Accessibility;
using VisionSDK_WPF.Common;
using VisionSDK_WPF.Models;

namespace VisionSDK_WPF.Viewmodels
{
    public class ucImageListViewModel : CommonBase
    {

        public ucImageListViewModel()
        {
            // Items = new ObservableCollection<ImageListModel>();
            // Test();
        }
        
        public static List<string> ImageFileList { get; set; }

        private ObservableCollection<ImageListModel> _items = null;
        public ObservableCollection<ImageListModel> Items
        {
            get { return _items ??= new ObservableCollection<ImageListModel>(); }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }


        public void GetImageFiles(string folderPath)
        {
            ImageFileList = new List<string>();

            foreach (var fileName in Directory.GetFiles(folderPath))
            {
                if (Regex.IsMatch(fileName, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    ImageFileList.Add(fileName);
                    
                    Bitmap src = new Bitmap(fileName);

                    ImageListModel data = new ImageListModel();
                    data.Format = Path.GetExtension(fileName);
                    data.Resolution = src.Width + "x" + src.Height;
                    data.Name = Path.GetFileNameWithoutExtension(fileName);
                    
                    Items.Add(data);

                    // Items.Add(new ImageListModel()
                    // {
                    //     Format = Path.GetExtension(fileName),
                    //     Resolution = src.Width + "x" + src.Height,
                    //     Name = Path.GetFileNameWithoutExtension(fileName)
                    // });
                }
            }
        }

        public void Test()
        {
            ImageListModel data = new ImageListModel();
            data.Format = ".jpg";
            data.Name = "test";
            data.Resolution = "120x100";
            data.IsSelected = false;
            
            Items.Add(data);
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

        // public void RefreshImageList()
        // {
        //     foreach (var image in Items)
        //     {
        //         image.PropertyChanged += (sender, args) =>
        //         {
        //             if (args.PropertyName == nameof(ImageListModel.IsSelected))
        //                 OnPropertyChanged(nameof(IsAllItemsSelected));
        //         };
        //     }
        // }
        
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