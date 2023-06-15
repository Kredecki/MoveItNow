using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MoveItNow
{
    /// <summary>
    /// Logika interakcji dla klasy BrowseTB.xaml
    /// </summary>
    public partial class BrowseTB : System.Windows.Controls.UserControl
    {
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
            "Path",
            typeof(string),
            typeof(BrowseTB),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Path
        {
            get => (string)GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public BrowseTB()
        {
            InitializeComponent();
        }

        public void GetPath(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Path = dialog.FileName;
            }
        }
    }
}
