using System.Collections.Generic;

namespace DownloadandUnionTs.Service
{
    public abstract class Abstract33Service : ICanDownLoadTS, ICanDownLoadVTT, ICanGetTsURL, ICanMergeTS, ICanWriteURLtoFile
    {
        protected string word = "definite";
        public abstract void DownLoadTs(List<string> ts);
        public abstract void DownLoadVTT(string vtt);
        public abstract List<string> GetTsURL();
        public abstract void MergeTS(List<string> ts);

        public void Do()
        {
            var s = GetTsURL();
            WriteURLtoFile(word, s);
            //DownLoadVTT("");
            //MergeTS(s);
        }

        public abstract void WriteURLtoFile(string fileName, List<string> list);
    }
}
