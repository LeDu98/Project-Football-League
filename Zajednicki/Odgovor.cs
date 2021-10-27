using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{   [Serializable]
    public class Odgovor
    {
        public string Greska { get; set; }
        public bool Uspesno { get; set; }
        public List<object> Rezultat { get; set; }
    }
}
