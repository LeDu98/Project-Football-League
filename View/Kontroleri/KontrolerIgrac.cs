using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Dialogs.Igraci;
using View.UserControls;

namespace View.Kontroleri
{
    public class KontrolerIgrac
    {
        private UCIgraci uCIgraci;
        private BindingList<Igrac> igraci;
        private DialogKreirajIgraca dialogKreirajIgraca;
        internal void InicijalizujUCIgrac(UCIgraci uCIgraci)
        {
            this.uCIgraci = uCIgraci;
            UcitajIgrace();
            this.uCIgraci.DataGridIgraci.DataSource = igraci;
        }

        internal void InicijalizujDialogKreirajIgraca(DialogKreirajIgraca dialogKreirajIgraca)
        {
            this.dialogKreirajIgraca = dialogKreirajIgraca;
            NapuniCbPozicije(dialogKreirajIgraca.CbPozicija);
            NapuniCbTimovi(dialogKreirajIgraca.CbTim);
            NapuniCbDrzave(dialogKreirajIgraca.CbDrzava);
        }

        internal void ObrisiIgraca()
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete igrača?", "Obriši", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                Igrac igrac = uCIgraci.DataGridIgraci.CurrentRow.DataBoundItem as Igrac;
                Komunikacija.Komunikacija.Instance.Obrisi(Zajednicki.Operacije.ObrisiIgraca, igrac);
                igraci.Remove(igrac);
                MessageBox.Show("Sistem je obrisao igrača!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD BRISANJA IGRACA");
                System.Windows.Forms.MessageBox.Show("Sistem ne moze da obrise igrača!");
            }
        }

        internal BindingList<Igrac> VratiListuIgracaTima(Tim t)
        {
            List<Object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuIgraca);
            igraci = new BindingList<Igrac>();
            foreach (Igrac i in lista)
            {
                if (i.TimID.TimID == t.TimID)
                {
                igraci.Add((Igrac)i);

                }  
            }
            return igraci;
        }

        internal void DodajIgraca()
        {
           if(string.IsNullOrEmpty(dialogKreirajIgraca.TxtIme.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.TxtPrezime.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.TxtGolovi.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.CbPozicija.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.CbDrzava.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.CbTim.Text))
            {
                MessageBox.Show("Niste uneli vrednosti u sva polja");
                return;
            }
            Igrac i = new Igrac();
            i.Ime = dialogKreirajIgraca.TxtIme.Text;
            i.Prezime = dialogKreirajIgraca.TxtPrezime.Text;

            try
            {
                i.Golovi = int.Parse(dialogKreirajIgraca.TxtGolovi.Text);
                if (i.Golovi <= 0)
                {
                    MessageBox.Show("U polje golovi morate uneti pozitivan ceo broj");
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("U polje golovi morate uneti pozitivan ceo broj!");
                return;
            }
            i.Pozicija = dialogKreirajIgraca.CbPozicija.SelectedItem.ToString();
            try
            {
                i.TimID = dialogKreirajIgraca.CbTim.SelectedItem as Tim;
            }
            catch (Exception)
            {
                MessageBox.Show("Morate odabrati jedan od ponuđenih timova!");
                return;

            }
            try
            {
                i.DrzavaID = dialogKreirajIgraca.CbDrzava.SelectedItem as Drzava;
            }
            catch (Exception)
            {

                MessageBox.Show("Morate odabrati jednu od ponuđenih država!");
                return;
            }

            Igrac pom = (Igrac)Komunikacija.Komunikacija.Instance.Kreiraj(Zajednicki.Operacije.KreirajIgraca, i);
            if (pom != null)
            {
                MessageBox.Show($"Igrač {i.Ime} {i.Prezime} je uspešno kreiran!");
                igraci.Add(pom);
            }
            else
            {
                MessageBox.Show("Sistem ne može da zapamti unetog igrača!");
            }

        }

        private void NapuniCbDrzave(ComboBox cbDrzava)
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuDrzava);

            foreach (object o in lista)
            {
                cbDrzava.Items.Add(o);
            }
        }

        private void NapuniCbTimovi(ComboBox cbTim)
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuTimova);

            foreach(object o in lista)
            {
                cbTim.Items.Add(o);
            }
        }

        private void NapuniCbPozicije(ComboBox cbPozicija)
        {
            cbPozicija.Items.Add("Golman");
            cbPozicija.Items.Add("Odbrana");
            cbPozicija.Items.Add("Vezni red");
            cbPozicija.Items.Add("Napad");
            cbPozicija.SelectedIndex = 0;
        }

        private void UcitajIgrace()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuIgraca);
            igraci = new BindingList<Igrac>();
            foreach (object o in lista)
            {
                igraci.Add((Igrac)o);
            }
        }

        internal void OtvoriDialogKreirajIgraca()
        {
            this.dialogKreirajIgraca = new DialogKreirajIgraca(this);
            dialogKreirajIgraca.ShowDialog();
        }
    }
}
