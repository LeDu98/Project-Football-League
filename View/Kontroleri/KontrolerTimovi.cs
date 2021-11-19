using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Dialogs.Timovi;
using View.UserControls;
using Zajednicki;

namespace View.Kontroleri
{
    public class KontrolerTimovi
    {
        private UCTimovi uCTimovi;
        
        private BindingList<Tim> timovi;
        private Tim selektovanTim;
        private DialogKreirajTim dialogKreirajTim;
        private DialogDetaljiOTimu dialogDetaljiOTimu;
        internal void InicijalizujUCTimovi(UCTimovi uCTimovi)
        {
            this.uCTimovi = uCTimovi;
            UcitajTimove();
            this.uCTimovi.DataGridTimovi.DataSource = timovi;
        }

        private void UcitajTimove()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuTimova);
            timovi = new BindingList<Tim>();
            foreach (object o in lista)
            {
                timovi.Add((Tim)o);
            }
        }

        internal void DodajTim()
        {
           if(string.IsNullOrEmpty(dialogKreirajTim.TxtNaziv.Text) || string.IsNullOrEmpty(dialogKreirajTim.TxtGrad.Text) || string.IsNullOrEmpty(dialogKreirajTim.TxtBojaKluba.Text) || string.IsNullOrEmpty(dialogKreirajTim.TxtPobede.Text) || string.IsNullOrEmpty(dialogKreirajTim.TxtNeresene.Text) || string.IsNullOrEmpty(dialogKreirajTim.TxtPorazi.Text))
            {
                System.Windows.Forms.MessageBox.Show("Niste uneli vrednosti u sva polja!");
                return;
            }
            Tim tim = new Tim();
            tim.NazivTima = dialogKreirajTim.TxtNaziv.Text;
            tim.Grad = dialogKreirajTim.TxtGrad.Text;
            tim.BojaKluba = dialogKreirajTim.TxtBojaKluba.Text;
            try
            {
                tim.Pobede = int.Parse(dialogKreirajTim.TxtPobede.Text);
                tim.Neresene = int.Parse(dialogKreirajTim.TxtNeresene.Text);
                tim.Porazi = int.Parse(dialogKreirajTim.TxtPorazi.Text);
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("U polja namenjena za unos pobeda, poraza i nerešenih utakmica morate uneti numeričku vrednost!");
                return;
            }
            tim.OdigraneUtakmice = tim.Pobede + tim.Neresene + tim.Porazi;
            tim.Bodovi = tim.Pobede * 3 + tim.Neresene;

            Tim pomocni = (Tim)Komunikacija.Komunikacija.Instance.Kreiraj(Operacije.KreirajTim, tim);
            if (pomocni != null)
            {
                System.Windows.Forms.MessageBox.Show("Uspesno ste kreirali novi tim!");
                timovi.Add(pomocni);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Sistem ne može da zapamti uneti tim!");
            }
        }

        internal BindingList<Tim> VratiTimove()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuTimova);
            timovi = new BindingList<Tim>();
            foreach (object o in lista)
            {
                timovi.Add((Tim)o);
            }
            return timovi;
        }

        internal void PromeniPodatkeTima(Tim tim)
        {
            var result = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da sačuvate promenjene podatke o timu?", "Sačuvaj", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, tim);
                System.Windows.Forms.MessageBox.Show("Sistem je izmenio podatke o timu!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD Izmene TIMA");
                System.Windows.Forms.MessageBox.Show("Sistem ne moze da izmeni podatke o timu");
            }
        }

        internal void OtvoriDialogDetaljiOTimu(Tim tim, BindingList<Igrac> listaIgraca)
        {
            this.dialogDetaljiOTimu = new DialogDetaljiOTimu(this,tim,listaIgraca);
            this.dialogDetaljiOTimu.ShowDialog();
        }

        internal void ObrisiTim()
        {
            var result = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da obrišete tim?","Obriši",System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            try
            {
                Tim tim = uCTimovi.DataGridTimovi.CurrentRow.DataBoundItem as Tim;
                Komunikacija.Komunikacija.Instance.Obrisi(Operacije.ObrisiTim, tim);
                timovi.Remove(tim);
                System.Windows.Forms.MessageBox.Show("Sistem je obrisao tim");
            }
            catch (Exception e)
            {

                Console.WriteLine(e+"EXCEPTION KOD BRISANJA TIMA");
                System.Windows.Forms.MessageBox.Show("Sistem ne moze da obrise tim");
            }
        }

        internal void Filtriraj()
        {
            uCTimovi.DataGridTimovi.DataSource=FiltrirajPretragu(uCTimovi.TxtPretraga.Text.ToLower());
            uCTimovi.DataGridTimovi.Refresh();
        }

        internal void OtvoriDialogKreirajTim()
        {
            this.dialogKreirajTim = new DialogKreirajTim(this);
            this.dialogKreirajTim.ShowDialog();
            
        }

        private BindingList<Tim> FiltrirajPretragu(string tekstPretrage)
        {
            BindingList<Tim> filtriraniTimovi = new BindingList<Tim>();
            foreach(Tim t in timovi)
            {
                string stringTimovi = t.NazivTima;
                stringTimovi = stringTimovi.ToLower();
                if (stringTimovi.Contains(tekstPretrage))
                {
                    filtriraniTimovi.Add(t);

                }
            }
            if (filtriraniTimovi.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Sistem ne moze da nadje timove po zadatoj vrednosti!");
            }
                return filtriraniTimovi;
        }
    }
}
