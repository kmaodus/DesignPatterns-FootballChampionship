using System.Collections.Generic;

namespace kmaodus_zadaca_1.FactoryMethod
{
    abstract class PodaciLoaderBase<T>
    {
        protected List<T> _podaci;
        public List<T> Podaci => _podaci;
        public string NazivDatoteke { get; set; }


        protected PodaciLoaderBase(string datoteka)
        {
            NazivDatoteke = datoteka;
            UcitajPodatke<T>();
        }

        public abstract void UcitajPodatke<TP>();
        public abstract T IzdvojiPodatak(string izvornaDatoteka);

    }
}
