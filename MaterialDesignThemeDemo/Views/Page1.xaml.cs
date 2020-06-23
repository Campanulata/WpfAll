using MaterialDesignThemeDemo.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialDesignThemeDemo.Views
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : UserControl
    {
        public Page1()
        {
            InitializeComponent();
            DataContext = new Page1ViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var f = new OpenFileDialog();
            f.ShowDialog();
            string path = f.FileName;
            TextImgPath.Text = @path;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
