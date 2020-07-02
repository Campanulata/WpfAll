using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MaterialDesignThemeDemo.ViewModels
{
    public class Page2ViewModel: ViewModelBase
    {
        public Page2ViewModel()
        {
            FontNames = new List<string> { "微软雅黑", "华文楷体" };
            SaveCommand = new RelayCommand<string>(t => Save());

        }
        public List<string> FontNames { get; set; }
        public string[] ListName { get; set; }

        private string names;

        public string Names
        {
            get { return names; }
            set { names = value; RaisePropertyChanged(); }
        }
        private string fontName;

        public string FontName
        {
            get { return fontName; }
            set { fontName = value; RaisePropertyChanged(); }
        }
        public RelayCommand<string> SaveCommand { get; set; }

        public void Save()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string ImgPath = path + @"1.png";
            Image image = Image.FromFile(@ImgPath);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);

            ListName = Names.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < 10; i++)
            {
                Point p = new Point(10, 10*i);//坐标

                graphics.DrawString(ListName[i], new Font(FontName, 1, FontStyle.Bold), new SolidBrush(Color.Black), p);
            }

            string output = ImgPath.Replace(@".", @"副本.");
            bitmap.Save(output);

        }

    }
}
