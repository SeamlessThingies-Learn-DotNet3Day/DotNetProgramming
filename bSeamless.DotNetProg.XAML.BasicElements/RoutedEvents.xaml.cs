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

namespace bSeamless.DotNetProg.XAML.BasicElements
{
    /// <summary>
    /// Interaction logic for RoutedEvents.xaml
    /// </summary>
    public partial class RoutedEvents : Window
    {
        public RoutedEvents()
        {
            InitializeComponent();

            grid.AddHandler(Button.ClickEvent, new RoutedEventHandler(commonClickHandler));
        }

        private void commonClickHandler(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;
            MessageBox.Show(button.Name);
        }
    }
}
