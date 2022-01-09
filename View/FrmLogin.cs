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

namespace View
{
    public partial class FrmLogin : Form
    {
        private KontrolerPrijavljivanje kontrolerPrijavljivanje;

       

        public FrmLogin(Kontroleri.KontrolerPrijavljivanje kontrolerPrijavljivanje)
        {
            InitializeComponent();
            this.kontrolerPrijavljivanje = kontrolerPrijavljivanje;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                kontrolerPrijavljivanje.KonektujSe();
                kontrolerPrijavljivanje.InicijalizujFrmLogin(this);
                kontrolerPrijavljivanje.Prijavljivanje(txtKorisnickoIme, txtLozinka);
                
            }
            catch (Exception)
            {

                MessageBox.Show("Greska pri povezivanju sa serverom");
                Application.ExitThread();
                Application.Exit();
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
