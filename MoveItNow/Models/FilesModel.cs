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
        public string Path { get; set; }
    }
}
