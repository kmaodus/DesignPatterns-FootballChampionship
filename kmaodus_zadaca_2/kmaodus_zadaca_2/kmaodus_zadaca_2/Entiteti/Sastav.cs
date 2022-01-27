using System.Collections.Generic;

namespace kmaodus_zadaca_2.Entiteti
{
    public class Sastav //TODO: obrisati
    {
        public Klub Klub { get; set; }

        public List<Igrac> Igraci { get; set; }

        public Sastav()
        {
            Igraci = new List<Igrac>();
        }
    }
}
