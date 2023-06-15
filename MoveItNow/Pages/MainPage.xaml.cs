using MoveItNow.Services;
using MoveItNow.ViewModels;
using System.Windows.Controls;

namespace MoveItNow
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new MainService());
        }
    }
}
