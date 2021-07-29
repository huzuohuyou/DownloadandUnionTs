using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ThreeThreeLines.Service
{
    public class KeyLineService  :ICanGetKeyLine
    {

        public void GetKeyLine(string word)
        {
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\台词.txt"))
                {
                    #region 获取关键行

                    var result = new List<string>();
                    var lines = new List<string>();
                    string perLine = string.Empty;
                    string keyLine = string.Empty;
                    string afterLine = string.Empty;
                    var currentLine = string.Empty;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        lines.Add(currentLine);
                    }
                     keyLine = lines.ToList().FirstOrDefault(r => r.ToLower().Contains(word.ToLower()));
                    if (!string.IsNullOrWhiteSpace(keyLine))
                    {
                        var index = lines.IndexOf(keyLine);
                        //if (index - 3 >= 0)
                        //    result.Add(lines[index - 3]);
                        //if (index - 2 >= 0)
                        //    result.Add(lines[index - 2]);
                        if (index  >= 0)
                            result.Add(lines[index]);
                        if (index + 1 <= lines.Count-1)
                            result.Add(lines[index + 1]);
                        //if (index + 3 <= lines.Count - 1)
                        //    result.Add(lines[index + 3]);
                        //if (index + 4 <= lines.Count - 1)
                        //    result.Add(lines[index + 4]);
                    }
                    #endregion

                    #region 写入关键行
                    var path = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\关键台词.txt";
                    if (File.Exists(path))
                        File.Delete(path);
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (string s in result)
                        {
                            Console.WriteLine($@"Write url to file : {s}");
                            sw.WriteLine(s);
                        }
                    }
                    #endregion
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
