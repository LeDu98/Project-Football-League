using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Dialogs.Timovi;
using View.UserControls;
using Zajednicki;

namespace View.Kontroleri
{
    public class KontrolerTimovi
    {
        private UCTimovi uCTimovi;
        
        private BindingList<Tim> timovi;
        private BindingList<Igrac> igraci;
        private BindingList<Igrac> igraciBrisanje;
        
        
        
       
        private DialogKreirajTim dialogKreirajTim;
        private DialogDetaljiOTimu dialogDetaljiOTimu;
        internal void InicijalizujUCTimovi(UCTimovi uCTimovi)
        {
            this.uCTimovi = uCTimovi;
            UcitajTimove();
            this.uCTimovi.DataGridTimovi.DataSource = timovi;
            uCTimovi.DataGridTimovi.Columns[0].HeaderText = "Naziv tima";
            uCTimovi.DataGridTimovi.Columns[1].HeaderText = "Grad";
            uCTimovi.DataGridTimovi.Columns[2].HeaderText = "Boje tima";
        }

        internal void InicijalizujDialogDetaljiOTimu(DialogDetaljiOTimu dialogDetaljiOTimu, Tim tim)
        {
            dialogDetaljiOTimu.TBNazivTima.Text = tim.NazivTima;
            dialogDetaljiOTimu.TBGrad.Text = tim.Grad;
            dialogDetaljiOTimu.TBBojaKluba.Text = tim.BojaKluba;
            
            dialogDetaljiOTimu.LabelOdigrane.Text = tim.OdigraneUtakmice.ToString();
            dialogDetaljiOTimu.LabelPobede.Text = tim.Pobede.ToString();
            dialogDetaljiOTimu.LabelNeresene.Text = tim.Neresene.ToString();
            dialogDetaljiOTimu.LabelPorazi.Text = tim.Porazi.ToString();
            dialogDetaljiOTimu.LabelBodovi.Text = tim.Bodovi.ToString();

            dialogDetaljiOTimu.TBNazivTima.Enabled = false;
            dialogDetaljiOTimu.TBGrad.Enabled = false;
            dialogDetaljiOTimu.TBBojaKluba.Enabled = false;

            dialogDetaljiOTimu.BtnPromeni.Enabled = false;

            igraci = VratiListuIgracaTima(tim);
            dialogDetaljiOTimu.DataGridIgraci.DataSource = igraci;

            dialogDetaljiOTimu.DataGridIgraci.Columns[4].HeaderText = "Država";
            dialogDetaljiOTimu.DataGridIgraci.Columns[5].Visible = false;
        }

        internal void PromeniStanjeDialogaDetaljiOTimu()
        {
            if (dialogDetaljiOTimu.CheckPromeni.Checked)
            {
                dialogDetaljiOTimu.TBNazivTima.Enabled = true;
                dialogDetaljiOTimu.TBGrad.Enabled = true;
                dialogDetaljiOTimu.TBBojaKluba.Enabled = true;
                
                dialogDetaljiOTimu.BtnPromeni.Enabled = true;
            }
            else
            {
                dialogDetaljiOTimu.TBNazivTima.Enabled = false;
                dialogDetaljiOTimu.TBGrad.Enabled = false;
                dialogDetaljiOTimu.TBBojaKluba.Enabled = false;

                dialogDetaljiOTimu.BtnPromeni.Enabled = false;
            }
        }

        private void UcitajTimove()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuTimova);
            timovi = new BindingList<Tim>();
            if (lista == null)
            {
                return;
            }
            foreach (object o in lista)
            {
                timovi.Add((Tim)o);
            }
        }

        internal void DodajTim()
        {
           if(string.IsNullOrEmpty(dialogKreirajTim.TxtNaziv.Text) || string.IsNullOrEmpty(dialogKreirajTim.TxtGrad.Text) || string.IsNullOrEmpty(dialogKreirajTim.TxtBojaKluba.Text))
            {
                MessageBox.Show("Niste uneli vrednosti u sva polja!");
                return;
            }
            Tim tim = new Tim();
            tim.NazivTima = dialogKreirajTim.TxtNaziv.Text;
            tim.Grad = dialogKreirajTim.TxtGrad.Text;
            tim.BojaKluba = dialogKreirajTim.TxtBojaKluba.Text;
           

            Tim pomocni = (Tim)Komunikacija.Komunikacija.Instance.Kreiraj(Operacije.KreirajTim, tim);
            if (pomocni != null)
            {
               MessageBox.Show("Uspesno ste kreirali novi tim!");
                timovi.Add(pomocni);
                UcitajTimove();
                this.uCTimovi.DataGridTimovi.DataSource = timovi;
            }
            else
            {
               MessageBox.Show("Sistem ne može da zapamti uneti tim!");
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

        
        internal void PromeniPodatkeTima(Tim tim)
        {
            if (dialogDetaljiOTimu.TBBojaKluba.Text == tim.BojaKluba && dialogDetaljiOTimu.TBGrad.Text == tim.Grad && dialogDetaljiOTimu.TBNazivTima.Text == tim.NazivTima)
            {
                MessageBox.Show("Podaci su ostali nepromenjeni!");
                return;
            }
            if (string.IsNullOrEmpty(dialogDetaljiOTimu.TBNazivTima.Text) || string.IsNullOrEmpty(dialogDetaljiOTimu.TBGrad.Text) || string.IsNullOrEmpty(dialogDetaljiOTimu.TBBojaKluba.Text))
            {
                MessageBox.Show("Sva polja su obavezna");
                return;
            }
            tim.NazivTima = dialogDetaljiOTimu.TBNazivTima.Text;
            tim.BojaKluba = dialogDetaljiOTimu.TBBojaKluba.Text;
            tim.Grad = dialogDetaljiOTimu.TBGrad.Text;

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
            dialogDetaljiOTimu.Dispose();
            UcitajTimove();
            this.uCTimovi.DataGridTimovi.DataSource = timovi;
        }

        internal void OtvoriDialogDetaljiOTimu()
        {
            Tim tim = uCTimovi.DataGridTimovi.CurrentRow.DataBoundItem as Tim;
            this.dialogDetaljiOTimu = new DialogDetaljiOTimu(this,tim);
            this.dialogDetaljiOTimu.ShowDialog();
        }

        internal void ObrisiTim()
        {
            var result = System.Windows.Forms.MessageBox.Show("Ukoliko potvrdite pored obrisanog tima će se obrisati i svi igrači tima, statistike igrača tima, kao i sve utakmice koje je tim odigrao ili treba odigrati. Da li ste sigurni da želite da obrišete tim?","Obriši",System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            try
            {
                Tim tim = uCTimovi.DataGridTimovi.CurrentRow.DataBoundItem as Tim;
                List<object> listaUtakmica = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuUtakmica);
                List<object> listaStatistika = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuStatistikaIgraca);
                List<object> listaTimova = Komunikacija.Komunikacija.Instance.VratiListu(Operacije.VratiListuTimova);

                
                foreach(Tim tim1 in listaTimova)
                {
                    foreach (Utakmica u in listaUtakmica)
                    {

                        if ((u.DomacinID.TimID == tim.TimID || u.GostID.TimID == tim.TimID) && (tim1.TimID==u.DomacinID.TimID || tim1.TimID==u.GostID.TimID))
                        {
                            foreach (StatistikaIgraca si in listaStatistika)
                            {
                                if (si.UtakmicaID.UtakmicaID == u.UtakmicaID)
                                {
                                    Igrac i = new Igrac();
                                    i = si.IgracID;
                                    i.Golovi -= si.Golovi;
                                    Komunikacija.Komunikacija.Instance.Obrisi(Operacije.ObrisiStatistikuIgraca, si);
                                    Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniIgraca, i);


                                }
                            }
                            if (tim1.TimID == u.DomacinID.TimID)
                            {
                                if (u.DomacinGolovi != -1 && u.GostGolovi != -1)
                                {
                                    if (u.DomacinGolovi == u.GostGolovi)
                                    {
                                        tim1.Neresene -= 1;
                                        tim1.Bodovi -= 1;
                                        Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, tim1);
                                    }
                                    if (u.DomacinGolovi > u.GostGolovi)
                                    {
                                        tim1.Pobede -= 1;
                                        tim1.Bodovi -= 3;
                                        Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, tim1);
                                    }
                                    if (u.DomacinGolovi < u.GostGolovi)
                                    {
                                        tim1.Porazi -= 1;
                                        Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, tim1);
                                    }
   
                                }
                            }
                            if (tim1.TimID == u.GostID.TimID)
                            {
                                if (u.DomacinGolovi != -1 && u.GostGolovi != -1)
                                {
                                    if (u.DomacinGolovi == u.GostGolovi)
                                    {
                                        tim1.Neresene -= 1;
                                        tim1.Bodovi -= 1;
                                        Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim,tim1);
                                    }
                                    if (u.DomacinGolovi < u.GostGolovi)
                                    {
                                        tim1.Pobede -= 1;
                                        tim1.Bodovi -= 3;
                                        Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, tim1);
                                    }
                                    if (u.DomacinGolovi > u.GostGolovi)
                                    {
                                        tim1.Porazi -= 1;
                                        Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, tim1);
                                    }
                                   
                                }
                            }
                            Komunikacija.Komunikacija.Instance.Obrisi(Operacije.ObrisiUtakmicu, u);
                        }
                    }
                }
                

                
                igraciBrisanje = new BindingList<Igrac>();
                igraciBrisanje = VratiListuIgracaTima(tim);
                    
               foreach(Igrac i in igraci)
                {
                  Komunikacija.Komunikacija.Instance.Obrisi(Operacije.ObrisiIgraca, i);
                }
                
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
