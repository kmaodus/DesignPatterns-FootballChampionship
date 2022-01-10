using System.Collections.Generic;

namespace kmaodus_zadaca_2.Entiteti
{
    public class Sastav
    {
        public Klub Klub { get; set; }


        // provjeriti da igrac ima samo jednu poziciju u sastavu, od pozicija koje su mu ucitane
        public List<Igrac> Igraci { get; set; }

        public Sastav()
        {
            Igraci = new List<Igrac>();
        }
    }
}
