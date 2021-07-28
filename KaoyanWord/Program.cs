using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KaoyanWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                var result =new List<string>();
                var words = new List<Word>();
                using (StreamReader sr = new StreamReader($@"D:\GitHub\DownloadandUnionTs\KaoyanWord\KaoYan_2.json"))
                {
                    var line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var word = JsonConvert.DeserializeObject<Word>( line);
                        words.Add(word);
                        result.Add(word.ToString());
                        Console.Write(word.ToString());
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
                        sw.WriteLine($@"{word}    {item.Split('|')[1]}");

                    }
                }
                var onlyWordPaht = @"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\B_贝壳今日单词_纯单词.txt";
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

            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        class Word
        {
            public string wordRank { get; set; }
            public string headWord { get; set; }
            public Content1 content { get; set; }

            public override string ToString()
            {
                var trans = new StringBuilder(); ;
                foreach (var item in content.word.content.trans)
                {
                    trans.Append($@"{item.pos} {item.tranCn};");
                }
                return $@"{headWord}|{trans.ToString()}";
            }
        }

        class Content1
        {

            public Word2 word { get; set; }
        }
        class Word2 {
            public Content2 content { get; set; }
        }

        class Content2
        {
            public Tran[] trans { get; set; }

        }

        class Tran
        {
            public string tranCn { get; set; }
            public string pos { get; set; }
        }
    }
}
