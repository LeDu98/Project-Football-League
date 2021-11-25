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
        public TextBox TBNazivTima { get => txtTim; }
        public TextBox TBGrad { get => txtGrad; }
        public TextBox TBBojaKluba { get => txtBojaKluba; }
        public Label LabelPozicija { get => lblPozicija; }
        public Label LabelOdigrane { get => lblOdigraneUtakmice; }
        public Label LabelPobede { get => lblPobede; }
        public Label LabelNeresene { get => lblNeresene; }
        public Label LabelPorazi { get => lblPorazi; }
        public Label LabelBodovi { get => lblBodovi; }
        public DataGridView DataGridIgraci { get => dgIgraci; }
        public CheckBox CheckPromeni { get => checkPromeni; }
        public Button BtnPromeni { get => btnPromeni; }


        public DialogDetaljiOTimu(Kontroleri.KontrolerTimovi kontrolerTimovi, Domen.Tim tim)
        {
            InitializeComponent();
            this.kontrolerTimovi = kontrolerTimovi;
            this.tim = tim;
            
            
        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            kontrolerTimovi.PromeniPodatkeTima(tim);
            
        }

        private void checkPromeni_CheckedChanged(object sender, EventArgs e)
        {
            kontrolerTimovi.PromeniStanjeDialogaDetaljiOTimu();
        }

        private void DialogDetaljiOTimu_Load(object sender, EventArgs e)
        {
            kontrolerTimovi.InicijalizujDialogDetaljiOTimu(this, tim);
        }
    }
}
