﻿using MoveItNow.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveItNow.Services
{
    public interface IMainService
    {
        void UpdateFiles(string path, ObservableCollection<FilesModel> files);
    }

    public class MainService : IMainService
    {
        public void UpdateFiles(string path, ObservableCollection<FilesModel> files)
        {
            files.Clear();

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
    }
}