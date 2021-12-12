using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace VisionSDK_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FolderPath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchDialog_OnClick(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            FolderPath = null;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FolderPath = fbd.SelectedPath;
            }
            else
            {
                MessageBox.Show("Folder did not selected.");
            }
        }
    }
}