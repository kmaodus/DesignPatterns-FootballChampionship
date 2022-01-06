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
        private List<StanjeKlubaNaLjestvici> ListaStanjeKlubaNaLjestvici { get; set; }
        private List<StanjeStrijelacaNaLjestvici> ListaStanjeStrijelacaNaLjestvici { get; set; }
        private List<StanjeKartonaNaLjestvici> ListaStanjaNaLjestvici { get; set; }
        public List<Klub> SviKlubovi { get; set; }



        private Prvenstvo(List<UtakmicaPotpuno> utakmicePotpuno, List<Klub> listaKlubova)
        {
            UtakmicePotpuno = utakmicePotpuno;
            SviKlubovi = listaKlubova;
        }

        public Prvenstvo() { }

        public static Prvenstvo DajInstancu()
        {
            if (_instanca == null)
            {
                _instanca = new Prvenstvo();
            }
            return _instanca;
        }

        //              feature 1:
        //              Ispis ljestvice nakon 5.kola prvenstva.Prikazuju se u obliku tablice s podacima
        //              o klubu, broj odigranih kola, broj pobjeda, broj neriješenih, broj poraza, broj
        //              danih golova, broj primljenih golova, razlika golova, broj bodova.
        public List<StanjeKlubaNaLjestvici> PregledLjestviceKlubovaNakonKola(int kolo, List<Klub> lista)
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
            return null;
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


        //              feature 2:
        //              Pregled ljestvice strijelaca nakon određenog kola prvenstva ili za sva odigrana kola u prvenstvu
        //              S3 - Ispis ljestvice strijelaca nakon 3. kola prvenstva. Prikazuju se u obliku tablice s
        //              podacima o broju golova, igraču, klubu kojem pripada igrač.



        //              feature 3:
        //              K2 - Ispis ljestvice kartona po klubovima nakon 2. kola prvenstva. Prikazuju se u
        //              obliku tablice s podacima o klubu, broju žutih kartona, broju drugih žutih
        //              karton, broju crvenih kartona, ukupan broj kartona.
        public List<StanjeKlubaNaLjestvici> PregledKartonaKlubovaNakonKola(int kolo, List<Klub> lista)
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
                            stanjeKluba.BrojZutihKartona += utakmicaPotpuno.DohvatiBrojPrvihZutihKartonaDomacina();
                            stanjeKluba.BrojDrugihZutihKartona += utakmicaPotpuno.DohvatiBrojDrugihZutihKartonaDomacina();
                            stanjeKluba.BrojCrvenihKartona += utakmicaPotpuno.DohvatiBrojCrvenihKartonaDomacina();

                        }

                        if (stanjeKluba.Klub == utakmicaPotpuno.KlubGost.Klub)
                        {
                            stanjeKluba.BrojDanihGolova += utakmicaPotpuno.DohvatiBrojGolovaGosta();
                            stanjeKluba.BrojPrimljenihGolova += utakmicaPotpuno.DohvatiBrojGolovaDomacina();
                            stanjeKluba.BrojZutihKartona += utakmicaPotpuno.DohvatiBrojDrugihZutihKartonaGosta();
                            stanjeKluba.BrojDrugihZutihKartona += utakmicaPotpuno.DohvatiBrojDrugihZutihKartonaDomacina();
                            stanjeKluba.BrojCrvenihKartona += utakmicaPotpuno.DohvatiBrojCrvenihKartonaGost();

                        }
                    }
                }
            }
            return null;
        }




        private void PopunjavanjeKlubovaNaStanjuLjestvice()
        {
            foreach (var klub in SviKlubovi)
            {
                StanjeKlubaNaLjestvici tempStanjeKlubaNaLjestvici = new StanjeKlubaNaLjestvici();
                tempStanjeKlubaNaLjestvici.Klub = klub;

                ListaStanjeKlubaNaLjestvici.Add(tempStanjeKlubaNaLjestvici);
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
