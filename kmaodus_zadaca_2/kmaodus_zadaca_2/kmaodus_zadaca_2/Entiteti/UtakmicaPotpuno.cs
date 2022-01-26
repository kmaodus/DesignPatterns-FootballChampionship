using kmaodus_zadaca_2.Entiteti.Enums;
using kmaodus_zadaca_2.Observer;
using System.Collections.Generic;

namespace kmaodus_zadaca_2.Entiteti
{
    public class UtakmicaPotpuno : IObserverSubject
    {
        public Klub KlubDomacin { get; set; } = new Klub();
        public Klub KlubGost { get; set; } = new Klub();
        public Utakmica Utakmica { get; set; }
        public List<Dogadaj> Dogadaji { get; set; } = new List<Dogadaj>();

        private List<IObserver> iobservers = new List<IObserver>();

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

        public void Attach(IObserver iobserver)
        {
            iobservers.Add(iobserver);
        }

        public void Dettach(IObserver iobserver)
        {
            iobservers.Remove(iobserver);
        }

        public void Notify(Dogadaj dogadaj)
        {
            foreach (var iobserver in iobservers)
            {
                iobserver.Update(this, dogadaj);
            }
        }

        public void PrikaziLiveUtakmicu() 
        {
            foreach (var dogadaj in Dogadaji)
            {
                Notify(dogadaj);
            }
        }
    }
}
