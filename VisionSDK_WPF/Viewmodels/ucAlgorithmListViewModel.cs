using System.Collections.ObjectModel;
using VisionSDK_WPF.Common;

namespace VisionSDK_WPF.Viewmodels
{
    public class ucAlgorithmListViewModel : CommonBase
    {
        public ucAlgorithmListViewModel()
        {
            AlgorithmCollection = new ObservableCollection<string>();
            
            LoadAlgorithmList();
        }

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

        private bool _isListScroll;

        public bool IsListScroll
        {
            get => _isListScroll;
            set
            {
                _isListScroll = value;
                OnPropertyChanged(nameof(IsListScroll));
            }
        }

        private void LoadAlgorithmList()
        {
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");
            AlgorithmCollection.Add("Threshold");
            AlgorithmCollection.Add("Otsu");
            AlgorithmCollection.Add("Gaussian Blur");
            AlgorithmCollection.Add("Sharpen");

            IsListScroll = true;
        }
    }
}