using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
   [Serializable]
   public enum Operacije
    {
        Prijavljivanje,
        VratiTabelu,
        VratiListuTimova,
        KreirajTim,
        ObrisiTim,
        VratiListuIgraca,
        VratiListuDrzava,
        KreirajIgraca,
        ObrisiIgraca,
        IzmeniTim,
        VratiListuUtakmica,
        KreirajUtakmicu,
        IzmeniUtakmicu,
        KreirajStatistikeIgraca,
        IzmeniIgraca,
        VratiListuRezultata,
        VratiListuStatistikaIgraca
    }
}
