using MoveItNow.Models;
using MoveItNow.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace MoveItNow.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FilesModel model = new();
        private readonly MainService _mainService = new();

        public string SourcePath
        {
            get { return model.SourcePath; }
            set
            {
                if (model.SourcePath != value)
                {
                    model.SourcePath = value;
                    OnPropertyChanged(nameof(SourcePath));
                    _mainService.UpdateFiles(value, SourceFiles);
                }
            }
        }
        public ObservableCollection<string> SourceFiles { get; } = new ObservableCollection<string>();

        public string DestinationPath
        {
            get { return model.DestinationPath; }
            set
            {
                if (model.DestinationPath != value)
                {
                    model.DestinationPath = value;
                    OnPropertyChanged(nameof(DestinationPath));
                    _mainService.UpdateFiles(value, DestinationFiles);
                }
            }
        }
        public ObservableCollection<string> DestinationFiles { get; } = new ObservableCollection<string>();
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
