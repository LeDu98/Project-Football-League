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

namespace View.Dialogs.Igraci
{
    public partial class DialogDetaljiOIgracu : Form
    {
        private KontrolerIgrac kontrolerIgrac;
        private Igrac igrac;

      

        public TextBox TBIme { get => txtIme; }
        public TextBox TBPrezime { get => txtPrezime; }
        public ComboBox CBPozicija { get => cmbPozicija; }
        public ComboBox CBDrzava { get => cmbDrzava; }
        public ComboBox CBTim { get => cmbTim; }
        public Label LabelGolovi { get => lblGolovi; }
        public CheckBox CheckIzmeni { get => checkIzmeni; }
        public Button BtnIzmeni { get => btnIzmeni; }
        

        public DialogDetaljiOIgracu(Kontroleri.KontrolerIgrac kontrolerIgrac, Domen.Igrac i)
        {
            InitializeComponent();
            this.kontrolerIgrac = kontrolerIgrac;
            this.igrac = i;
            
        }

        

        private void checkIzmeni_CheckedChanged(object sender, EventArgs e)
        {
            kontrolerIgrac.PromeniStanjeDialogaDetaljiOIgracu();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            kontrolerIgrac.PromeniPodatkeIgraca(igrac);
        }

        private void DialogDetaljiOIgracu_Load(object sender, EventArgs e)
        {
            kontrolerIgrac.InicijalizujDialogDetaljiOIgracu(this, igrac);
        }
    }
}
