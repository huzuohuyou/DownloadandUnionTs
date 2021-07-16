using System;
using System.Collections.Generic;
using System.Text;

namespace BeiKeToDayWords
{
    public interface ICanWashDirtyFile
    {
        void WriteOnlyWordtoFile(List<string> words);
        void WriteTranslatetoFile(List<string> trans);
    }
}
