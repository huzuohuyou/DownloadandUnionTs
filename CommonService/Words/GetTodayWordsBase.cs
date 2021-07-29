using System.Collections.Generic;

namespace CommonService.Words
{
    public abstract class GetTodayWordsBase
    {
        public abstract List<string> GetTodayWords(List<string> wordsDetail);

        public abstract List<string> GetTodayWordsDetail();

        public abstract void CreateWordDir();

        public List<string> Do()
        {
            var details = GetTodayWordsDetail();
            var words = GetTodayWords(details);
            CreateWordDir();
            return words;
        }
    }
}
