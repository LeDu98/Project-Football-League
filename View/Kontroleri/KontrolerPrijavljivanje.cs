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
           foreach(AdministratorLige al in administratoriLige)
            {
                if(al.KorisnickoIme==txtKorisnickoIme.Text && al.Lozinka == txtLozinka.Text)
                {
                    GlavniKoordinator.Instance.administratorLige = al;
                    MessageBox.Show("Dobro dosli: " + al.ToString());
                    GlavniKoordinator.Instance.OtvoriGlavnuFormu();
                    return;

                }
            }
            MessageBox.Show("Pogresno ime i/ili lozinka");
            return;
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
            UcitajAdministratoreLige();
        }

        private void UcitajAdministratoreLige()
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
        }
    }
}
