using kmaodus_zadaca_2.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_2.Decorator
{
    class PregledLjestviceDecorator : Decorator
    {
        public PregledLjestviceDecorator(IKomponenta c) : base(c) { }

        public override void Prikazi()
        {
            //if (this.komponenta.GetType() == typeof(StanjeKlubaNaLjestvici))
            //{
            //    StanjeKlubaNaLjestvici t = (StanjeKlubaNaLjestvici)komponenta;
            //}

            base.Prikazi();
        }

    }
}
