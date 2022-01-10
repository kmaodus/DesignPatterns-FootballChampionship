using kmaodus_zadaca_2.Alati;
using kmaodus_zadaca_2.Entiteti.Enums;
using System.Collections.Generic;
using System.Linq;

namespace kmaodus_zadaca_2.Entiteti
{
    public class Prvenstvo
    {
        private static Prvenstvo _instanca;

        public List<UtakmicaPotpuno> UtakmicePotpuno { get; set; }
        public List<Klub> SviKlubovi { get; set; }
        public List<Igrac> SviIgraci { get; set; }


        private List<StanjeKlubaNaLjestvici> ListaStanjeKlubaNaLjestvici { get; set; } = new List<StanjeKlubaNaLjestvici>();
        private List<StanjeStrijelacaNaLjestvici> ListaStanjeStrijelacaNaLjestvici { get; set; } = new List<StanjeStrijelacaNaLjestvici>();
        //private List<StanjeKartonaNaLjestvici> ListaStanjaNaLjestvici { get; set; } = new List<StanjeKartonaNaLjestvici>();


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
                                    stanjeKluba.BrojPoraza++; break;
                                case 2:
                                    stanjeKluba.BrojPobjeda++; break;
                                case 0:
                                    stanjeKluba.BrojNeriješenih++; break;
                                default: break;
                            }
                        }
                    }
                }
            }
            ListaStanjeKlubaNaLjestvici = ListaStanjeKlubaNaLjestvici.OrderByDescending(x => x.BrojBodova).ThenBy(x => x.Klub.Naziv).ToList();

            // ispis tablice
            IspisTablice printer = new IspisTablice();
            printer.IspisiPregledLjestviceKlubovaNakonKola(ListaStanjeKlubaNaLjestvici);
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
                            dogadaj.Vrsta == (int)OznakeDogadaja.Gol_Iz_KaznenogUdarca)
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
            //int igraciKojiSuZabiliGol = ListaStanjeStrijelacaNaLjestvici.Where(x => x.BrojGolova > 0).Count(); //TODO

            ListaStanjeStrijelacaNaLjestvici = ListaStanjeStrijelacaNaLjestvici.OrderByDescending(x => x.BrojGolova).ThenBy(x => x.Igrac.ImePrezime).ToList();

            // ispis tablice
            IspisTablice printer = new IspisTablice();
            printer.IspisiPregledStrijelacaNakonKola(ListaStanjeStrijelacaNaLjestvici);

        }
        #endregion

        #region Pregled ljestvice kartona po klubovima nakon određenog kola prvenstva ili za odigrana kola u prvenstvu
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
                            stanjeKluba.BrojZutihKartona += utakmicaPotpuno.DohvatiBrojPrvihZutihKartonaDomacina();
                            stanjeKluba.BrojDrugihZutihKartona += utakmicaPotpuno.DohvatiBrojDrugihZutihKartonaDomacina();
                            stanjeKluba.BrojCrvenihKartona += utakmicaPotpuno.DohvatiBrojCrvenihKartonaDomacina();
                        }

                        if (stanjeKluba.Klub == utakmicaPotpuno.KlubGost.Klub)
                        {
                            stanjeKluba.BrojZutihKartona += utakmicaPotpuno.DohvatiBrojPrvihZutihKartonaGosta();
                            stanjeKluba.BrojDrugihZutihKartona += utakmicaPotpuno.DohvatiBrojDrugihZutihKartonaDomacina();
                            stanjeKluba.BrojCrvenihKartona += utakmicaPotpuno.DohvatiBrojCrvenihKartonaGost();
                        }
                    }
                }
                //int count = ListaStanjeKlubaNaLjestvici.Where(x => x.BrojZutihKartona > 0 || x.BrojCrvenihKartona > 0).Count();

            }
            ListaStanjeKlubaNaLjestvici = ListaStanjeKlubaNaLjestvici.OrderByDescending(x => x.UkupanBrojKartona).ThenBy(x => x.Klub.Naziv).ToList();

            // ispis tablice
            IspisTablice printer = new IspisTablice();
            printer.IspisiPregledKartonaKlubovaNakonKola(ListaStanjeKlubaNaLjestvici);
        }
        #endregion

        #region Pregled rezultata utakmica za klub nakon određenog kola prvenstva ili za odigrana kola u prvenstvu
        /*
          feature 4:
            Sintaksa:
                R klub [kolo] 
                R D 4
                Ispis rezultata za Dinamo nakon 4. kola prvenstva. Prikazuju se u obliku tablice
                s podacima o kolu, datum i vrijeme, klub domaćin, klub gost, rezultat.
        */

        public void PregledRezultataUtakmicaZaKlubNakonKola(string klub, int kolo)
        {
            List<UtakmicaPotpuno> utakmiceKluba = new List<UtakmicaPotpuno>();

            foreach (var utakmicaPotpuno in UtakmicePotpuno)
            {
                if (utakmicaPotpuno.Utakmica.Kolo <= kolo &&
                    (utakmicaPotpuno.Utakmica.ID_Domacin == klub ||
                    utakmicaPotpuno.Utakmica.ID_Gost == klub)) // TODO: dodati metodu za dohvat kola
                {
                    utakmiceKluba.Add(utakmicaPotpuno);
                }
            }

            // ispis tablice
            IspisTablice printer = new IspisTablice();
            printer.IspisiPregledRezultataUtakmicaZaKlubNakonKola(utakmiceKluba);
        }
        #endregion



        #region Pomoćne metode
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
                foreach (var klub in SviKlubovi)
                {
                    if (tempStrijelacNaLjestvici.Igrac.ID_Klub == klub.ID_Klub)
                    {
                        tempStrijelacNaLjestvici.Klub = klub;
                    }
                }

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

        #endregion

    }
}
