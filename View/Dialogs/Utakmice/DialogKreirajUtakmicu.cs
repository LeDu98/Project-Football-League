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

namespace View.Dialogs.Utakmice
{
    public partial class DialogKreirajUtakmicu : Form
    {
        private KontrolerUtakmice kontrolerUtakmice;
        public ComboBox CbDomacin { get => cmbDomacin; }
        public ComboBox CbGost { get => cmbGost; }
        public DialogKreirajUtakmicu(Kontroleri.KontrolerUtakmice kontrolerUtakmice, BindingList<Domen.Tim> listaTimova)
        {
            InitializeComponent();
            this.kontrolerUtakmice = kontrolerUtakmice;
            foreach(Tim t in listaTimova)
            {
                cmbDomacin.Items.Add(t);

            }
            foreach(Tim t2 in listaTimova)
            {
                cmbGost.Items.Add(t2);
            }
           
        }

        private void DialogKreirajUtakmicu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            kontrolerUtakmice.KreirajUtakmicu(cmbDomacin, cmbGost, dateTimePicker1);
        }
    }
}
