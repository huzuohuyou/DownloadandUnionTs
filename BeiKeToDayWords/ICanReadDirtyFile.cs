using System;
using System.Collections.Generic;
using System.Text;

namespace BeiKeToDayWords
{
    public interface ICanReadDirtyFile
    {
        (List<string>words, List<string> trans ) GetTodayWord();
    }
}
