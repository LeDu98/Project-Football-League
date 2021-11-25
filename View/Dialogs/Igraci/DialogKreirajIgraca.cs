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

namespace View.Dialogs.Igraci
{
    public partial class DialogKreirajIgraca : Form
    {
        private KontrolerIgrac kontrolerIgrac;
        public ComboBox CbPozicija { get => cmbPozicija; }
        public ComboBox CbDrzava { get => cmbDrzava; }
        public ComboBox CbTim { get => cmbTim; }
        public TextBox TxtIme { get => txtIme; }
        public TextBox TxtPrezime { get => txtPrezime; }
       
       
        public DialogKreirajIgraca(Kontroleri.KontrolerIgrac kontrolerIgrac)
        {
            InitializeComponent();
            this.kontrolerIgrac = kontrolerIgrac;
            
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            kontrolerIgrac.DodajIgraca();
        }

        private void DialogKreirajIgraca_Load(object sender, EventArgs e)
        {
            kontrolerIgrac.InicijalizujDialogKreirajIgraca(this);
        }
    }
}
