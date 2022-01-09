using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace View.Komunikacija
{
    internal class KomunikacijaKlijent
    {
        
        private Primanje primanje;
        private Slanje slanje;

        public KomunikacijaKlijent(Socket soket)
        {
            primanje = new Primanje(soket);
            slanje = new Slanje(soket);
        }
        public void PosaljiZahtev(Zahtev zahtev)
        {
            
          slanje.Posalji(zahtev);
        }

        public Odgovor PrimiOdgovor()
        {
            
            Odgovor odgovor = (Odgovor)primanje.Primi();
            if (odgovor.Uspesno)
            {
                return odgovor;
            }
            else
            {
               
                return odgovor;
            }
        }
    }
}
