using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Text;
using System.Windows.Media.TextFormatting;
using VisionSDK_WPF.Common;

namespace VisionSDK_WPF.Models
{
    public class ImageListModel
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public string Resolution { get; set; }
        public string Format { get; set; }

        public string Size { get; set; }
    }
}