using kmaodus_zadaca_2.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_2.Observer
{
    public interface IObserver
    {
        void Update(UtakmicaPotpuno utakmicaPotpuno, Dogadaj dogadaj);
    }
}
