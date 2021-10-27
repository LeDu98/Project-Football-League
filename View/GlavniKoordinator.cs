using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Kontroleri;

namespace View
{
    public class GlavniKoordinator
    {
        private GlavniKontroler glavniKontroler = new GlavniKontroler();
        private KontrolerPrijavljivanje kontrolerPrijavljivanje = new KontrolerPrijavljivanje();
        private FrmGlavna frmGlavna;
        private FrmLogin frmLogin;

        
        public AdministratorLige administratorLige { get; set; }
        
        private static GlavniKoordinator instance;
        private GlavniKoordinator() { }
        public static GlavniKoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlavniKoordinator();

                }
                return instance;
            }
        }

        public void OtvoriFormuZaPrijavljivanje()
        {
            frmLogin = new FrmLogin(kontrolerPrijavljivanje);
            frmLogin.Show();
        }
        public void OtvoriGlavnuFormu()
        {
            frmGlavna = new FrmGlavna(glavniKontroler);
            frmLogin.Visible = false;
            frmGlavna.ShowDialog();
            frmLogin.Dispose();
        }
    }
}
