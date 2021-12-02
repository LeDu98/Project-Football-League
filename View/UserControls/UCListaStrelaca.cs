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
    public partial class UCListaStrelaca : UserControl
    {
        private KontrolerListaStrelaca kontrolerListaStrelaca;
        
        public DataGridView DataGridListaStrelaca { get => dgListaStrelaca; }

        public UCListaStrelaca(KontrolerListaStrelaca kontrolerListaStrelaca)
        {
            InitializeComponent();
            this.kontrolerListaStrelaca = kontrolerListaStrelaca;
            
        }

        

        private void UCListaStrelaca_Load(object sender, EventArgs e)
        {
            kontrolerListaStrelaca.InicijalizujUCListaStrelaca(this);
        }

        
    }
}
