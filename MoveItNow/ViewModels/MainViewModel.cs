using MoveItNow.Models;
using MoveItNow.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace MoveItNow.ViewModels
{
    public class MainViewModel
    {
        private readonly IBrowseService _browseService;
        public Browse SourceBrowse { get; }
        public Browse DestinationBrowse { get; }

        public MainViewModel(IBrowseService mainService)
        {
            _browseService = mainService;
            SourceBrowse = new Browse(_browseService);
            DestinationBrowse = new Browse(_browseService);
        }
    }

    public class Browse : INotifyPropertyChanged
    {
        private readonly FilesModel model = new();

        private readonly IBrowseService _browseService;
        public Browse(IBrowseService mainService)
        {
            _browseService = mainService;
        }

        public string Path
        {
            get { return model.Path; }
            set
            {
                if (model.Path != value)
                {
                    model.Path = value;
                    OnPropertyChanged(nameof(Path));
                    _browseService.UpdateFiles(value, Files);
                }
            }
        }

        public ObservableCollection<FilesModel> Files { get; } = new ObservableCollection<FilesModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
