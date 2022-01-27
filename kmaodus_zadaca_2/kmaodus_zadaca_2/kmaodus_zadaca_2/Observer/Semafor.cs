using kmaodus_zadaca_2.Entiteti;
using kmaodus_zadaca_2.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kmaodus_zadaca_2.Observer
{
    public class Semafor : IObserver
    {
        protected const int SIRINA_TABLICE = 167;

        private string MinutaDogadaja { get; set; }
        private string KlubDomacinNaziv { get; set; }
        private string KlubGostNaziv { get; set; }

        private string KlubDomacinNazivZaIspis { get; set; }
        private string KlubGostNazivZaIspis { get; set; }

        private int GoloviDomacin { get; set; } = 0;
        private int GoloviGost { get; set; } = 0;
        private List<string> StrijelciDomacin { get; set; } = new List<string>();
        private List<string> StrijelciGost { get; set; } = new List<string>();

        public string OstaloDomacin { get; set; }
        public string OstaloGost { get; set; }


        public void Update(UtakmicaPotpuno utakmicaPotpuno, Dogadaj dogadaj)
        {
            // D kolo klub1 klub2 sekundi
            // D  2     D    H       2

            PromijeniStanjeSemafora(utakmicaPotpuno, dogadaj);
        }

        private void PromijeniStanjeSemafora(UtakmicaPotpuno utakmicaPotpuno, Dogadaj dogadaj)
        {
            MinutaDogadaja = dogadaj.Minuta;
            KlubDomacinNaziv = utakmicaPotpuno.KlubDomacin.ID_Klub;
            KlubGostNaziv = utakmicaPotpuno.KlubGost.ID_Klub;

            KlubDomacinNazivZaIspis = utakmicaPotpuno.KlubDomacin.Naziv;
            KlubGostNazivZaIspis = utakmicaPotpuno.KlubGost.Naziv;


            //logika 
            OstaloDomacin = "";
            OstaloGost = "";

            if (dogadaj.Vrsta == (int)OznakeDogadaja.PočetakUtakmice)
            {
                MinutaDogadaja = "=== POCETAK UTAKMICE ===";
            }
            else if (dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_Igre ||
                     dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_KaznenogUdarca)
            {
                if (dogadaj.Klub == KlubDomacinNaziv)
                {
                    GoloviDomacin++;
                    StrijelciDomacin.Add(dogadaj.Igrac + " " + MinutaDogadaja);
                }
                else
                {
                    GoloviGost++;
                    StrijelciGost.Add(dogadaj.Igrac + " " + MinutaDogadaja);
                }
            }
            else if (dogadaj.Vrsta == (int)OznakeDogadaja.Autogol)
            {
                if (dogadaj.Klub == KlubGostNaziv)
                {
                    GoloviDomacin++;
                    StrijelciDomacin.Add(dogadaj.Igrac + " OG" + " " + MinutaDogadaja);
                }
                else
                {
                    GoloviGost++;
                    StrijelciGost.Add(dogadaj.Igrac + " OG" + " " + MinutaDogadaja);
                }
            }
            else if (dogadaj.Vrsta == (int)OznakeDogadaja.ZutiKarton)
            {
                if (dogadaj.Klub == KlubDomacinNaziv)
                {
                    OstaloDomacin = $"Zuti karton : {dogadaj.Igrac}";
                }
                else
                {
                    OstaloGost = $"Zuti karton : {dogadaj.Igrac}";
                }
            }
            else if (dogadaj.Vrsta == (int)OznakeDogadaja.CrveniKarton)
            {
                if (dogadaj.Klub == KlubDomacinNaziv)
                {
                    OstaloDomacin = $"Crveni karton : {dogadaj.Igrac}";
                }
                else
                {
                    OstaloGost = $"Crveni karton : {dogadaj.Igrac}";
                }
            }
            else if (dogadaj.Vrsta == (int)OznakeDogadaja.ZamjenaIgraca)
            {
                if (dogadaj.Klub == KlubDomacinNaziv)
                {
                    OstaloDomacin = $"Zamjena igraca : {dogadaj.Igrac}";
                }
                else
                {
                    OstaloGost = $"Zamjena igraca : {dogadaj.Igrac}";
                }
            }
            else
            {
                MinutaDogadaja = "=== KRAJ UTAKMICE ===";
            }


            PrikaziSemafor();
        }

        public void PrikaziSemafor()
        {

            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("Minuta: " + MinutaDogadaja);

            Console.WriteLine(new string('-', SIRINA_TABLICE));
            Console.WriteLine(String.Format("| {0, -80} | {1, -80} | ", "Klub domacin", "Klub gost"));
            Console.WriteLine(String.Format("| {0, -80} | {1, -80} | ", "            ", "         "));
            Console.WriteLine(String.Format("| {0, -80} | {1, -80} | ", KlubDomacinNazivZaIspis, KlubGostNazivZaIspis));

            // https://stackoverflow.com/questions/8518761/how-to-iterate-through-two-collections-of-the-same-length-using-a-single-foreach
            var spojeniStrijelci = StrijelciDomacin.Zip(StrijelciGost, (d, g) => new { strijelacDomacin = d, strijelacGost = g });

            Console.WriteLine(String.Format("| {0, -80} | {1, -80} | ", GoloviDomacin, GoloviGost));

            using (var EnumeratorDomacini = StrijelciDomacin.GetEnumerator())
            using (var EnumeratorGosti = StrijelciGost.GetEnumerator())
            {

                while (EnumeratorDomacini.MoveNext() || EnumeratorGosti.MoveNext())
                {
                    string strijelacDomacin = "";
                    string strijelacGost = "";

                    if (EnumeratorDomacini.Current != null)
                    {
                        strijelacDomacin = EnumeratorDomacini.Current;
                    }
                    if (EnumeratorGosti.Current != null)
                    {
                        strijelacGost = EnumeratorGosti.Current;
                    }

                    Console.WriteLine(String.Format("| {0, -80} | {1, -80} | ", strijelacDomacin, strijelacGost));

                }

            }

            // prvo gol 
            //Console.WriteLine(String.Format("| {0, -35}   {1, -35}   {2, -35} |  {3, -35} {4, -35} {5, -35}  |", GoloviDomacin, tempStrijelacDomacin, OstaloDomacin, GoloviGost, tempStrijelacGost, OstaloGost));

            Console.WriteLine();
            Console.WriteLine(String.Format("| {0, -80} | {1, -80} | ", OstaloDomacin, OstaloGost));
            Console.WriteLine(new string('-', SIRINA_TABLICE));
        }
    }
}
