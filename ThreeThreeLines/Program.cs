using DownloadandUnionTs.Service;
using ThreeThreeLines.Service;

namespace DownloadandUnionTs
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var word =  args[0];
                if (word.StartsWith("#"))
                {
                    new KeyLineService().GetKeyLine(word.Remove(0,1));
                }
                else
                {
                    new My33Service(args).Do();
                }
            }
            

        }

       
    }
}
