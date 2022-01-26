using System.Collections.Generic;

namespace kmaodus_zadaca_2.Entiteti
{
    public class Klub
    {
        //Composite - izbaciti Sastav


        public string ID_Klub { get; set; }
        public string Naziv { get; set; }
        private Trener Trener { get; set; }
        private List<Igrac> Igraci { get; set; }

        public Klub(string idKlub, string naziv, string trener)
        {
            ID_Klub = idKlub;
            Naziv = naziv;
            Trener = new Trener(trener);
            Igraci = new List<Igrac>();
        }


        public Klub() { }


        public void DodajIgraca(Igrac igrac) { }
        public void UkloniIgraca(Igrac igrac) { }
        public List<Igrac> DohvatiIgrace()
        {
            return Igraci;
        }


        public void DodajTrenera(Trener trener) { }
        public void UkloniTrenera(Trener trener) { }
        public Trener DohvatiTrenera()
        {
            if (Trener != null)
            {
                return Trener;
            }
            else
            {
                return new Trener("nedodijeljen");
            }
        }

    }
}
