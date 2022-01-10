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
using Zajednicki;

namespace View.Kontroleri
{
    public class KontrolerIgrac
    {
        private UCIgraci uCIgraci;
        private BindingList<Igrac> igraci;
        private DialogKreirajIgraca dialogKreirajIgraca;
        private DialogDetaljiOIgracu dialogDetaljiOIgracu;
        private BindingList<StatistikaIgraca> listaStatistikaIgraca;

        private BindingList<Igrac> filtriraniIgraci;

        #region UCIgrac
        internal void InicijalizujUCIgrac(UCIgraci uCIgraci)
        {
            this.uCIgraci = uCIgraci;
            UcitajIgrace();
            this.uCIgraci.DataGridIgraci.DataSource = igraci;
            uCIgraci.DataGridIgraci.Columns[4].HeaderText = "Država";
            uCIgraci.DataGridIgraci.Columns[5].HeaderText = "Tim";
        }

        private void UcitajIgrace()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuIgraca);
            igraci = new BindingList<Igrac>();
            if (lista == null)
            {
                return;
            }
            foreach (object o in lista)
            {
                igraci.Add((Igrac)o);
            }
        }

        internal void Filtriraj()
        {
            uCIgraci.DataGridIgraci.DataSource = FiltrirajPretragu(uCIgraci.TxtPretraga.Text.ToLower());
            uCIgraci.DataGridIgraci.Refresh();
        }

        private BindingList<Igrac> FiltrirajPretragu(string tekstPretrage)
        {

            Igrac igrac = new Igrac();
            igrac.Ime = tekstPretrage;
            igrac.Prezime = tekstPretrage;
            filtriraniIgraci = new BindingList<Igrac>();
            try
            {
                List<object> pretrazeniTimovi = Komunikacija.Komunikacija.Instance.Pretrazi(Operacije.PretragaIgraca, igrac);
                foreach (Igrac i in pretrazeniTimovi)
                {
                    filtriraniIgraci.Add(i);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Sistem ne moze da nadje igrače po zadatoj vrednosti!");
            }
            if (filtriraniIgraci.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da nadje igrače po zadatoj vrednosti!");
            }
            return filtriraniIgraci;
        }

        internal void ObrisiIgraca()
        {
            var result = MessageBox.Show("Ukoliko potvrdite to znači da će se svi podaci o igraču obrisati, kao i svi podaci o statistikama obrisanog igrača. Da li ste sigurni da želite da obrišete igrača?", "Obriši", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                if (uCIgraci.DataGridIgraci.RowCount == 0)
                {
                    MessageBox.Show("Sistem ne moze da obrise igraca");
                    return;
                }
                Igrac igrac = uCIgraci.DataGridIgraci.CurrentRow.DataBoundItem as Igrac;
                List<object> listaStatistika = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuStatistikaIgraca);
                listaStatistikaIgraca = new BindingList<StatistikaIgraca>();


                foreach (StatistikaIgraca o in listaStatistika)
                {
                    if (o.IgracID.IgracID == igrac.IgracID)
                    {

                        listaStatistikaIgraca.Add(o);
                    }
                }
                igrac.ListaStatistika = listaStatistikaIgraca;
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
        #endregion

        #region dialogKreirajIgraca
        internal void InicijalizujDialogKreirajIgraca(DialogKreirajIgraca dialogKreirajIgraca)
        {
            this.dialogKreirajIgraca = dialogKreirajIgraca;
            NapuniCbPozicije(dialogKreirajIgraca.CbPozicija);
            NapuniCbTimovi(dialogKreirajIgraca.CbTim);
            NapuniCbDrzave(dialogKreirajIgraca.CbDrzava);
            
        }
        internal void OtvoriDialogKreirajIgraca()
        {
            this.dialogKreirajIgraca = new DialogKreirajIgraca(this);
            dialogKreirajIgraca.ShowDialog();
        }
        internal void DodajIgraca()
        {
            if (string.IsNullOrEmpty(dialogKreirajIgraca.TxtIme.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.TxtPrezime.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.CbPozicija.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.CbDrzava.Text) || string.IsNullOrEmpty(dialogKreirajIgraca.CbTim.Text))
            {
                MessageBox.Show("Niste uneli vrednosti u sva polja");
                return;
            }
            if(dialogKreirajIgraca.TxtIme.Text.Any<char>(char.IsDigit) || dialogKreirajIgraca.TxtPrezime.Text.Any<char>(char.IsDigit)){
                MessageBox.Show("Polja ime i prezime ne mogu sadrzati numericke vrednosti");
                return;
            }
            Igrac i = new Igrac();
            i.Ime = dialogKreirajIgraca.TxtIme.Text;
            i.Prezime = dialogKreirajIgraca.TxtPrezime.Text;


            i.Pozicija = dialogKreirajIgraca.CbPozicija.SelectedItem.ToString();

            i.TimID = dialogKreirajIgraca.CbTim.SelectedItem as Tim;
            if (i.TimID == null)
            {
                MessageBox.Show("Uneli ste nevalidnu vrednost za tim! Morate odabrati jednu od posojecih opcija.");
                return;
            }


            i.DrzavaID = dialogKreirajIgraca.CbDrzava.SelectedItem as Drzava;
            if (i.DrzavaID == null)
            {
                MessageBox.Show("Uneli ste nevalidnu vrednost za drzavu! Morate odabrati jednu od postojecih opcija.");
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
            dialogKreirajIgraca.Dispose();


        }



        #endregion

        #region dialogDetaljiOIgracu
        internal void InicijalizujDialogDetaljiOIgracu(DialogDetaljiOIgracu dialogDetaljiOIgracu, Igrac i)
        {
            this.dialogDetaljiOIgracu = dialogDetaljiOIgracu;
            NapuniCbPozicije(dialogDetaljiOIgracu.CBPozicija);
            NapuniCbTimovi(dialogDetaljiOIgracu.CBTim);
            NapuniCbDrzave(dialogDetaljiOIgracu.CBDrzava);


            dialogDetaljiOIgracu.CBDrzava.Text = i.DrzavaID.NazivDrzave;
            dialogDetaljiOIgracu.CBPozicija.Text = i.Pozicija;
            dialogDetaljiOIgracu.CBTim.Text = i.TimID.NazivTima;

            dialogDetaljiOIgracu.LabelGolovi.Text = i.Golovi.ToString();
            dialogDetaljiOIgracu.TBIme.Text = i.Ime;
            dialogDetaljiOIgracu.TBPrezime.Text = i.Prezime;

            dialogDetaljiOIgracu.CBDrzava.Enabled = false;
            dialogDetaljiOIgracu.CBPozicija.Enabled = false;
            dialogDetaljiOIgracu.CBTim.Enabled = false;

            dialogDetaljiOIgracu.TBIme.Enabled = false;
            dialogDetaljiOIgracu.TBPrezime.Enabled = false;
            dialogDetaljiOIgracu.BtnIzmeni.Enabled = false;
        }

        internal void PromeniPodatkeIgraca(Igrac igrac)
        {
            if (dialogDetaljiOIgracu.TBIme.Text == igrac.Ime && dialogDetaljiOIgracu.TBPrezime.Text == igrac.Prezime && dialogDetaljiOIgracu.CBDrzava.Text == igrac.DrzavaID.NazivDrzave && dialogDetaljiOIgracu.CBPozicija.Text == igrac.Pozicija && dialogDetaljiOIgracu.CBTim.Text == igrac.TimID.NazivTima)
            {
                MessageBox.Show("Sistem nije izmenio podatke jer nije izvršena nikakva promena nad njima!");
                return;
            }
            if (string.IsNullOrEmpty(dialogDetaljiOIgracu.TBIme.Text) || string.IsNullOrEmpty(dialogDetaljiOIgracu.TBPrezime.Text) || string.IsNullOrEmpty(dialogDetaljiOIgracu.CBPozicija.Text))
            {
                MessageBox.Show("Sva polja su obavezna");
                return;
            }
            if (dialogDetaljiOIgracu.TBIme.Text.Any<char>(char.IsDigit) || dialogDetaljiOIgracu.TBPrezime.Text.Any<char>(char.IsDigit))
            {
                MessageBox.Show("Polja ime i prezime ne mogu sadrzati numericke vrednosti");
                return;
            }
            igrac.TimID = dialogDetaljiOIgracu.CBTim.SelectedItem as Tim;
            if (igrac.TimID == null)
            {
                MessageBox.Show("Nevalidna vrednost za Tim!");
                return;
            }
            igrac.DrzavaID = dialogDetaljiOIgracu.CBDrzava.SelectedItem as Drzava;
            if (igrac.DrzavaID == null)
            {
                MessageBox.Show("Nevalidna vrednost za drzavu!");
                return;
            }
            igrac.Ime = dialogDetaljiOIgracu.TBIme.Text;
            igrac.Prezime = dialogDetaljiOIgracu.TBPrezime.Text;
            igrac.Pozicija = dialogDetaljiOIgracu.CBPozicija.Text;

            var result = MessageBox.Show("Da li ste sigurni da želite da sačuvate promenjene podatke o igraču?", "Sačuvaj", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniIgraca, igrac);
                System.Windows.Forms.MessageBox.Show("Sistem je izmenio podatke o igraču!");
                uCIgraci.TxtPretraga.Text = "";
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD Izmene igrača");
                System.Windows.Forms.MessageBox.Show("Sistem ne moze da izmeni podatke o igraču");
            }
            dialogDetaljiOIgracu.Dispose();
            UcitajIgrace();
            this.uCIgraci.DataGridIgraci.DataSource = igraci;
        }

        internal void PromeniStanjeDialogaDetaljiOIgracu()
        {
            if (dialogDetaljiOIgracu.CheckIzmeni.Checked)
            {
                dialogDetaljiOIgracu.CBDrzava.Enabled = true;
                dialogDetaljiOIgracu.CBPozicija.Enabled = true;
                dialogDetaljiOIgracu.CBTim.Enabled = true;

                dialogDetaljiOIgracu.TBIme.Enabled = true;
                dialogDetaljiOIgracu.TBPrezime.Enabled = true;
                dialogDetaljiOIgracu.BtnIzmeni.Enabled = true;
            }
            else
            {
                dialogDetaljiOIgracu.CBDrzava.Enabled = false;
                dialogDetaljiOIgracu.CBPozicija.Enabled = false;
                dialogDetaljiOIgracu.CBTim.Enabled = false;

                dialogDetaljiOIgracu.TBIme.Enabled = false;
                dialogDetaljiOIgracu.TBPrezime.Enabled = false;
                dialogDetaljiOIgracu.BtnIzmeni.Enabled = false;
            }
        }

        internal void OtvoriDialogDetaljiOIgracu()
        {
            if (uCIgraci.DataGridIgraci.RowCount == 0)
            {
                MessageBox.Show("Sistem ne moze da ucita igraca");
                return;
            }
            Igrac igrac = uCIgraci.DataGridIgraci.CurrentRow.DataBoundItem as Igrac;
            igrac = (Igrac)Komunikacija.Komunikacija.Instance.VratiObjekat(Operacije.VratiObjekatIgrac, (object)igrac)[0];
            if (igrac.IgracID == 0)
            {
                MessageBox.Show("Sistem ne može da učita igrača");
                return;
            }
            this.dialogDetaljiOIgracu = new DialogDetaljiOIgracu(this, igrac);
            dialogDetaljiOIgracu.ShowDialog();
        }
        private void NapuniCbDrzave(ComboBox cbDrzava)
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuDrzava);
            if (lista == null)
            {
                return;
            }
            foreach (object o in lista)
            {
                cbDrzava.Items.Add(o);
            }
            cbDrzava.SelectedIndex = 0;
        }
        private void NapuniCbTimovi(ComboBox cbTim)
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuTimova);
            if (lista == null)
            {
                return;
            }
            foreach (object o in lista)
            {
                cbTim.Items.Add(o);
            }
            cbTim.SelectedIndex = 0;
        }

        private void NapuniCbPozicije(ComboBox cbPozicija)
        {
            cbPozicija.Items.Add("Golman");
            cbPozicija.Items.Add("Odbrana");
            cbPozicija.Items.Add("Vezni red");
            cbPozicija.Items.Add("Napad");
            cbPozicija.SelectedIndex = 0;
        }

        #endregion

    }
}
