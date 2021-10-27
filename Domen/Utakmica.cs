using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class Utakmica
    {
        public int UtakmicaID { get; set; }
        public DateTime DatumIVremeOdigravanja { get; set; }
        public int DomacinGolovi { get; set; }
        public int GostGolovi { get; set; }
        public Tim DomacinID { get; set; }
        public Tim GostID { get; set; }
    }
}
