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
    public partial class UCUtakmice : UserControl
    {
        private KontrolerUtakmice kontrolerUtakmice;
        private KontrolerTimovi kontrolerTimovi;
        private KontrolerIgrac kontrolerIgrac;
        public DataGridView DataGridUtakmice { get => dgUtakmice; }
        public UCUtakmice(Kontroleri.KontrolerUtakmice kontrolerUtakmice, KontrolerIgrac kontrolerIgrac, KontrolerTimovi kontrolerTimovi)
        {
            InitializeComponent();
            this.kontrolerIgrac = kontrolerIgrac;
            this.kontrolerTimovi = kontrolerTimovi;
            this.kontrolerUtakmice = kontrolerUtakmice;
        }

        private void UCUtakmice_Load(object sender, EventArgs e)
        {
            kontrolerUtakmice.InicijalizujUCUtakmice(this);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            BindingList<Tim> listaTimova = kontrolerTimovi.VratiTimove();
            kontrolerUtakmice.OtvoriDialogKreirajUtakmicu(listaTimova);
        }
    }
}
