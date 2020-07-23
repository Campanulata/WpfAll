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
            Times = "1";
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
        private string times;

        public string Times
        {
            get { return times; }
            set { times = value; RaisePropertyChanged(); }
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
            string ImgPath2 = path + @"2.png";
            Image image = Image.FromFile(@ImgPath);
            Image image2 = Image.FromFile(@ImgPath2);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            Bitmap bitmap2 = new Bitmap(image2.Width, image2.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Graphics graphics2 = Graphics.FromImage(bitmap2);
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            graphics2.DrawImage(image2, 0, 0, image2.Width, image2.Height);

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
            //2
            for (int i = 0; i < 3; i++)
            {
                Point p = new Point(200, 370 + 80 * i);//坐标
                graphics2.DrawString(ListName[i], new Font(FontName, 30, FontStyle.Bold), new SolidBrush(Color.Black), p);
            }
            for (int i = 3; i < 8; i++)
            {
                Point p = new Point(200, 430 + 55 * i);//坐标
                graphics2.DrawString(ListName[i], new Font(FontName, 30, FontStyle.Bold), new SolidBrush(Color.Black), p);
            }
            for (int i = 0; i < 3; i++)
            {
                Point p = new Point(380, 370 + 80 * i);//坐标
                graphics2.DrawString(ListScore[i], new Font(FontName, 30, FontStyle.Bold), new SolidBrush(Color.Black), p);
            }
            for (int i = 3; i < 8; i++)
            {
                Point p = new Point(380, 430 + 55 * i);//坐标
                graphics2.DrawString(ListScore[i], new Font(FontName, 30, FontStyle.Bold), new SolidBrush(Color.Black), p);
            }

            graphics2.DrawString("第"+ Times+"节课", new Font(FontName, 30, FontStyle.Bold), new SolidBrush(Color.Black), new Point(240, 230));
            string output2 = ImgPath2.Replace(@"2.", @"2"+ "第" + Times + "节课"+"副本.");
            bitmap2.Save(output2);

        }

    }
}
