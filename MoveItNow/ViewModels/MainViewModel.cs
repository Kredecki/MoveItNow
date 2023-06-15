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
        private readonly IMainService _mainService;
        public Browse SourceBrowse { get; }
        public Browse DestinationBrowse { get; }

        public MainViewModel(IMainService mainService)
        {
            _mainService = mainService;
            SourceBrowse = new Browse(_mainService);
            DestinationBrowse = new Browse(_mainService);
        }
    }

    public class Browse : INotifyPropertyChanged
    {
        private readonly FilesModel model = new();

        private readonly IMainService _mainService;
        public Browse(IMainService mainService)
        {
            _mainService = mainService;
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
                    _mainService.UpdateFiles(value, Files);
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
