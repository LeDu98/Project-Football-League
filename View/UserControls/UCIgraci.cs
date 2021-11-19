using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Kontroleri;

namespace View.UserControls
{
    public partial class UCIgraci : UserControl
    {
        private KontrolerIgrac kontrolerIgrac;
        public DataGridView DataGridIgraci { get => dgIgraci; }
        public UCIgraci(KontrolerIgrac kontrolerIgrac)
        {
            InitializeComponent();
            this.kontrolerIgrac = kontrolerIgrac;
        }

        private void UCIgraci_Load(object sender, EventArgs e)
        {
            kontrolerIgrac.InicijalizujUCIgrac(this);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            kontrolerIgrac.OtvoriDialogKreirajIgraca();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            kontrolerIgrac.ObrisiIgraca();
        }
    }
}
