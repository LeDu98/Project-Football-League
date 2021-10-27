using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class StatistikaIgraca
    {
        public Utakmica UtakmicaID { get; set; }
        public Igrac IgracID { get; set; }
        public int Golovi { get; set; }
    }
}
