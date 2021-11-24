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
    public partial class UCTimovi : UserControl
    {
        private KontrolerTimovi kontrolerTimovi;
       
        public DataGridView DataGridTimovi { get => dgTimovi; }
        public TextBox TxtPretraga { get => txtPretraga; }
        
        public UCTimovi(Kontroleri.KontrolerTimovi kontrolerTimovi)
        {
            InitializeComponent();
            this.kontrolerTimovi = kontrolerTimovi;
           
        }

        private void UCTimovi_Load(object sender, EventArgs e)
        {
            kontrolerTimovi.InicijalizujUCTimovi(this);
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            kontrolerTimovi.Filtriraj();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            kontrolerTimovi.OtvoriDialogKreirajTim();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            kontrolerTimovi.ObrisiTim();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            Tim t = dgTimovi.CurrentRow.DataBoundItem as Tim;
            kontrolerTimovi.OtvoriDialogDetaljiOTimu(dgTimovi.CurrentRow.DataBoundItem as Tim);
        }
    }
}
