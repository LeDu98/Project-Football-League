using Domen;
using ServerKontroler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zajednicki;

namespace Server
{
    internal class Obrada
    {
        private Socket klijent;

        public Obrada(Socket klijent)
        {
            this.klijent = klijent;
        }

        public void PokreniObradu()
        {
            try
            {
                NetworkStream tok = new NetworkStream(klijent);
                BinaryFormatter formater = new BinaryFormatter();
                while (true)
                {
                    Zahtev z = (Zahtev)formater.Deserialize(tok);
                    Odgovor odgovor;
                    try
                    {
                        odgovor = ObradiZahtev(z);
                    }
                    catch (Exception ex)
                    {

                        odgovor = new Odgovor();
                        odgovor.Uspesno = false;
                        odgovor.Greska = ex.Message;
                    }
                    formater.Serialize(tok, odgovor);
                }
            }
            catch (IOException)
            {

                Console.WriteLine(" Doslo je do prekida veze.");
            }
        }

        private Odgovor ObradiZahtev(Zahtev z)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Uspesno = true;
            List<object> lista;
            switch (z.Operacija)
            {
                case Operacije.Prijavljivanje:
                    odgovor.Rezultat = new List<object>();
                    odgovor.Rezultat.Add(Kontroler.Instance.Prijavljivanje((AdministratorLige)z.Objekat));
                    odgovor.Uspesno = true;
                    break;

               /* case Operacije.VratiTabelu:
                    odgovor.Rezultat = Kontroler.Instance.VratiTabelu();
                    odgovor.Uspesno = true;
                    break;
               */



            }
            return odgovor;
        }
    }
}
