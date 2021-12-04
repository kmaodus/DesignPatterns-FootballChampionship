namespace kmaodus_zadaca_1.FactoryMethod
{
    public class PodaciLoaderFactory
    {
        public PodaciLoaderFactory()
        {

        }

        public IgracLoader DohvatiIgracLoader()
        {
            return new IgracLoader();
        }

        public KlubLoader DohvatiKlubLoader()
        {
            return new KlubLoader();
        }

        public UtakmicaLoader DohvatiUtakmiceLoader()
        {
            return new UtakmicaLoader();
        }

        public SastaviUtakmicaLoader DohvatiSastavUtakmicaLoader()
        {
            return new SastaviUtakmicaLoader();
        }

        public DogadajLoader DohvatiDogadajLoader()
        {
            return new DogadajLoader();
        }
    }
}
