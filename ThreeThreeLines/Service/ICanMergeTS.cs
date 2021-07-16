using System.Collections.Generic;

namespace DownloadandUnionTs.Service
{
    public interface ICanMergeTS
    {
        void MergeTS(List<string> ts);
    }
}
