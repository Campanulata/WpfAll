using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GalaSoft.MvvmLight.Command;

namespace MaterialDesignThemeDemo.ViewModels
{
    public class Page1ViewModel: ViewModelBase
    {
        public Page1ViewModel()
        {
            Scale = "1.3";
            Top = "50";
            Bottom = "50";
            BothSides = "50";
            Names = "粘贴学生姓名"+"\n"+"一行一个";
            FontNames = new List<string> { "微软雅黑", "华文楷体" };
            SaveCommand = new RelayCommand<string>(t=>Save());
        }

        public List<string> FontNames { get; set; }
        public string[] ListName { get; set; }

        private string names;

        public string Names
        {
            get { return names; }
            set { names = value; RaisePropertyChanged(); }
        }

        private string scale;

        public string Scale
        {
            get { return scale; }
            set { scale = value; RaisePropertyChanged(); }
        }
        private string imgPath;

        public string ImgPath
        {
            get { return imgPath; }
            set { imgPath = value; RaisePropertyChanged(); }
        }
        private string top;

        public string Top
        {
            get { return top; }
            set { top = value; RaisePropertyChanged(); }
        }
        private string bothSides;

        public string BothSides
        {
            get { return bothSides; }
            set { bothSides = value; RaisePropertyChanged(); }
        }
        private string bottom;

        public string Bottom
        {
            get { return bottom; }
            set { bottom = value; RaisePropertyChanged(); }
        }
        private string column;

        public string Column
        {
            get { return column; }
            set { column = value; RaisePropertyChanged(); }
        }
        private string row;

        public string Row
        {
            get { return row; }
            set { row = value; RaisePropertyChanged(); }
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
            Image image = Image.FromFile(@ImgPath);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            //文字区域宽高
            float stringHeight = image.Height - float.Parse(Top) - float.Parse(Bottom);
            float stringWidth = image.Width - 2 * float.Parse(BothSides);
            //↖️↘️
            float x1 = float.Parse(BothSides);
            float y1 = float.Parse(Top);
            //间隔
            float xSpace = stringWidth / float.Parse(Column);
            float ySpace = stringHeight / float.Parse(Row);
            ListName = Names.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < int.Parse(Row); i++)//按行打印
            {
                float y = i * ySpace + y1;//计算当前行的纵坐标

                for (int j = 0; j < int.Parse(Column); j++)
                {
                    int num = i * int.Parse(Column) + j + 1;//第n个元素
                    //计算坐标
                    float x = j * xSpace + x1;
                    Point p = new Point((int)x, (int)y);//坐标

                    if (num > ListName.Length)
                    {
                        break;
                    }
                    else
                    {
                        graphics.DrawString(ListName[num - 1], new Font(FontName, float.Parse(Scale) * 0.2f * stringHeight / int.Parse(Row), FontStyle.Bold), new SolidBrush(Color.Black), p);

                    }
                }
            }
            string output = ImgPath.Replace(@".", @"副本.");
            bitmap.Save(output);

        }
    }
}
