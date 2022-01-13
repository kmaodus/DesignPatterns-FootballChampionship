using kmaodus_zadaca_2.Entiteti;
using kmaodus_zadaca_2.Singleton;
using System.Linq;

namespace kmaodus_zadaca_2.Builder
{
    public class UtakmicaPotpunoBuilder
    {
        public UtakmicaPotpunoBuilder() { }

        public UtakmicaPotpuno KreirajUtakmicaPotpuno(BazaPodataka bazaPodataka, int brojUtakmice)
        {
            UtakmicaPotpuno utakmicaPotpuno = new UtakmicaPotpuno();
            utakmicaPotpuno.Utakmica = bazaPodataka.Utakmice.Where(x => x.Broj == brojUtakmice).FirstOrDefault();

            Klub sastavDomacin = new Klub();
            Klub sastavGost = new Klub();

            sastavDomacin = bazaPodataka.Klubovi.Where(x => x.ID_Klub == utakmicaPotpuno.Utakmica.ID_Domacin).FirstOrDefault();
            sastavGost = bazaPodataka.Klubovi.Where(x => x.ID_Klub == utakmicaPotpuno.Utakmica.ID_Gost).FirstOrDefault();

            utakmicaPotpuno.KlubDomacin = sastavDomacin;
            utakmicaPotpuno.KlubGost = sastavGost;

            foreach (var zapis in bazaPodataka.SastaviUtakmica)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubDomacin.ID_Klub)
                {
                    sastavDomacin.Igraci.Add(bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac).FirstOrDefault());
                }
            }

            foreach (var zapis in bazaPodataka.SastaviUtakmica)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubGost.ID_Klub)
                {
                    sastavGost.Igraci.Add(bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac).FirstOrDefault());
                }
            }

            // dogadaji
            foreach (var zapis in bazaPodataka.Dogadaji)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj)
                {
                    utakmicaPotpuno.Dogadaji.Add(zapis);
                }
            }

            return utakmicaPotpuno;
        }


        //metoda za postavljanje - bez dupliciranja koda
        //public KreirajSastavKluba(BazaPodataka bazaPodataka, Sastav sastavKluba)
        //{
        //    foreach (var zapis in bazaPodataka.SastaviUtakmica)
        //    {
        //        if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubDomacin.Klub.ID_Klub)
        //        {
        //            sastavKluba.Igraci.Add((Igrac)bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac));
        //        }
        //    }
        //}

    }
}
