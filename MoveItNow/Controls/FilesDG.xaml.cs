﻿using MoveItNow.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MoveItNow
{
    /// <summary>
    /// Logika interakcji dla klasy FilesDG.xaml
    /// </summary>
    public partial class FilesDG : System.Windows.Controls.UserControl
    {
        public static readonly DependencyProperty FilesProperty = DependencyProperty.Register(
           "Files",
           typeof(ObservableCollection<FilesModel>),
           typeof(FilesDG),
           new PropertyMetadata(default(ObservableCollection<FilesModel>)));

        public ObservableCollection<FilesModel> Files
        {
            get => (ObservableCollection<FilesModel>)GetValue(FilesProperty);
            set => SetValue(FilesProperty, value);
        }
        
        public FilesDG()
        {
            InitializeComponent();
        }

        private void DataGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var newWidth = e.NewSize.Width / 4;

            NameColumn.Width = newWidth;
            ExtensionColumn.Width = newWidth;
            SizeColumn.Width = newWidth;
            LastModifiedColumn.Width = newWidth;
        }
    }
}
