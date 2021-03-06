using kmaodus_zadaca_1.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class UtakmicaPotpuno
    {
        public Sastav KlubDomacin { get; set; } = new Sastav();
        public Sastav KlubGost { get; set; } = new Sastav();
        public Utakmica Utakmica { get; set; }
        public List<Dogadaj> Dogadaji { get; set; } = new List<Dogadaj>();

        public int KrajnjiRezultat { get; set; }

        public UtakmicaPotpuno() { }

        public int DohvatiBrojGolovaDomacina()
        {
            int ukupanBrojGolova = 0;

            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Domacin && dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_Igre || dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_KaznenogUdarca)
                {
                    ukupanBrojGolova++;
                }

                if (dogadaj.Klub == Utakmica.ID_Gost && dogadaj.Vrsta == (int)OznakeDogadaja.Autogol)
                {
                    ukupanBrojGolova++;
                }
            }
            return ukupanBrojGolova;
        }
        public int DohvatiBrojGolovaGosta()
        {
            int ukupanBrojGolova = 0;
            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Gost && dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_Igre || dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_KaznenogUdarca)
                {
                    ukupanBrojGolova++;
                }

                if (dogadaj.Klub == Utakmica.ID_Domacin && dogadaj.Vrsta == (int)OznakeDogadaja.Autogol)
                {
                    ukupanBrojGolova++;
                }
            }

            return ukupanBrojGolova;
        }
        public int DohvatiBrojPrvihZutihKartonaDomacina()
        {
            int ukupanBrojPrvihZutihKartonaDomacina = 0;
            List<string> igraciSaZutimKartonom = new List<string>();


            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Domacin && dogadaj.Vrsta == (int)OznakeDogadaja.ZutiKarton)
                {
                    if (!igraciSaZutimKartonom.Contains(dogadaj.Igrac))
                    {
                        igraciSaZutimKartonom.Add(dogadaj.Igrac);
                        ukupanBrojPrvihZutihKartonaDomacina++;
                    }
                }
            }

            return ukupanBrojPrvihZutihKartonaDomacina;
        }
        public int DohvatiBrojDrugihZutihKartonaDomacina()
        {
            int ukupanBrojDrugihZutihKartonaDomacina = 0;
            List<string> igraciSaZutimKartonom = new List<string>();


            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Domacin && dogadaj.Vrsta == (int)OznakeDogadaja.ZutiKarton)
                {
                    if (!igraciSaZutimKartonom.Contains(dogadaj.Igrac))
                    {
                        igraciSaZutimKartonom.Add(dogadaj.Igrac);
                    }
                    else
                    {
                        ukupanBrojDrugihZutihKartonaDomacina++;
                    }
                }
            }

            return ukupanBrojDrugihZutihKartonaDomacina;
        }
        public int DohvatiBrojPrvihZutihKartonaGosta()
        {
            int ukupanBrojPrvihZutihKartonaGosta = 0;
            List<string> igraciSaZutimKartonom = new List<string>();


            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Gost && dogadaj.Vrsta == (int)OznakeDogadaja.ZutiKarton)
                {
                    if (!igraciSaZutimKartonom.Contains(dogadaj.Igrac))
                    {
                        igraciSaZutimKartonom.Add(dogadaj.Igrac);
                        ukupanBrojPrvihZutihKartonaGosta++;
                    }
                }
            }

            return ukupanBrojPrvihZutihKartonaGosta;
        }
        public int DohvatiBrojDrugihZutihKartonaGosta()
        {
            int ukupanBrojDrugihZutihKartonaGosta = 0;
            List<string> igraciSaZutimKartonom = new List<string>();


            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Gost && dogadaj.Vrsta == (int)OznakeDogadaja.ZutiKarton)
                {
                    if (!igraciSaZutimKartonom.Contains(dogadaj.Igrac))
                    {
                        igraciSaZutimKartonom.Add(dogadaj.Igrac);
                    }
                    else
                    {
                        ukupanBrojDrugihZutihKartonaGosta++;
                    }
                }
            }

            return ukupanBrojDrugihZutihKartonaGosta;
        }
        public int DohvatiBrojCrvenihKartonaDomacina()
        {
            int ukupanBrojCrvenihKartonaDomacina = 0;

            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Domacin && dogadaj.Vrsta == (int)OznakeDogadaja.CrveniKarton)
                {
                    ukupanBrojCrvenihKartonaDomacina++;
                }
            }

            return ukupanBrojCrvenihKartonaDomacina;
        }
        public int DohvatiBrojCrvenihKartonaGost()
        {
            int ukupanBrojCrvenihKartonaGosta = 0;

            foreach (var dogadaj in Dogadaji)
            {
                if (dogadaj.Klub == Utakmica.ID_Gost && dogadaj.Vrsta == (int)OznakeDogadaja.CrveniKarton)
                {
                    ukupanBrojCrvenihKartonaGosta++;
                }
            }

            return ukupanBrojCrvenihKartonaGosta;
        }
    }
}

