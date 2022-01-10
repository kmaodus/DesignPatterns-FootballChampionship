using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kmaodus_zadaca_2.Alati
{
    public class ParserArgumenata
    {
        // primjer unosa -i DZ_1_igraci.csv -s DZ_1_sastavi_utakmica.csv -u DZ_1_utakmice.csv -k DZ_1_klubovi.csv -d DZ_1_dogadaji.csv

        public static string DohvatiArgument(IEnumerable<string> args, string opcija)
            => args.SkipWhile(i => i != opcija).Skip(1).Take(1).FirstOrDefault();

        public static bool ProvjeriArgumente(string[] args)
        {
            bool ispravan = true;
            string[] zastavice = { "-i", "-k", "-u", "-s", "-d" };

            foreach (string zastavica in zastavice)
            {
                if (string.IsNullOrEmpty(DohvatiArgument(args, zastavica)))
                {
                    ispravan = false;
                }
                else
                {
                    string datoteka = DohvatiArgument(args, zastavica);

                    if (!File.Exists(datoteka))
                    {
                        Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
                        Zapisnik.Ispis(Zapisnik.GRESKA, $"[GRESKA] Nije moguce pronaci datoteku --> {datoteka}");
                        Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
                        ispravan = false;
                    }
                }
            }

            return ispravan;
        }
    }
}
