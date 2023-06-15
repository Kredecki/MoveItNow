using MoveItNow.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveItNow.Services
{
    public interface IBrowseService
    {
        void BrowseFiles(string path, ObservableCollection<FilesModel> files);
        void BrowseDirectories(string path, ObservableCollection<FilesModel> files);
    }

    public class BrowseService : IBrowseService
    {
        public void BrowseFiles(string path, ObservableCollection<FilesModel> files)
        {
            if (Directory.Exists(path))
            {
                var directoryFiles = Directory.GetFiles(path);
                foreach (var filePath in directoryFiles)
                {
                    var fileInfo = new FileInfo(filePath);
                    var fileInformation = new FilesModel
                    {
                        Name = fileInfo.Name,
                        Extension = fileInfo.Extension,
                        Size = fileInfo.Length,
                        LastModified = fileInfo.LastWriteTime
                    };
                    files.Add(fileInformation);
                }
            }
        }

        public void BrowseDirectories(string path, ObservableCollection<FilesModel> files)
        {
            var directoryDirectories = Directory.GetDirectories(path);
            foreach (var directoryPath in directoryDirectories)
            {
                var directoryInfo = new DirectoryInfo(directoryPath);
                var directoryInformation = new FilesModel
                {
                    Name = directoryInfo.Name,
                    Extension = directoryInfo.Extension,
                    Size = directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length),
                    LastModified = directoryInfo.LastWriteTime
                };
                files.Add(directoryInformation);
            }
        }
    }
}
