using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GalaSoft.MvvmLight.Command;

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
        public string[] ListScore { get; set; }
        private string scores;

        public string Scores
        {
            get { return scores; }
            set { scores = value; RaisePropertyChanged(); }
        }

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
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string ImgPath = path + @"1.png";
            Image image = Image.FromFile(@ImgPath);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);

            ListName = Names.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            ListScore = Scores.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < 10; i++)
            {
                Point p = new Point(330, 720+100*i);//坐标
                graphics.DrawString(ListName[i], new Font(FontName, 30, FontStyle.Bold), new SolidBrush(Color.Black), p);
            }
            for (int i = 0; i < 10; i++)
            {
                Point p = new Point(530, 720 + 100 * i);//坐标
                graphics.DrawString(ListScore[i], new Font(FontName, 30, FontStyle.Bold), new SolidBrush(Color.Black), p);
            }
            string output = ImgPath.Replace(@"1.", @"1副本.");
            bitmap.Save(output);

        }

    }
}
