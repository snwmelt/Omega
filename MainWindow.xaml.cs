﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Omega
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitButtonCommand(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aboutButtonCommand(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This Program was design By Otis Daley", "About Omega");
        }

        private void newbuttonCommand(object sender, RoutedEventArgs e)
        {

            newEntry fileNewWindow = new newEntry();
            fileNewWindow.ShowDialog();

        }
    }
}
