using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemeDemo.Models;
using MaterialDesignThemeDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;

namespace MaterialDesignThemeDemo.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            MenuModels.Add(new MenuModel() { Icon = "ScriptText", Title="榜单制作" });
            MenuModels.Add(new MenuModel() { Icon = "MicrosoftExcel", Title="数据分析" });
            Page = new Page0();
            OpenCommand = new RelayCommand<string>(t => OpenPage(t));
        }


        public ObservableCollection<MenuModel> MenuModels { get; set; }
        
        public RelayCommand<string> OpenCommand { get; set; }

        private object page;
        public object Page
        {
            get { return page; }
            set { page = value;RaisePropertyChanged(); }
        }

        public void OpenPage(string Title)
        {
            switch (Title)
            {
                case "榜单制作":
                    Page = new Page1();
                    break;
                case "数据分析":
                    Page = new Page2();

                    break;

                default:
                    break;
            }
        }

    } 
}
