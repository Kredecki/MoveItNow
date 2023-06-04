using MoveItNow.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace MoveItNow.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FilesModel model = new();

        public string SourcePath
        {
            get { return model.SourcePath; }
            set
            {
                if (model.SourcePath != value)
                {
                    model.SourcePath = value;
                    OnPropertyChanged(nameof(SourcePath));
                    UpdateFiles(value, SourceFiles);
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
                    UpdateFiles(value, DestinationFiles);
                }
            }
        }
        public ObservableCollection<string> DestinationFiles { get; } = new ObservableCollection<string>();

        private void UpdateFiles(string path, ObservableCollection<string> files)
        {
            files.Clear();

            if (Directory.Exists(path))
            {
                var directoryFiles = Directory.GetFiles(path);
                foreach (var file in directoryFiles)
                {
                    files.Add(file);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
