using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Text;
using System.Windows.Media.TextFormatting;
using VisionSDK_WPF.Common;

namespace VisionSDK_WPF.Models
{
    public class ImageListModel : CommonBase
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        
        private string _resolution;

        public string Resolution
        {
            get => _resolution;
            set => SetProperty(ref _resolution, value);
        }

        private string _format;

        public string Format
        {
            get => _format;
            set => SetProperty(ref _format, value);
        }
    }
}