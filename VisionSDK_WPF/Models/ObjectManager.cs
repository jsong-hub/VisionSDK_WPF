using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace VisionSDK_WPF.Models
{
    public class ObjectManager
    {
        public readonly ImageListModel ImageListModel = new ImageListModel();

        public readonly ObservableCollection<ImageListModel> ImageListCollectionModel =
            new ObservableCollection<ImageListModel>();

        public readonly TargetImageModel TargetImageModel = new TargetImageModel();

        public string SelectedFolderPath = null;
    }
}