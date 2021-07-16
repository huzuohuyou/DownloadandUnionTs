using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DownloadandUnionTs.Service
{
    public class My33Service : Abstract33Service
    {
        public My33Service(string[] args)
        {
            //word = args[0];
        }
        public override void DownLoadTs(List<string> ts)
        {
            throw new NotImplementedException();
        }

        public override void DownLoadVTT(string vtt)
        {
            throw new NotImplementedException();
        }

        public override List<string> GetTsURL()
        {
            var result = new List<string>();
            var squeue = new List<int>();
            var index = 0;
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader($@"D:\考研台词\{word}\X_TS文件列表_未清理.txt"))
                {
                    string line;
                    var RegexStr = @"(?<txt>(?<=XHR ).+)";
                    // 从文件读取并显示行，直到文件的末尾 
                    while ((line = sr.ReadLine()) != null)
                    {
                        var mt = Regex.Match(line, RegexStr);
                        if (mt.Value.Length>10)
                        {
                            result.Add(mt.Value);
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

        public override void MergeTS(List<string> ts)
        {
            throw new NotImplementedException();
        }



        public override void WriteURLtoFile(string word, List<string> list)
        {
            var path = $@"D:\考研台词\{word}\Y_TS文件列表_已清理.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string s in list)
                {
                    Console.WriteLine($@"Write url to file : {s}");
                    sw.WriteLine(s);
                }
            }
        }
    }
}
