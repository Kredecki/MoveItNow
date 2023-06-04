using System.Collections.ObjectModel;

namespace MoveItNow.Models
{
    public class FilesModel
    {
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public ObservableCollection<string> SourceFiles { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> DestinationFiles { get; set; } = new ObservableCollection<string>();
    }
}
