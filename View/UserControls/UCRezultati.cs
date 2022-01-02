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
        public TextBox TBPretraga { get => txtPretraga; }
        public UCRezultati(Kontroleri.KontrolerRezultati kontrolerRezultati)
        {
            InitializeComponent();
            this.kontrolerRezultati = kontrolerRezultati;
        }

        private void UCRezultati_Load(object sender, EventArgs e)
        {
            kontrolerRezultati.InicijalizujUCRezultate(this);
        }


        private void dgRezultati_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kontrolerRezultati.OtvoriDialogDetaljiOUtakmici();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            kontrolerRezultati.ObrisiUtakmicu();

        }

       

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            kontrolerRezultati.Filtriraj();
        }
    }
}
