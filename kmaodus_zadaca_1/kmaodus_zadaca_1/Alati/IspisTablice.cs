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

        public IspisTablice() { }

        public void IspisiPregledLjestviceKlubovaNakonKola(List<StanjeKlubaNaLjestvici> stanjeKlubaNaLjestvici)
        {
            // Klub | Broj odigranih kola | Pobjeda | Nerijeseno | Poraz | Dani golovi | Primljeni golovi | Razlika golova | Broj bodova
            Console.WriteLine(String.Format("\n| {0, -10} | {1, -15} | {2, -10} | {3, -10} | {4} | {5} | {6} | {7} | {8} |\n", "Klub", "Broj odigranih kola", "Pobjeda", "Nerijeseno", "Poraz", "Dani golovi", "Primljeni golovi", "Razlika golova", "Broj bodova"));

            foreach (var klub in stanjeKlubaNaLjestvici)
            {
                Console.WriteLine(String.Format("| {0, -10} | {1, -15} | {2, -10} | {3, -10} | {4} | {5} | {6} | {7} | {8} |",
                    klub.Klub.Naziv, klub.BrojOdigranihKola, klub.BrojPobjeda, klub.BrojNeriješenih, klub.BrojPoraza, klub.BrojDanihGolova,
                    klub.BrojPrimljenihGolova, klub.RazlikaGolova, klub.BrojBodova));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }
        }

        public void IspisiPregledStrijelacaNakonKola(List<StanjeStrijelacaNaLjestvici> stanjeStrijelacaNaLjestvici)
        {
            // Igrač | Klub | Broj danih golova
            Console.WriteLine(String.Format("\n| {0, -50} | {1, -15} | {2, -36} |\n", "Igrač", "Klub", "Broj danih golova"));

            foreach (var strijelac in stanjeStrijelacaNaLjestvici.Where(s => s.BrojGolova > 0))
            {
                Console.WriteLine(String.Format("| {0, -50} | {1, -15} | {2, -36} |", strijelac.Igrac.ImePrezime, strijelac.Klub.Naziv, strijelac.BrojGolova));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }
        }

        public void IspisiPregledKartonaKlubovaNakonKola(List<StanjeKlubaNaLjestvici> stanjeKlubaNaLjestvici)
        {
            // Klub | Broj prvih zutih kartona | Broj drugih zutih kartona | Broj crvenih kartona | Ukupan broj kartona
            Console.WriteLine(String.Format("| {0, -57} | {1, -13} | {2, -36} | {3, -36} | {4, -36} |",
                "Klub", "Broj prvih zutih kartona", "Broj drugih zutih kartona", "Broj crvenih kartona", "Ukupan broj kartona"));

            foreach (var klub in stanjeKlubaNaLjestvici)
            {
                Console.WriteLine(String.Format("| {0, -57} | {1, -13} | {2, -36} | {3, -36} | {4, -36} |", klub.Klub.Naziv, klub.BrojZutihKartona, klub.BrojDrugihZutihKartona,
                    klub.BrojCrvenihKartona, klub.UkupanBrojKartona));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }
        }

        public void IspisiPregledRezultataUtakmicaZaKlubNakonKola(List<UtakmicaPotpuno> utakmicePotpuno)
        {
            // Broj kola | Datum i vrijeme | Klub domacin | Rezultat | Klub gost 
            //     1.    | 17.7.2021 21:00 |     Rijeka   | 2 - 0    |  Gorica 
            Console.WriteLine(String.Format("| {0, -50} | {1, 13} | {2, 36} | {3, 36} | {4, 40} |", "Broj kola", "Datum i vrijeme", "Klub domacin", "Rezultat", "Klub gost"));

            foreach (var klub in utakmicePotpuno)
            {
                StringBuilder datumVrijeme = new StringBuilder();
                datumVrijeme.Append(klub.Utakmica.Pocetak.ToString("dd.mm.yyyy HH:mm"));

                StringBuilder rezultat = new StringBuilder();
                rezultat.Append(klub.DohvatiBrojGolovaDomacina() + " - " + klub.DohvatiBrojGolovaGosta());

                Console.WriteLine(String.Format("| {0, -50} | {1, 13} | {2, 36} | {3, 36} | {4, 40} |", klub.Utakmica.Kolo, datumVrijeme, klub.KlubDomacin.Klub.Naziv, rezultat, klub.KlubGost.Klub.Naziv));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }

        }
    }
}
