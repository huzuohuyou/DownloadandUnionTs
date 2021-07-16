using System.Collections.Generic;

namespace BeiKeToDayWords
{
    public abstract class AbsService : ICanReadDirtyFile, ICanWashDirtyFile
    {
        public void Do()
        {
            var result = GetTodayWord();
            WriteOnlyWordtoFile(result.words);
            WriteTranslatetoFile(result.trans);
        }

        public abstract (List<string> words, List<string> trans) GetTodayWord();
        public abstract void WriteOnlyWordtoFile(List<string> words);
        public abstract void WriteTranslatetoFile(List<string> trans);


    }
}
