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
    public partial class UCRaspored : UserControl
    {
        private KontrolerRaspored kontrolerRezultati;
        
        public DataGridView DataGridUtakmice { get => dgUtakmice; }
        public UCRaspored(Kontroleri.KontrolerRaspored kontrolerUtakmice)
        {
            InitializeComponent();
           
            this.kontrolerRezultati = kontrolerUtakmice;
        }

        private void UCUtakmice_Load(object sender, EventArgs e)
        {
            kontrolerRezultati.InicijalizujUCRaspored(this);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            
            kontrolerRezultati.OtvoriDialogKreirajUtakmicu();
            kontrolerRezultati.InicijalizujUCRaspored(this);

        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            
            kontrolerRezultati.OtvoriDialogUpdateUtakmicu();
        }

        private void dgUtakmice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kontrolerRezultati.OtvoriDialogUpdateUtakmicu();

        }
    }
}
