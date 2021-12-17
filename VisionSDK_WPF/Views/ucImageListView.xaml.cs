using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
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

            DataContext = new ucImageListViewModel();
        }
    }
}