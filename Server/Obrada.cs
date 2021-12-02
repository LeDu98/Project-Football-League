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
                    Zahtev zahtev = (Zahtev)formater.Deserialize(tok);
                    Odgovor odgovor;
                    try
                    {
                        odgovor = ObradiZahtev(zahtev);
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

        private Odgovor ObradiZahtev(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Uspesno = true;
            List<object> lista;
            switch (zahtev.Operacija)
            {
                case Operacije.Prijavljivanje:
                    odgovor.Rezultat = new List<object>();
                    odgovor.Rezultat.Add(Kontroler.Instance.Prijavljivanje((AdministratorLige)zahtev.Objekat));
                    odgovor.Uspesno = true;
                    break;

                case Operacije.VratiTabelu:
                    odgovor.Rezultat = Kontroler.Instance.VratiTabelu();
                    odgovor.Uspesno = true;
                    break;

                case Operacije.VratiListuTimova:
                    odgovor.Rezultat = Kontroler.Instance.VratiTimove();
                    odgovor.Uspesno = true;
                    break;
                case Operacije.KreirajTim:
                    lista = new List<object>();
                    lista.Add(Kontroler.Instance.KreirajTim((Tim)zahtev.Objekat));
                    odgovor.Rezultat = lista;
                    break;
                case Operacije.ObrisiTim:
                    odgovor.Uspesno = Kontroler.Instance.ObrisiTim((Tim)zahtev.Objekat);
                    break;
                case Operacije.VratiListuIgraca:
                    odgovor.Rezultat = Kontroler.Instance.VratiIgrace();
                    odgovor.Uspesno = true;
                    break;
                case Operacije.VratiListuDrzava:
                    odgovor.Rezultat = Kontroler.Instance.VratiDrzave();
                    odgovor.Uspesno = true;
                    break;
                case Operacije.KreirajIgraca:
                    lista = new List<object>();
                    lista.Add(Kontroler.Instance.KreirajIgraca((Igrac)zahtev.Objekat));
                    odgovor.Rezultat = lista;
                    break;
                case Operacije.ObrisiIgraca:
                    odgovor.Uspesno = Kontroler.Instance.ObrisiIgraca((Igrac)zahtev.Objekat);
                    break;
                case Operacije.IzmeniTim:
                    odgovor.Uspesno = Kontroler.Instance.UpdateTima((Tim)zahtev.Objekat);
                    break;
                case Operacije.VratiListuUtakmica:
                    odgovor.Rezultat = Kontroler.Instance.VratiUtakmice();
                    odgovor.Uspesno = true;
                    break;
                case Operacije.KreirajUtakmicu:
                    lista = new List<object>();
                    lista.Add(Kontroler.Instance.KreirajUtakmicu((Utakmica)zahtev.Objekat));
                    odgovor.Rezultat = lista;
                    break;
                case Operacije.IzmeniUtakmicu:
                    odgovor.Uspesno = Kontroler.Instance.UpdateUtakmice((Utakmica)zahtev.Objekat);
                    break;
                case Operacije.KreirajStatistikeIgraca:
                    lista = new List<object>();
                    lista.Add(Kontroler.Instance.KreirajStatistiku((StatistikaIgraca)zahtev.Objekat));
                    odgovor.Rezultat = lista;
                    break;
                case Operacije.IzmeniIgraca:
                    odgovor.Uspesno = Kontroler.Instance.UpdateIgraca((Igrac)zahtev.Objekat);
                    break;
                case Operacije.VratiListuRezultata:
                    odgovor.Rezultat = Kontroler.Instance.VratiRezultate();
                    odgovor.Uspesno = true;
                    break;
                case Operacije.VratiListuStatistikaIgraca:
                    odgovor.Rezultat = Kontroler.Instance.VratiStatistikeIgraca();
                    odgovor.Uspesno = true;
                    break;
                case Operacije.ObrisiStatistikuIgraca:
                    odgovor.Uspesno = Kontroler.Instance.ObrisiStatistikuIgraca((StatistikaIgraca)zahtev.Objekat);
                    break;
                case Operacije.ObrisiUtakmicu:
                    odgovor.Uspesno = Kontroler.Instance.ObrisiUtakmicu((Utakmica)zahtev.Objekat);
                    break;
                case Operacije.VratiListuStrelaca:
                    odgovor.Rezultat = Kontroler.Instance.VratiListuStrelaca();
                    odgovor.Uspesno = true;
                    break;



            }
            return odgovor;
        }
    }
}
