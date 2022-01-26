using kmaodus_zadaca_2.Entiteti;
using kmaodus_zadaca_2.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_2.Observer
{
    public class Semafor : IObserver
    {
        private string MinutaDogadaja { get; set; }
        private string KlubDomacinNaziv { get; set; }
        private string KlubGostNaziv { get; set; }

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
            KlubDomacinNaziv = utakmicaPotpuno.KlubDomacin.Naziv;
            KlubGostNaziv = utakmicaPotpuno.KlubGost.Naziv;



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
            // D kolo klub1 klub2 sekundi
            // D  2     D    H       2
            Console.WriteLine(MinutaDogadaja);
            Console.WriteLine();
            Console.WriteLine($"Domacin: {KlubDomacinNaziv}");
            Console.WriteLine($"Gost: {KlubGostNaziv}");


            // Broj kola | Datum i vrijeme | Klub domacin | Rezultat | Klub gost 
            //     1.    | 17.7.2021 21:00 |     Rijeka   | 2 - 0    |  Gorica 
            Console.WriteLine(String.Format("| {0, -80} | {1, -80} | ", "Klub domacin", "Klub gost"));

            // https://stackoverflow.com/questions/8518761/how-to-iterate-through-two-collections-of-the-same-length-using-a-single-foreach
            var spojeniStrijelci = StrijelciDomacin.Zip(StrijelciGost, (d, g) => new { strijelacDomacin = d, strijelacGost = g });

            foreach (var zapis in spojeniStrijelci)
            {
                var tempStrijelacDomacin = "";
                var tempStrijelacGost = "";

                if (zapis.strijelacDomacin != null)
                {
                    tempStrijelacDomacin = zapis.strijelacDomacin;
                }

                if (zapis.strijelacGost != null)
                {
                    tempStrijelacGost = zapis.strijelacGost;
                }

                Console.WriteLine(String.Format("| {0, -35}   {1, -35}  | {2, -35}   {3, -35}  |", GoloviDomacin, tempStrijelacDomacin, GoloviGost, tempStrijelacGost));
            }
        }
    }
}
