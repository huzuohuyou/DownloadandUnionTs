using SqlSugar;
using System;
using System.Text;

namespace CommonService.DB
{
    public class WORD
    {
        public WORD() { }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string EN { get; set; }
        public int ISWATCHED { get; set; } = 0;
        public int ISIKONWIT { get; set; } = 0;
        public string DETAIL { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string DETAIL2
        {
            get
            {
                return $@"{EN}   {DETAIL}";
            }
        }
        public int ISFRESH { get; set; } = 1;


        public string LINES { get; set; } = "#";

        [SugarColumn(IsIgnore = true)]
        public string LINES2 { get {
                var sb = new StringBuilder();
                foreach (var item in LINES.Split("#"))
                {
                    sb.Append(
                        $@"{item}
");
                }
                return sb.ToString() ;
            } }
        public string WORDGROUP { get; set; } = "英语二";
        public string CREATEDATE { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string LASTWATCHDATE { get; set; }
    }
}
