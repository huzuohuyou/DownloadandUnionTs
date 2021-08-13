using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonService.Words
{
    public class GetTodayWordsService : GetTodayWordsBase
    {
        public override List<string> GetTodayWordsDetail()
        {
            var result = new List<string>();
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(@"D:\Gitee\DramaEnglishMedia\Words\A_贝壳今日单词_未过滤.txt"))
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
                

            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public override List<string> GetTodayWords(List<string> wordsDetail)
        {
            var result = new List<string>();
            try
            {
                var onlyWordPaht = @"D:\Gitee\DramaEnglishMedia\Words\B_贝壳今日单词_纯单词.txt";
                if (File.Exists(onlyWordPaht))
                    File.Delete(onlyWordPaht);
                using (StreamWriter sw = new StreamWriter(onlyWordPaht))
                {
                    foreach (string s in wordsDetail)
                    {
                        Console.WriteLine($@"Write url to file : {s}");
                        var word = s.Split('|')[0];
                        sw.WriteLine(word);
                        result.Add(word);
                    }
                }
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);
            }
            return result;

        }

        public override void CreateWordDir()
        {
            var wordsdetail = GetTodayWordsDetail();
            try
            {
                foreach (var item in wordsdetail)
                {
                    var word = item.Split('|')[0];
                    var dir = $@"D:\Gitee\DramaEnglishMedia\Words\{word}\";
                    var path = $@"D:\Gitee\DramaEnglishMedia\Words\{word}\{word}.txt";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    if (!File.Exists(path)) {
                        using (StreamWriter sw = new StreamWriter(path))
                        {

                            Console.WriteLine(item);
                            sw.WriteLine($@"{word}    {item.Split('|')[1]}");

                        }
                    }
                       
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);
            }
    }

       
    }
}
