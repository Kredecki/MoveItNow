﻿using MoveItNow.Services;
using MoveItNow.ViewModels;
using System.Windows;

namespace MoveItNow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new BrowseService());
        }
    }
}
