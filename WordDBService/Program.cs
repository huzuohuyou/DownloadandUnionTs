using CommonService.Lines;
using CommonService.Words;
using System;
using System.IO;

namespace WordDBService
{
    class Program
    {
        static void Main(string[] args)
        {
            //var wordsdetails = new GetTodayWordsService().GetTodayWordsDetail();
            var path = $@"D:\GitHub\DramaEnglish\DramaEnglish.WPF\Words";
            DirectoryInfo theFolder = new DirectoryInfo(path);
           var dirs= theFolder.GetDirectories();
            foreach (var item in dirs)
            {
                var detail = string.Empty;
                try
                {
                    var detailpath = $@"{path}\{item.Name}\{item.Name}.txt";
                    if (File.Exists(detailpath))
                        using (StreamReader sr = new StreamReader(detailpath))
                        {
                            detail = sr.ReadToEnd();
                        }

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("**************************"+ex.Message);
                }
                CommonService.DB.WordDBService.AddorUpdateWord(new CommonService.DB.WORD { 
                EN= item.Name,
                DETAIL= detail.Split("    ").Length>=2? detail.Split("    ")[1]:"",
                LINES= new GetCeanLinesService().GetCleanLins(item.Name),
                WORDGROUP="英语二"
                });
            }
            
   }
    }
}
