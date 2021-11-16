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

namespace View
{
    public partial class FrmGlavna : Form
    {
        private readonly GlavniKontroler glavniKontroler;
        public FrmGlavna(Kontroleri.GlavniKontroler glavniKontroler)
        {
            InitializeComponent();
            this.glavniKontroler = glavniKontroler;
            
        }

        internal void SetPanel(UserControl userControl)
        {
            panelGlavni.Controls.Clear();
            userControl.Parent = panelGlavni;
            userControl.Dock = DockStyle.Fill;
        }

        private void timoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavniKontroler.OtvoriUCTimovi(this);
        }

        private void tabelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavniKontroler.OtvoriUCTabela(this);
        }
    }
}
