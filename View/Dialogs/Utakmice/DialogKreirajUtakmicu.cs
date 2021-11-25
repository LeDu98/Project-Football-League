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
        private KontrolerRaspored kontrolerRaspored;
       

        public ComboBox CbDomacin { get => cmbDomacin; }
        public ComboBox CbGost { get => cmbGost; }
        public DateTimePicker DatumIVreme { get => dateTimePicker1; }
        public DialogKreirajUtakmicu(Kontroleri.KontrolerRaspored kontrolerRaspored)
        {
            InitializeComponent();
            this.kontrolerRaspored = kontrolerRaspored;
            
        }

       

        private void DialogKreirajUtakmicu_Load(object sender, EventArgs e)
        {
            kontrolerRaspored.InicijalizujDialogKreirajUtakmicu(this);
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            kontrolerRaspored.KreirajUtakmicu();
            this.Dispose();
        }
    }
}
