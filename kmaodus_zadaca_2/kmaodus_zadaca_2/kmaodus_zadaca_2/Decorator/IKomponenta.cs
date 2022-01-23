using System;
using System.Collections.Generic;

namespace kmaodus_zadaca_2.Decorator
{
    public abstract class IKomponenta
    {
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        public abstract void Prikazi();
        public abstract void Dodaj(IKomponenta child);
        public abstract void Ukloni(IKomponenta child);
        public abstract IKomponenta GetChild(int index);
        public abstract List<IKomponenta> GetChildren();
    }
}
