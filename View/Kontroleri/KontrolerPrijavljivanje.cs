using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Helpers;

namespace View.Kontroleri
{
    public class KontrolerPrijavljivanje
    {
        public BindingList<AdministratorLige> administratoriLige;
        public FrmLogin frmLogin;
        internal void KonektujSe()
        {
            Komunikacija.Komunikacija.Instance.KonektujSe();
        }

        internal void Prijavljivanje(TextBox txtKorisnickoIme, TextBox txtLozinka)
        {
            if (!FormeHelpers.TextFieldValidator(new TextBox[] { txtKorisnickoIme, txtLozinka }))
            {
                MessageBox.Show("Sva polja su obavezna.");
                return;
            }
            AdministratorLige al = new AdministratorLige();
            al.KorisnickoIme = txtKorisnickoIme.Text;
            al.Lozinka = txtLozinka.Text;
            al = (AdministratorLige)Komunikacija.Komunikacija.Instance.VratiObjekat(Zajednicki.Operacije.Prijavljivanje, (object)al)[0];
            if (al.AdministratorLigeID == 0)
            {
                MessageBox.Show("Pogresno ime i/ili lozinka");
                return;
            }
            
            GlavniKoordinator.Instance.administratorLige = al;
            MessageBox.Show("Dobro dosli: " + al.ToString());
            GlavniKoordinator.Instance.OtvoriGlavnuFormu();
            
     
            
        }

        /*internal void Prijavljivanje(TextBox txtKorisnickoIme,TextBox txtLozinka)
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
        }*/

        internal void InicijalizujFrmLogin(FrmLogin frmLogin)
        {
            this.frmLogin = frmLogin;
            
        }

        /*private void UcitajAdministratoreLige()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuAdministratoraLige);
            administratoriLige = new BindingList<AdministratorLige>();
            if (lista == null)
            {
                return;
            }
            foreach (object o in lista)
            {
                administratoriLige.Add((AdministratorLige)o);
            }
        }*/
    }
}
