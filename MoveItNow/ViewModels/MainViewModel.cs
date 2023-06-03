using MoveItNow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveItNow.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FilesModel model = new();

        public string FilePath
        {
            get { return model.FilePath; }
            set
            {
                if (model.FilePath != value)
                {
                    model.FilePath = value;
                    OnPropertyChanged(nameof(FilePath));
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
