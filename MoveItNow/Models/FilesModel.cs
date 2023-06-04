using System;
using System.Collections.ObjectModel;
using System.IO;

namespace MoveItNow.Models
{
    public class FilesModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime LastModified { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public ObservableCollection<FilesModel> SourceFiles { get; set; } = new ObservableCollection<FilesModel>();
        public ObservableCollection<FilesModel> DestinationFiles { get; set; } = new ObservableCollection<FilesModel>();
    }
}
