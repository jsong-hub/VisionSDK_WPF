using System.Collections.ObjectModel;

namespace VisionSDK_WPF.Models
{
    public class ObjectManager
    {
        public readonly ImageListModel ImageListModel = new ImageListModel();

        public readonly ObservableCollection<ImageListModel> ImageListCollectionModel =
            new ObservableCollection<ImageListModel>();

        public string SelectedFolderPath = null;
    }
}