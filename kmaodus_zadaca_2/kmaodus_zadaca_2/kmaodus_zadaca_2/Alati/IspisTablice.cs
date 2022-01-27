using kmaodus_zadaca_2.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kmaodus_zadaca_2.Alati
{
    public class IspisTablice
    {
        protected const int SIRINA_TABLICE = 181;
        protected const int SIRINA_TABLICE_LJESTVICE = 173;
        protected const int SIRINA_TABLICE_STRIJELACA = 157;
        protected const int SIRINA_TABLICE_REZULTATA = 101;

        public IspisTablice() { }

        public void IspisiPregledLjestviceKlubovaNakonKola(List<StanjeKlubaNaLjestvici> stanjeKlubaNaLjestvici)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', SIRINA_TABLICE_LJESTVICE));
            // Klub | Broj odigranih kola | Pobjeda | Nerijeseno | Poraz | Dani golovi | Primljeni golovi | Razlika golova | Broj bodova
            Console.WriteLine(String.Format("| {0, -20} | {1, -20} | {2, -15} | {3, -8} | {4, -8} | {5, -5} | {6, -8} | {7, -10} | {8, -10} | {9, -19} |\n", "Klub", "Trener", "Broj odigranih kola", "Pobjeda", "Nerijeseno", "Poraz", "Dani golovi", "Primljeni golovi", "Razlika golova", "Broj bodova"));
            Console.WriteLine(new string('-', SIRINA_TABLICE_LJESTVICE));

            foreach (var klub in stanjeKlubaNaLjestvici)
            {
                Console.WriteLine(String.Format("| {0, -20} | {1, -19} |  {2, -19} | {3, -8} | {4, -10} | {5, -5} | {6, -11} | {7, -16} | {8, -14} | {9, -19} |",
                    klub.Klub.Naziv, klub.Klub.DohvatiTrenera().ImePrezime, klub.BrojOdigranihKola, klub.BrojPobjeda, klub.BrojNeriješenih, klub.BrojPoraza, klub.BrojDanihGolova,
                    klub.BrojPrimljenihGolova, klub.RazlikaGolova, klub.BrojBodova));
                Console.WriteLine(new string('-', SIRINA_TABLICE_LJESTVICE));
            }
            //stanjeKlubaNaLjestvici.Select(x => x.BrojPobjeda).Sum();

            Console.WriteLine(new string('-', SIRINA_TABLICE_LJESTVICE));
            Console.WriteLine(String.Format("| {0, -26}  {1, -20}  {2, -15} | {3, -8} | {4, -10} | {5, -5} | {6, -11} | {7, -16} | {8, -14} | {9, -19} |\n", "SUM:", "", "", stanjeKlubaNaLjestvici.Select(x => x.BrojPobjeda).Sum(), stanjeKlubaNaLjestvici.Select(x => x.BrojNeriješenih).Sum(),
                stanjeKlubaNaLjestvici.Select(x => x.BrojPoraza).Sum(), stanjeKlubaNaLjestvici.Select(x => x.BrojDanihGolova).Sum(), stanjeKlubaNaLjestvici.Select(x => x.BrojPrimljenihGolova).Sum(), stanjeKlubaNaLjestvici.Select(x => x.RazlikaGolova).Sum(), stanjeKlubaNaLjestvici.Select(x => x.BrojBodova).Sum()));
            Console.WriteLine(new string('-', SIRINA_TABLICE_LJESTVICE));
        }

        public void IspisiPregledStrijelacaNakonKola(List<StanjeStrijelacaNaLjestvici> stanjeStrijelacaNaLjestvici)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));

            // Igrač | Klub | Broj danih golova
            Console.WriteLine(String.Format("| {0, -50} | {1, -40} | {2, -25} | {3, -29} |\n", "Igrač", "Klub", "Broj danih golova", "Trener"));
            Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));

            foreach (var strijelac in stanjeStrijelacaNaLjestvici.Where(s => s.BrojGolova > 0))
            {
                Console.WriteLine(String.Format("| {0, -50} | {1, -40} | {2, -25} | {3, -29} |", strijelac.Igrac.ImePrezime, strijelac.Klub.Naziv, strijelac.BrojGolova, strijelac.Klub.DohvatiTrenera().ImePrezime));
                Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));
            }

            Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));
            Console.WriteLine(String.Format("| {0, -50} | {1, -40} | {2, -25} | {3, -29} |\n", "SUM:", "", stanjeStrijelacaNaLjestvici.Where(s => s.BrojGolova > 0).Select(x => x.BrojGolova).Sum(), ""));
            Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));
        }

        public void IspisiPregledKartonaKlubovaNakonKola(List<StanjeKlubaNaLjestvici> stanjeKlubaNaLjestvici)
        {
            Console.WriteLine(new string('-', SIRINA_TABLICE));
            // Klub | Broj prvih zutih kartona | Broj drugih zutih kartona | Broj crvenih kartona | Ukupan broj kartona
            Console.WriteLine(String.Format("| {0, -35} | {1, -15} | {2, -28} | {3, -28} | {4, -19} | {5, -28} |",
                "Klub", "Broj prvih zutih kartona", "Broj drugih zutih kartona", "Broj crvenih kartona", "Ukupan broj kartona", "Trener"));
            Console.WriteLine(new string('-', SIRINA_TABLICE));

            foreach (var klub in stanjeKlubaNaLjestvici)
            {
                Console.WriteLine(String.Format("| {0, -35} | {1, 24} | {2, 28} | {3, 28} | {4, 19} | {5, -28} |", klub.Klub.Naziv, klub.BrojZutihKartona, klub.BrojDrugihZutihKartona,
                    klub.BrojCrvenihKartona, klub.UkupanBrojKartona, klub.Klub.DohvatiTrenera().ImePrezime));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }

            Console.WriteLine(new string('-', SIRINA_TABLICE));
            Console.WriteLine(String.Format("| {0, -35} | {1, 24} | {2, 28} | {3, 28} | {4, 19} | {5, -28} |", " SUM:   ", stanjeKlubaNaLjestvici.Select(x => x.BrojZutihKartona).Sum(), stanjeKlubaNaLjestvici.Select(x => x.BrojDrugihZutihKartona).Sum(),
                   stanjeKlubaNaLjestvici.Select(x => x.BrojCrvenihKartona).Sum(), stanjeKlubaNaLjestvici.Select(x => x.UkupanBrojKartona).Sum(), ""));
            Console.WriteLine(new string('-', SIRINA_TABLICE));

        }

        public void IspisiPregledRezultataUtakmicaZaKlubNakonKola(List<UtakmicaPotpuno> utakmicePotpuno)
        {
            // Broj kola | Datum i vrijeme | Klub domacin | Rezultat | Klub gost 
            //     1.    | 17.7.2021 21:00 |     Rijeka   | 2 - 0    |  Gorica 
            Console.WriteLine(String.Format("| {0, -10} | {1, 20} | {2, -20} | {3, 15} | {4, -20} |", "Broj kola", "Datum i vrijeme", "Klub domacin", "Rezultat", "Klub gost"));
            //Zapisnik.Ispis(Zapisnik.OBAVIJEST, String.Format("\n| {0, -10} | {1, -20} | {2, -20} | {3, -15} | {4, -20} |", "Broj kola", "Datum i vrijeme", "Klub domacin", "Rezultat", "Klub gost"));

            foreach (var klub in utakmicePotpuno)
            {
                StringBuilder datumVrijeme = new StringBuilder();
                datumVrijeme.Append(klub.Utakmica.Pocetak.ToString("dd.mm.yyyy HH:mm"));

                StringBuilder rezultat = new StringBuilder();
                rezultat.Append(klub.DohvatiBrojGolovaDomacina() + " - " + klub.DohvatiBrojGolovaGosta());

                Console.WriteLine(String.Format("| {0, 10} | {1, 20} | {2, -20} | {3, 15} | {4, -20} |", klub.Utakmica.Kolo, datumVrijeme, klub.KlubDomacin.Naziv, rezultat, klub.KlubGost.Naziv));
                Console.WriteLine(new string('-', SIRINA_TABLICE_REZULTATA));
            }
        }


    }
}
