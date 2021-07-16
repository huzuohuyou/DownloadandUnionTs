using DownloadandUnionTs.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace DownloadandUnionTs
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args != null && args.Length > 0)
            //{
                new My33Service(args).Do();
            //}
        }

       
    }
}
