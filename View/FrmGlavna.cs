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
           
            glavniKontroler.OtvoriUCGlavna(this);
            
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

       

        private void igraciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavniKontroler.OtvoriUCIgraci(this);
        }

        

        private void rezultatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavniKontroler.OtvoriUCRezultati(this);
        }

        private void rasporedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavniKontroler.OtvoriUCUtakmice(this);
        }

        private void listaStrelacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            glavniKontroler.OtvoriUCListaStrelaca(this);
        }

        private void tabelaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            glavniKontroler.OtvoriUCTabela(this);
        }

        private void FrmGlavna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
