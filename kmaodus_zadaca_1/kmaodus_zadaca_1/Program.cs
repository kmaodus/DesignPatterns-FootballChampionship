using kmaodus_zadaca_1.Alati;
using kmaodus_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            // args za debug
            args = new[] {
                "-v", "../../../TestneDatoteke/DZ1_dogadaji.csv",
                "-l", "../../../TestneDatoteke/DZ1_dogadaji.csv",
                "-c", "../../../TestneDatoteke/DZ1_dogadaji.csv",
                "-k", "../../../TestneDatoteke/DZ1_dogadaji.csv",
                "-o", "../../../TestneDatoteke/DZ1_dogadaji.csv",
                "-s", "../../../TestneDatoteke/DZ1_dogadaji.csv"
            };
#endif


            //Interaktivno.GetInstance().UcitajLinije();
            Console.ReadLine();
        }
    }
}
