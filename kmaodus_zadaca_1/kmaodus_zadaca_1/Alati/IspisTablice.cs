using kmaodus_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kmaodus_zadaca_1.Alati
{
    public class IspisTablice
    {
        protected const int SIRINA_TABLICE = 150;
        protected const int SIRINA_TABLICE_STRIJELACA = 125;
        protected const int SIRINA_TABLICE_REZULTATA = 101;

        public IspisTablice() { }

        public void IspisiPregledLjestviceKlubovaNakonKola(List<StanjeKlubaNaLjestvici> stanjeKlubaNaLjestvici)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', SIRINA_TABLICE));
            // Klub | Broj odigranih kola | Pobjeda | Nerijeseno | Poraz | Dani golovi | Primljeni golovi | Razlika golova | Broj bodova
            Console.WriteLine(String.Format("| {0, -20} | {1, -15} | {2, -8} | {3, -8} | {4, -5} | {5, -8} | {6, -10} | {7, -10} | {8, -19} |\n", "Klub", "Broj odigranih kola", "Pobjeda", "Nerijeseno", "Poraz", "Dani golovi", "Primljeni golovi", "Razlika golova", "Broj bodova"));
            Console.WriteLine(new string('-', SIRINA_TABLICE));

            foreach (var klub in stanjeKlubaNaLjestvici)
            {
                Console.WriteLine(String.Format("| {0, -20} | {1, -19} | {2, -8} | {3, -10} | {4, -5} | {5, -11} | {6, -16} | {7, -14} | {8, -19} |",
                    klub.Klub.Naziv, klub.BrojOdigranihKola, klub.BrojPobjeda, klub.BrojNeriješenih, klub.BrojPoraza, klub.BrojDanihGolova,
                    klub.BrojPrimljenihGolova, klub.RazlikaGolova, klub.BrojBodova));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }
        }

        public void IspisiPregledStrijelacaNakonKola(List<StanjeStrijelacaNaLjestvici> stanjeStrijelacaNaLjestvici)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));

            // Igrač | Klub | Broj danih golova
            Console.WriteLine(String.Format("| {0, -50} | {1, -40} | {2, -25} |\n", "Igrač", "Klub", "Broj danih golova"));
            Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));

            foreach (var strijelac in stanjeStrijelacaNaLjestvici.Where(s => s.BrojGolova > 0))
            {
                Console.WriteLine(String.Format("| {0, -50} | {1, -40} | {2, -25} |", strijelac.Igrac.ImePrezime, strijelac.Klub.Naziv, strijelac.BrojGolova));
                Console.WriteLine(new string('-', SIRINA_TABLICE_STRIJELACA));
            }
        }

        public void IspisiPregledKartonaKlubovaNakonKola(List<StanjeKlubaNaLjestvici> stanjeKlubaNaLjestvici)
        {
            Console.WriteLine(new string('-', SIRINA_TABLICE));
            // Klub | Broj prvih zutih kartona | Broj drugih zutih kartona | Broj crvenih kartona | Ukupan broj kartona
            Console.WriteLine(String.Format("| {0, -35} | {1, -15} | {2, -28} | {3, -28} | {4, -19} |",
                "Klub", "Broj prvih zutih kartona", "Broj drugih zutih kartona", "Broj crvenih kartona", "Ukupan broj kartona"));
            Console.WriteLine(new string('-', SIRINA_TABLICE));

            foreach (var klub in stanjeKlubaNaLjestvici)
            {
                Console.WriteLine(String.Format("| {0, -35} | {1, -24} | {2, -28} | {3, -28} | {4, -19} |", klub.Klub.Naziv, klub.BrojZutihKartona, klub.BrojDrugihZutihKartona,
                    klub.BrojCrvenihKartona, klub.UkupanBrojKartona));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }
        }

        public void IspisiPregledRezultataUtakmicaZaKlubNakonKola(List<UtakmicaPotpuno> utakmicePotpuno)
        {
            Console.WriteLine();

            // Broj kola | Datum i vrijeme | Klub domacin | Rezultat | Klub gost 
            //     1.    | 17.7.2021 21:00 |     Rijeka   | 2 - 0    |  Gorica 
            Console.WriteLine(String.Format("| {0, -10} | {1, 20} | {2, 20} | {3, 15} | {4, 20} |", "Broj kola", "Datum i vrijeme", "Klub domacin", "Rezultat", "Klub gost"));
            //Zapisnik.Ispis(Zapisnik.OBAVIJEST, String.Format("\n| {0, -10} | {1, 20} | {2, 20} | {3, 15} | {4, 20} |", "Broj kola", "Datum i vrijeme", "Klub domacin", "Rezultat", "Klub gost"));

            foreach (var klub in utakmicePotpuno)
            {
                StringBuilder datumVrijeme = new StringBuilder();
                datumVrijeme.Append(klub.Utakmica.Pocetak.ToString("dd.mm.yyyy HH:mm"));

                StringBuilder rezultat = new StringBuilder();
                rezultat.Append(klub.DohvatiBrojGolovaDomacina() + " - " + klub.DohvatiBrojGolovaGosta());

                Console.WriteLine(String.Format("| {0, -10} | {1, 20} | {2, 20} | {3, 15} | {4, 20} |", klub.Utakmica.Kolo, datumVrijeme, klub.KlubDomacin.Klub.Naziv, rezultat, klub.KlubGost.Klub.Naziv));
                Console.WriteLine(new string('-', SIRINA_TABLICE_REZULTATA));
            }

        }
    }
}
