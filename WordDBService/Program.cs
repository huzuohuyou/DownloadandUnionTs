using CommonService.Lines;
using CommonService.Words;

namespace WordDBService
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsdetails = new GetTodayWordsService().GetTodayWordsDetail();
            foreach (var item in wordsdetails)
            {
                CommonService.DB.WordDBService.AddorUpdateWord(new CommonService.DB.WORD { 
                EN=item.Split('|')[0],
                DETAIL= item.Split('|')[1],
                LINES= new GetCeanLinesService().GetCleanLins(item.Split('|')[0]),
                WORDGROUP="英语二"
                });
            }
            
   }
    }
}
