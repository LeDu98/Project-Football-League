using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class Tim
    {
        public int TimID { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public string BojaKluba { get; set; }
        public List<Igrac> ListaIgraca { get; set; }
    }
}
