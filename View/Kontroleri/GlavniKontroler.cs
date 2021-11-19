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

        internal void OtvoriUCTimovi(FrmGlavna frmGlavna)
        {
            frmGlavna.SetPanel(new UCTimovi(new KontrolerTimovi(), new KontrolerIgrac()));
        }

        internal void OtvoriUCIgraci(FrmGlavna frmGlavna)
        {
            frmGlavna.SetPanel(new UCIgraci(new KontrolerIgrac()));
        }

        internal void OtvoriUCUtakmice(FrmGlavna frmGlavna)
        {
            frmGlavna.SetPanel(new UCUtakmice(new KontrolerUtakmice(),new KontrolerIgrac(),new KontrolerTimovi()));
        }
    }
}
