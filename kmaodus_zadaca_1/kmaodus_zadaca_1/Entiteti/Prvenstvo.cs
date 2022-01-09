using kmaodus_zadaca_1.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class Prvenstvo
    {
        private static Prvenstvo _instanca;

        public List<UtakmicaPotpuno> UtakmicePotpuno { get; set; }
        public List<Klub> SviKlubovi { get; set; }
        public List<Igrac> SviIgraci { get; set; }


        private List<StanjeKlubaNaLjestvici> ListaStanjeKlubaNaLjestvici { get; set; } = new List<StanjeKlubaNaLjestvici>();
        private List<StanjeStrijelacaNaLjestvici> ListaStanjeStrijelacaNaLjestvici { get; set; } = new List<StanjeStrijelacaNaLjestvici>();
        private List<StanjeKartonaNaLjestvici> ListaStanjaNaLjestvici { get; set; } = new List<StanjeKartonaNaLjestvici>();


        private Prvenstvo(List<UtakmicaPotpuno> utakmicePotpuno, List<Klub> listaKlubova, List<Igrac> listaIgraca)
        {
            UtakmicePotpuno = utakmicePotpuno;
            SviKlubovi = listaKlubova;
            SviIgraci = listaIgraca;
        }

        public Prvenstvo() { }
        public static Prvenstvo DajInstancu(List<UtakmicaPotpuno> utakmicePotpuno, List<Klub> listaKlubova, List<Igrac> listaIgraca)
        {
            if (_instanca == null)
            {
                _instanca = new Prvenstvo(utakmicePotpuno, listaKlubova, listaIgraca);
            }
            return _instanca;
        }


        #region PregledLjestviceKlubovaNakonKola
        //              feature 1:
        //              Ispis ljestvice nakon 5.kola prvenstva.Prikazuju se u obliku tablice s podacima
        //              o klubu, broj odigranih kola, broj pobjeda, broj neriješenih, broj poraza, broj
        //              danih golova, broj primljenih golova, razlika golova, broj bodova.
        public void PregledLjestviceKlubovaNakonKola(int kolo)
        {
            ListaStanjeKlubaNaLjestvici.Clear();

            PopunjavanjeKlubovaNaStanjuLjestvice();

            foreach (var utakmicaPotpuno in UtakmicePotpuno)
            {
                if (utakmicaPotpuno.Utakmica.Kolo <= kolo) // TODO: dodati metodu za dohvat kola
                {
                    foreach (var stanjeKluba in ListaStanjeKlubaNaLjestvici)
                    {
                        if (stanjeKluba.Klub == utakmicaPotpuno.KlubDomacin.Klub)
                        {
                            stanjeKluba.BrojDanihGolova += utakmicaPotpuno.DohvatiBrojGolovaDomacina();
                            stanjeKluba.BrojPrimljenihGolova += utakmicaPotpuno.DohvatiBrojGolovaGosta();

                            int rezultat = OdrediPobjednika(utakmicaPotpuno);
                            switch (rezultat)
                            {
                                case 1:
                                    stanjeKluba.BrojPobjeda++;
                                    break;
                                case 2:
                                    stanjeKluba.BrojPoraza++;
                                    break;
                                case 0:
                                    stanjeKluba.BrojNeriješenih++;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (stanjeKluba.Klub == utakmicaPotpuno.KlubGost.Klub)
                        {
                            stanjeKluba.BrojDanihGolova += utakmicaPotpuno.DohvatiBrojGolovaGosta();
                            stanjeKluba.BrojPrimljenihGolova += utakmicaPotpuno.DohvatiBrojGolovaDomacina();

                            int rezultat = OdrediPobjednika(utakmicaPotpuno);
                            switch (rezultat)
                            {
                                case 1:
                                    stanjeKluba.BrojPoraza++;
                                    break;
                                case 2:
                                    stanjeKluba.BrojPobjeda++;
                                    break;
                                case 0:
                                    stanjeKluba.BrojNeriješenih++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private int OdrediPobjednika(UtakmicaPotpuno utakmicaPotpuno)
        {
            int rezultat;

            if (utakmicaPotpuno.DohvatiBrojGolovaDomacina() > utakmicaPotpuno.DohvatiBrojGolovaGosta())
            {
                rezultat = 1;
            }
            else if (utakmicaPotpuno.DohvatiBrojGolovaDomacina() < utakmicaPotpuno.DohvatiBrojGolovaGosta())
            {
                rezultat = 2;
            }
            else
            {
                rezultat = 0;
            }

            return rezultat;
        }
        #endregion

        #region PregledStrijelacaNakonKola

        //              feature 2:
        //              Pregled ljestvice strijelaca nakon određenog kola prvenstva ili za sva odigrana kola u prvenstvu
        //              S3 - Ispis ljestvice strijelaca nakon 3. kola prvenstva. Prikazuju se u obliku tablice s
        //              podacima o broju golova, igraču, klubu kojem pripada igrač.

        public void PregledStrijelacaNakonKola(int kolo)
        {
            ListaStanjeStrijelacaNaLjestvici.Clear();
            PopunjavanjeStrijelacaNaLjestvici();

            foreach (var utakmicaPotpuno in UtakmicePotpuno)
            {
                if (utakmicaPotpuno.Utakmica.Kolo <= kolo)
                {
                    foreach (var dogadaj in utakmicaPotpuno.Dogadaji)
                    {
                        if (dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_Igre || 
                            dogadaj.Vrsta== (int)OznakeDogadaja.Gol_Iz_KaznenogUdarca )
                        {
                            foreach (var strijelac in ListaStanjeStrijelacaNaLjestvici)
                            {
                                if (dogadaj.Igrac == strijelac.Igrac.ImePrezime)
                                {
                                    strijelac.BrojGolova++;
                                }
                            }
                        }
                    }
                }
            }

            int igraciKojiSuZabiliGol = ListaStanjeStrijelacaNaLjestvici.Where(x => x.BrojGolova > 0).Count(); //TODO
        }
        #endregion

        #region PregledKartonaKlubovaNakonKola

        //              feature 3:
        //              K2 - Ispis ljestvice kartona po klubovima nakon 2. kola prvenstva. Prikazuju se u
        //              obliku tablice s podacima o klubu, broju žutih kartona, broju drugih žutih
        //              karton, broju crvenih kartona, ukupan broj kartona.
        public void PregledKartonaKlubovaNakonKola(int kolo)
        {
            ListaStanjeKlubaNaLjestvici.Clear();

            PopunjavanjeKlubovaNaStanjuLjestvice();

            foreach (var utakmicaPotpuno in UtakmicePotpuno)
            {
                if (utakmicaPotpuno.Utakmica.Kolo <= kolo) // TODO: dodati metodu za dohvat kola
                {
                    foreach (var stanjeKluba in ListaStanjeKlubaNaLjestvici)
                    {
                        if (stanjeKluba.Klub == utakmicaPotpuno.KlubDomacin.Klub)
                        {
                            //stanjeKluba.BrojDanihGolova += utakmicaPotpuno.DohvatiBrojGolovaDomacina();
                            //stanjeKluba.BrojPrimljenihGolova += utakmicaPotpuno.DohvatiBrojGolovaGosta();
                            stanjeKluba.BrojZutihKartona += utakmicaPotpuno.DohvatiBrojPrvihZutihKartonaDomacina();
                            stanjeKluba.BrojDrugihZutihKartona += utakmicaPotpuno.DohvatiBrojDrugihZutihKartonaDomacina();
                            stanjeKluba.BrojCrvenihKartona += utakmicaPotpuno.DohvatiBrojCrvenihKartonaDomacina();

                        }

                        if (stanjeKluba.Klub == utakmicaPotpuno.KlubGost.Klub)
                        {
                            //stanjeKluba.BrojDanihGolova += utakmicaPotpuno.DohvatiBrojGolovaGosta();
                            //stanjeKluba.BrojPrimljenihGolova += utakmicaPotpuno.DohvatiBrojGolovaDomacina();
                            stanjeKluba.BrojZutihKartona += utakmicaPotpuno.DohvatiBrojPrvihZutihKartonaGosta();
                            stanjeKluba.BrojDrugihZutihKartona += utakmicaPotpuno.DohvatiBrojDrugihZutihKartonaDomacina();
                            stanjeKluba.BrojCrvenihKartona += utakmicaPotpuno.DohvatiBrojCrvenihKartonaGost();

                        }
                    }
                }
                int count = ListaStanjeKlubaNaLjestvici.Where(x => x.BrojZutihKartona > 0 || x.BrojCrvenihKartona > 0).Count();

            }
        }
        #endregion




        private void PopunjavanjeKlubovaNaStanjuLjestvice()
        {
            foreach (var klub in SviKlubovi)
            {
                StanjeKlubaNaLjestvici tempStanjeKlubaNaLjestvici = new StanjeKlubaNaLjestvici();
                tempStanjeKlubaNaLjestvici.Klub = klub;

                ListaStanjeKlubaNaLjestvici.Add(tempStanjeKlubaNaLjestvici);
            }
        }

        private void PopunjavanjeStrijelacaNaLjestvici()
        {
            foreach (var strijelac in SviIgraci)
            {
                StanjeStrijelacaNaLjestvici tempStrijelacNaLjestvici = new StanjeStrijelacaNaLjestvici();
                tempStrijelacNaLjestvici.Igrac = strijelac;

                ListaStanjeStrijelacaNaLjestvici.Add(tempStrijelacNaLjestvici);
            }
        }

        //metoda za brisanje strijelaca
        //public void ObrisiStrijelcaIzListe(){}


        //TODO: metoda za dohvat lista
        //public List<StanjeKlubaNaLjestvici> DohvatiStanjeKlubovaNakonKola(List<Klub> listaKlubova)
        //{
        //    List<StanjeKlubaNaLjestvici> stanjeKlubovaNaLjestvici;

        //    foreach (var klub in listaKlubova)
        //    {
        //        StanjeKlubaNaLjestvici stanjeKlubaNaLjestvici = new StanjeKlubaNaLjestvici();

        //        foreach (var utakmica in UtakmicePotpuno)
        //        {
        //            if (utakmica.KlubDomacin == klub || utakmica.KlubGost == klub)
        //            {
        //                // utakmicaPotpuno - iz nje sve


        //            }
        //        }
        //    }
        //}
    }
}
