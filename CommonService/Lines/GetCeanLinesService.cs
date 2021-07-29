using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CommonService.Lines
{
    public class GetCeanLinesService
    {

        public string GetCleanLins(string word) {
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader($@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words\{word}\台词.txt"))
                {
                    #region 获取关键行
                    var lines = new List<string>();
                    var currentLine = string.Empty;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        var RegexStr = $@"^\d.*\d$";  //匹配字符串的开始和结束是否为0-9的数字[定位字符]
                        if (!Regex.IsMatch(currentLine, RegexStr))
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
