using DownloadandUnionTs.Service;
using ThreeThreeLines.Service;
using ThreeThreeLines.Service.Lines;

namespace DownloadandUnionTs
{
    class Program
    {
        static void Main(string[] args)
        {
            new MaikeLinesImage().MakeLineImage("stress");
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
