using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonService.Lines
{
    public class GetCeanLinesService
    {

        public string GetCleanLins(string word) {
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                DirectoryInfo theFolder = new DirectoryInfo($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\ts\");
                var files = theFolder.GetFiles();
                var CreationTime = files.ToList<FileInfo>().Max(r => r.CreationTime).ToString("yyyy-MM-dd HH:mm");
                var newestFiles = files.ToList<FileInfo>().Where(r => r.CreationTime.ToString("yyyy-MM-dd HH:mm") == CreationTime);
                var vttFile = newestFiles.FirstOrDefault(r => r.Extension == ".vtt");
                if (vttFile==null)
                {
                    return "未找到vtt文件";
                }
                using (StreamReader sr = new StreamReader(vttFile.FullName))
                {
                    #region 获取关键行
                    var lines = new List<string>();
                    var currentLine = string.Empty;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        var RegexStr = @"^\d{2,2}:\d{2,2}:\d{2,2}\.\d{2,3} -->";  //匹配字符串的开始和结束是否为0-9的数字[定位字符]
                        if (!Regex.IsMatch(currentLine, RegexStr)&&!string.IsNullOrWhiteSpace(currentLine)&& !Regex.IsMatch(currentLine, @"\d"))
                            lines.Add(currentLine);
                        if (currentLine.ToLower().Contains(word.ToLower()))
                            lines.Add($@"============================================");
                    }
                    #endregion
                    return string.Join("#", lines);
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
