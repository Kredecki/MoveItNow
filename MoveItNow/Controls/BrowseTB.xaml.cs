using MoveItNow.ViewModels;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace MoveItNow
{
    /// <summary>
    /// Logika interakcji dla klasy BrowseTB.xaml
    /// </summary>
    public partial class BrowseTB : System.Windows.Controls.UserControl
    {
        public readonly MainViewModel viewModel = new();
        
        public BrowseTB()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public void GetPath(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                viewModel.FilePath = dialog.FileName;
            }
        }
    }
}
