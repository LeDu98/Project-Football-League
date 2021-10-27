using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.UserControls;

namespace View.Kontroleri
{
    public class GlavniKontroler
    {
        internal void OtvoriUCTabela(FrmGlavna frmGlavna)
        {
            frmGlavna.SetPanel(new UCTabela(new KontrolerTabela()));
        }
    }
}
