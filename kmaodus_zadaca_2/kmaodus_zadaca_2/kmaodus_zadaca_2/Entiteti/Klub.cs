using System.Collections.Generic;

namespace kmaodus_zadaca_2.Entiteti
{
    public class Klub
    {
        //Composite - izbaciti Sastav


        public string ID_Klub { get; set; }
        public string Naziv { get; set; }
        public Trener Trener { get; set; }
        public List<Igrac> Igraci { get; set; }

        public Klub(string idKlub, string naziv, string trener)
        {
            ID_Klub = idKlub;
            Naziv = naziv;
            Trener = new Trener(trener);
            Igraci = new List<Igrac>();
        }


        public Klub() { }
    }
}
