using System.Collections.Generic;

namespace DownloadandUnionTs.Service
{
    public interface ICanWriteURLtoFile
    {
        void WriteURLtoFile(string fileName,List<string> list);
    }
}
