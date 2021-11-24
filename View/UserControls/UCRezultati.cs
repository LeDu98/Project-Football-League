using Domen;
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
    public partial class UCRezultati : UserControl
    {
        private KontrolerRezultati kontrolerRezultati;
        public DataGridView DataGridRezultati { get => dgRezultati; }
        public UCRezultati(Kontroleri.KontrolerRezultati kontrolerRezultati)
        {
            InitializeComponent();
            this.kontrolerRezultati = kontrolerRezultati;
        }

        private void UCRezultati_Load(object sender, EventArgs e)
        {
            kontrolerRezultati.InicijalizujUCRezultate(this);
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            Rezultati rez = dgRezultati.CurrentRow.DataBoundItem as Rezultati;
            kontrolerRezultati.OtvoriDialogDetaljiOUtakmici(rez);
        }
    }
}
