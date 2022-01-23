using System.Collections.Generic;

namespace kmaodus_zadaca_2.Decorator
{
    abstract class Decorator : IKomponenta
    {
        protected const int SIRINA_TABLICE = 150;
        protected const int SIRINA_TABLICE_STRIJELACA = 125;
        protected const int SIRINA_TABLICE_REZULTATA = 101;

        protected IKomponenta komponenta;

        public Decorator(IKomponenta c)
        {
            this.komponenta = c;
        }

        public override void Prikazi()
        {
            komponenta.Prikazi();
        }
        public override void Dodaj(IKomponenta dijete)
        {
            this.komponenta.Dodaj(dijete);

        }
        public override void Ukloni(IKomponenta dijete)
        {
            this.komponenta.GetChildren().Remove(dijete);
        }

        public override IKomponenta GetChild(int index)
        {
            return this.komponenta.GetChild(index);
        }

        public override List<IKomponenta> GetChildren()
        {
            return this.komponenta.GetChildren();
        }
    }
}
