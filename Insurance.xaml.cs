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
using System.Windows.Shapes;

namespace CarSearch
{
    /// <summary>
    /// Interaction logic for Insurance.xaml
    /// </summary>
    public partial class Insurance : Window
    {
        public Insurance()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}