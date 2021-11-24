using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Helpers;
using View.Kontroleri;

namespace View.UserControls
{
    public partial class UCTabela : UserControl
    {
        private KontrolerTabela kontrolerTabela;
        public DataGridView DataGridTabela { get => dgTabela; }
        
        public UCTabela(Kontroleri.KontrolerTabela kontrolerTabela)
        {
            InitializeComponent();
            this.kontrolerTabela = kontrolerTabela;
            
        }

        private void UCTabela_Load(object sender, EventArgs e)
        {
            kontrolerTabela.InicijalizujUCTabela(this);
        }
    }
}
