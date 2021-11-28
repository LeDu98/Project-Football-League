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
        public TextBox TxtPretraga { get => txtPretraga; }
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

        private void dgIgraci_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kontrolerIgrac.OtvoriDialogDetaljiOIgracu();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            kontrolerIgrac.OtvoriDialogDetaljiOIgracu();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            kontrolerIgrac.Filtriraj();
        }

        
    }
}
