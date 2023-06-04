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
        void UpdateFiles(string path, ObservableCollection<string> files);
    }

    public class MainService : IMainService
    {
        public void UpdateFiles(string path, ObservableCollection<string> files)
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
    }
}
