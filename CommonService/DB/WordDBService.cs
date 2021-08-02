using SqlSugar;
using System;
using System.Collections.Generic;

namespace CommonService.DB
{
    public static class WordDBService
    {
        static SqlSugarClient db;

        static WordDBService()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = $@"DataSource=D:\GitHub\DramaEnglish\DramaEnglish.WPF\Database\wordDB.db",//连接符字串
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true
            });

            //添加Sql打印事件，开发中可以删掉这个代码
            db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql);
                };
        }


        public static int AddorUpdateWord(WORD word)
        {
            if (GetWORD(word.EN) == null)
                return AddWord(word);
            else
                return UpdateWord(word);
        }

        public static int AddWord(WORD word)
        {
            word.LASTWATCHDATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return db.Insertable(word).ExecuteCommand();
        }

        public static int UpdateWord(WORD word)
        {
            word.LASTWATCHDATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var result = db.Updateable<WORD>(word).ExecuteCommand();
            return result;
        }

        public static void WatcheWord(WORD word)
        {
            word.ISFRESH = 0;
            word.LASTWATCHDATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            UpdateWord(word);
        }

        public static void IKnowWord(WORD word)
        {
            word.ISIKONWIT = 1;
            word.LASTWATCHDATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            UpdateWord(word);
        }

        public static List<WORD> GetFreshWrod()
        {
            return db.Queryable<WORD>().Where(it => it.ISFRESH == 1).ToList();
        }

        public static WORD GetWORD(string EN)
        {
            var word = db.Queryable<WORD>().First(it => it.EN == EN);
            return word;
        }

        public static List<WORD> GetAllWORD(string EN)
        {
            return db.Queryable<WORD>().Where(r => 1 == 1).ToList();
        }

        public static List<WORD> GetIDontKnowWORD()
        {
            return db.Queryable<WORD>().Where(r => r.ISIKONWIT == 0 &&r.HAVEMP4==1).ToList();
        }

        public static WORD GetLikelyWORD(string EN)
        {
            return db.Queryable<WORD>().First(it => it.EN.Contains(EN));
        }

        public static int AllWordCount()
        {
            return db.Queryable<WORD>().Where(it => 1 == 1).Count();
        }

        public static int IKnowWordCount()
        {
            return db.Queryable<WORD>().Where(it => it.ISIKONWIT == 1).Count();

        }
    }
}
