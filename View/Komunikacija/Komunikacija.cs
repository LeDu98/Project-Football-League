using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicki;

namespace View.Komunikacija
{
    public class Komunikacija
    {
        private static Komunikacija instance;
        private Socket soket;
        private KomunikacijaKlijent klijent;

        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }

        

        private Komunikacija()
        {
            
            soket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

        }

        public void KonektujSe()
        {
            if(soket!=null && !soket.Connected)
            {
                soket.Connect("127.0.0.1", 9100);
                klijent = new KomunikacijaKlijent(soket);
            }
        }


        internal List<object> VratiListu(Operacije operacije)
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = operacije,
            };
            
            klijent.PosaljiZahtev(zahtev);
            return klijent.PrimiOdgovor().Rezultat;
        }

        internal List<object> Pretrazi(Operacije operacije, object obj)
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = operacije,
                Objekat=obj
            };

            klijent.PosaljiZahtev(zahtev);
            return klijent.PrimiOdgovor().Rezultat;
        }

        internal object Kreiraj(Operacije operacije, Object obj, List<object> list=null)
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = operacije,
                Objekat = obj,
                ListaObjekata = list
            };
            klijent.PosaljiZahtev(zahtev);
            return klijent.PrimiOdgovor().Rezultat[0];
        }

        internal bool Obrisi(Operacije operacije, Object obj)
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = operacije,
                Objekat = obj
            };
            klijent.PosaljiZahtev(zahtev);
            return klijent.PrimiOdgovor().Uspesno;
        }

        internal bool Update(Operacije operacije, Object obj)
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = operacije,
                Objekat = obj
            };
            klijent.PosaljiZahtev(zahtev);
            return klijent.PrimiOdgovor().Uspesno;
        }
        internal List<Object> VratiObjekat(Operacije operacije, Object obj)
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = operacije,
                Objekat = obj
            };
            klijent.PosaljiZahtev(zahtev);
            return klijent.PrimiOdgovor().Rezultat;
        }
    }
}
