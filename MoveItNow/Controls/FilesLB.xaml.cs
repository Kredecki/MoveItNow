using MoveItNow.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MoveItNow
{
    /// <summary>
    /// Logika interakcji dla klasy FilesLB.xaml
    /// </summary>
    public partial class FilesLB : System.Windows.Controls.UserControl
    {
        public static readonly DependencyProperty FilesProperty = DependencyProperty.Register(
                   "Files",
                   typeof(ObservableCollection<string>),
                   typeof(FilesLB),
                   new PropertyMetadata(default(ObservableCollection<string>)));

        public ObservableCollection<string> Files
        {
            get => (ObservableCollection<string>)GetValue(FilesProperty);
            set => SetValue(FilesProperty, value);
        }
        
        public FilesLB()
        {
            InitializeComponent();
        }
    }
}
