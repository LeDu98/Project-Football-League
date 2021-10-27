using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Helpers;

namespace View.Kontroleri
{
    public class KontrolerPrijavljivanje
    {
        internal void KonektujSe()
        {
            Komunikacija.Komunikacija.Instance.KonektujSe();
        }

        internal void Prijavljivanje(TextBox txtKorisnickoIme,TextBox txtLozinka,FrmLogin frmLogin)
        {
            if(!FormeHelpers.TextFieldValidator(new TextBox[] { txtKorisnickoIme, txtLozinka }))
            {
                MessageBox.Show("Sva polja su obavezna.");
                return;
            }

            try
            {
                AdministratorLige administratorLige = Komunikacija.Komunikacija.Instance.Prijavljivanje(txtLozinka, txtKorisnickoIme);
                if (administratorLige == null)
                {
                    MessageBox.Show("Pogresno ime i/ili lozinka");
                    return;
                }
                GlavniKoordinator.Instance.administratorLige = administratorLige;
                MessageBox.Show("Dobro dosli: " + administratorLige.ToString());
                GlavniKoordinator.Instance.OtvoriGlavnuFormu();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        internal void Prijavljivanje(object txtKorisnickoIme, object txtLozinka, FrmLogin frmLogin)
        {
            throw new NotImplementedException();
        }
    }
}
