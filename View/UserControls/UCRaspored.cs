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
        private KontrolerRaspored kontrolerRaspored;

        public DataGridView DataGridUtakmice { get => dgUtakmice; }
        
        public TextBox TBPretraga { get => txtPretraga; }
        public UCRaspored(Kontroleri.KontrolerRaspored kontrolerUtakmice)
        {
            InitializeComponent();
           
            this.kontrolerRaspored = kontrolerUtakmice;
        }

        private void UCUtakmice_Load(object sender, EventArgs e)
        {
            kontrolerRaspored.InicijalizujUCRaspored(this);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            
            kontrolerRaspored.OtvoriDialogKreirajUtakmicu();
            kontrolerRaspored.InicijalizujUCRaspored(this);

        }

        

        private void dgUtakmice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kontrolerRaspored.OtvoriDialogUpdateUtakmicu();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            kontrolerRaspored.ObrisiUtakmicu();
        }

        

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            kontrolerRaspored.Filtriraj();
        }
    }
}
