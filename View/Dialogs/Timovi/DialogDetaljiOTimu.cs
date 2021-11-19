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
using View.UserControls;

namespace View.Dialogs.Timovi
{
    public partial class DialogDetaljiOTimu : Form
    {
        private KontrolerTimovi kontrolerTimovi;
        private Tim tim;
       

        public DialogDetaljiOTimu(Kontroleri.KontrolerTimovi kontrolerTimovi, Domen.Tim tim, BindingList<Domen.Igrac> listaIgraca)
        {
            InitializeComponent();
            this.kontrolerTimovi = kontrolerTimovi;
            this.tim = tim;
            txtTim.Text = tim.NazivTima;
            txtGrad.Text = tim.Grad;
            txtBojaKluba.Text = tim.BojaKluba;
            lblPozicija.Text = tim.Pozicija.ToString();
            lblOdigraneUtakmice.Text = tim.OdigraneUtakmice.ToString();
            lblPobede.Text = tim.Pobede.ToString();
            lblNeresene.Text = tim.Neresene.ToString();
            lblPorazi.Text = tim.Porazi.ToString();
            lblBodovi.Text = tim.Bodovi.ToString();
            dgIgraci.DataSource = listaIgraca;
        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            if(txtBojaKluba.Text==tim.BojaKluba && txtGrad.Text==tim.Grad && txtTim.Text == tim.NazivTima)
            {
                MessageBox.Show("Podaci su ostali nepromenjeni!");
                return;
            }
            if (string.IsNullOrEmpty(txtTim.Text) || string.IsNullOrEmpty(txtGrad.Text) || string.IsNullOrEmpty(txtBojaKluba.Text))
            {
                MessageBox.Show("Sva polja su obavezna");
                return;
            }
                tim.NazivTima = txtTim.Text;
            tim.BojaKluba = txtBojaKluba.Text;
            tim.Grad = txtGrad.Text;
            
            kontrolerTimovi.PromeniPodatkeTima(tim);
            this.Dispose();
            
            
        }
    }
}
