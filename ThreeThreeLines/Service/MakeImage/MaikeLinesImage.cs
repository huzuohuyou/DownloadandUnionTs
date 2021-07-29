using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ThreeThreeLines.Service.Lines
{
    class MaikeLinesImage : ICanMakeLineImage
    {

        public void MakeLineImage(string word)
        {
            string path = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{ word}\{ word}.png";
            string text =
$@"{GetWordDetail(word)}
   {GetWordKeyLine(word)}"; ;    //将获取到的字符串赋值到text字符串中
            Bitmap bmp = new Bitmap(200, 20);      //定义画布大小
            Graphics g = Graphics.FromImage(bmp);      //封装一个GDI+绘图图面
            Random r = new Random();
            g.Clear(ColorTranslator.FromHtml("#1D1D1F"));  //背景色为白色

            g.DrawString(
                text.ToString()
                , new Font("微软雅黑", 12)
                , new SolidBrush(ColorTranslator.FromHtml("#F5F5F7"))
                , new Point(5, 5));//画图

            var strFullName = path;  //存储位置+图片名
            bmp.Save(strFullName, ImageFormat.Png);

        }

        private string GetWordKeyLine(string word)
        {
            var path = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{ word}\关键台词.txt";
            try
            {
                if (File.Exists(path))
                {
                    // 创建一个 StreamReader 的实例来读取文件 
                    // using 语句也能关闭 StreamReader
                    using (StreamReader sr = new StreamReader(path))
                    {
                        var detail = sr.ReadToEnd();
                        return detail;
                    }
                }

            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return "";
        }

        private string GetWordDetail(string word)
        {
            var path = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{ word}\{word}.txt";
            try
            {
                if (File.Exists(path))
                {
                    // 创建一个 StreamReader 的实例来读取文件 
                    // using 语句也能关闭 StreamReader
                    using (StreamReader sr = new StreamReader(path))
                    {
                        var detail = sr.ReadToEnd();
                        return detail;
                    }
                }

            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}
