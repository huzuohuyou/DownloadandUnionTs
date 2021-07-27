using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BeiKeTodyWords
{
    public class BeiKeTodayWordsService : ICanGetTodayWord
    {
        public void GetTodayWord()
        {
            var result = new List<string>();
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\A_贝壳今日单词_未过滤.txt"))
                {
                    string line;
                    var en = @"^\w+$";
                    var fy = @"^[n|adj|v|pron|adv|num|art|prep|conj|interj].+[\u4E00-\u9FA5]+$";
                    // 从文件读取并显示行，直到文件的末尾 
                    var item = new StringBuilder(); ;
                    while ((line = sr.ReadLine()) != null)
                    {

                        if (Regex.IsMatch(line, en))
                        {
                            item.Clear();
                            var mt = Regex.Match(line, en);
                            item.Append(mt.Value);
                        }

                        if (Regex.IsMatch(line, fy))
                        {
                            var mt = Regex.Match(line, fy);
                            item.Append($@"|{mt.Value}");
                            result.Add(item.ToString());
                        }

                    }
                }
                var onlyWordPaht= @"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\B_贝壳今日单词_纯单词.txt";
                if (File.Exists(onlyWordPaht))
                    File.Delete(onlyWordPaht);
                using (StreamWriter sw = new StreamWriter(onlyWordPaht))
                {
                    foreach (string s in result)
                    {
                        Console.WriteLine($@"Write url to file : {s}");
                        sw.WriteLine(s.Split('|')[0]);
                    }
                }
                foreach (var item in result)
                {
                    var word = item.Split('|')[0];
                    var dir = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\";
                    var path = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\{word}.txt";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    //if (!File.Exists(path))
                    //    File.Create(path);
                    
                    using (StreamWriter sw = new StreamWriter(path))
                    {

                        Console.WriteLine(item);
                        sw.WriteLine($@"{word}    {item.Split('|')[1]}" );

                    }
                }

            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
