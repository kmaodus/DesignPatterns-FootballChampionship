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


            var igrac = new Igrac();
            igrac.Pozicija.Add("B");

            var igrac2 = new Igrac();
            igrac2.Pozicija.Add("B");
            igrac2.Pozicija.Add("DB");


            Console.WriteLine(igrac.Pozicija.First().ToString());

            foreach (var pozicija in igrac2.Pozicija)
            {
                Console.WriteLine(pozicija);
            }

            Console.ReadLine();
        }
    }
}
