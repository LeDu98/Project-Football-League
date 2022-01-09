using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Dialogs.Utakmice;
using View.UserControls;
using Zajednicki;

namespace View.Kontroleri
{
   public class KontrolerRaspored
    {
        private UCRaspored uCRaspored;
        private BindingList<Utakmica> raspored;
        private DialogKreirajUtakmicu dialogKreirajUtakmicu;
        private DialogUpdateUtakmicu dialogUpdateUtakmicu;
        private BindingList<Tim> timovi;
        private BindingList<Igrac> igraci;
        private BindingList<Igrac> domaciIgraci;
        private BindingList<Igrac> gostujuciIgraci;
        private BindingList<StatistikaIgraca> listaStatistikaIgraca;

        private BindingList<Utakmica> filtriraneUtakmice;

        private int domacinGolovi;
        private int gostGolovi;
        private int strelacDomaci = 1;
        private int strelacGost = 1;

        #region UCRaspored
        internal void InicijalizujUCRaspored(UCRaspored uCRaspored)
        {
            this.uCRaspored = uCRaspored;

            UcitajUtakmice();
            this.uCRaspored.DataGridUtakmice.DataSource = raspored;

           
          

            uCRaspored.DataGridUtakmice.Columns[0].HeaderText = "Termin utakmice";
            uCRaspored.DataGridUtakmice.Columns[1].HeaderText = "Domaći tim";
            uCRaspored.DataGridUtakmice.Columns[2].Visible = false;
            uCRaspored.DataGridUtakmice.Columns[3].Visible = false;
            uCRaspored.DataGridUtakmice.Columns[4].HeaderText = "Gostujući tim";

        }
        internal void ObrisiUtakmicu()
        {
            var result = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da obrišete utakmicu?", "Obriši", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            try
            {
                Utakmica utakmica = uCRaspored.DataGridUtakmice.CurrentRow.DataBoundItem as Utakmica;

                List<object> listaStatistika = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuStatistikaIgraca);
       
                foreach (StatistikaIgraca si in listaStatistika)
                   {
                        if (si.UtakmicaID.UtakmicaID == utakmica.UtakmicaID)
                            {
                              Komunikacija.Komunikacija.Instance.Obrisi(Operacije.ObrisiStatistikuIgraca, si);
                            }
                   }
                Komunikacija.Komunikacija.Instance.Obrisi(Operacije.ObrisiUtakmicu, utakmica);
                raspored.Remove(utakmica);
                System.Windows.Forms.MessageBox.Show("Sistem je obrisao utakmicu");
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD BRISANJA UTAKMICE");
                System.Windows.Forms.MessageBox.Show("Sistem ne moze da obrise utakmicu");
            }
        }
        internal void Filtriraj()
        {
            
            uCRaspored.DataGridUtakmice.DataSource = FiltrirajPretragu(uCRaspored.TBPretraga.Text.ToLower());
            uCRaspored.DataGridUtakmice.Refresh();
        }

        private BindingList<Utakmica> FiltrirajPretragu(string tekstPretrage)
        {
            Utakmica utakmica = new Utakmica();
            utakmica.Pretraga = tekstPretrage;
            
            filtriraneUtakmice = new BindingList<Utakmica>();
            try
            {
                List<object> pretrazeneUtakmice = Komunikacija.Komunikacija.Instance.Pretrazi(Operacije.PretragaUtakmica, utakmica);
                foreach (Utakmica u in pretrazeneUtakmice)
                {
                    if (u.DomacinGolovi == -1 && u.GostGolovi == -1)
                    {
                        filtriraneUtakmice.Add(u);

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Sistem ne moze da nadje timove po zadatoj vrednosti!");
            }
            if (filtriraneUtakmice.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da nadje timove po zadatoj vrednosti!");

            }
            return filtriraneUtakmice;
        }
        private void UcitajUtakmice()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuUtakmica);
            raspored = new BindingList<Utakmica>();
            if (lista == null)
            {
                return;
            }
            foreach (Utakmica o in lista)
            {
                if (o.DomacinGolovi == -1 && o.GostGolovi == -1)
                {
                    raspored.Add(o);

                }
            }
        }


        #endregion

        #region DialogKreirajUtakmicu
        internal void InicijalizujDialogKreirajUtakmicu(DialogKreirajUtakmicu dialogKreirajUtakmicu)
        {
            this.dialogKreirajUtakmicu = dialogKreirajUtakmicu;
            timovi = VratiTimove();

            foreach (Tim t in timovi)
            {
                dialogKreirajUtakmicu.CbDomacin.Items.Add(t);

            }
            foreach (Tim t2 in timovi)
            {
                dialogKreirajUtakmicu.CbGost.Items.Add(t2);
            }
            dialogKreirajUtakmicu.CbDomacin.SelectedIndex = 0;
            dialogKreirajUtakmicu.CbGost.SelectedIndex = 1;
            dialogKreirajUtakmicu.CbDomacin.DropDownStyle = ComboBoxStyle.DropDownList;
            dialogKreirajUtakmicu.CbGost.DropDownStyle = ComboBoxStyle.DropDownList;
            
            dialogKreirajUtakmicu.DatumIVreme.Format = DateTimePickerFormat.Custom;
            dialogKreirajUtakmicu.DatumIVreme.CustomFormat = "dd.MM.yyyy. HH:mm";

            
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
        internal void OtvoriDialogKreirajUtakmicu()
        {
            dialogKreirajUtakmicu = new DialogKreirajUtakmicu(this);
            dialogKreirajUtakmicu.ShowDialog();
        }
        internal void KreirajUtakmicu()
        {
            Tim domacin = dialogKreirajUtakmicu.CbDomacin.SelectedItem as Tim;
            Tim gost = dialogKreirajUtakmicu.CbGost.SelectedItem as Tim;
            if (domacin == null || gost == null)
            {
                MessageBox.Show("Niste selektovali validne vrednosti!");
                return;
            }
            if (domacin == gost)
            {
                MessageBox.Show("Ne mozete selektovati dva ista tima");
                return;
            }


            Utakmica u = new Utakmica()
            {
                DomacinID = domacin,
                GostID = gost,
                DatumIVremeOdigravanja = dialogKreirajUtakmicu.DatumIVreme.Value

            };
            Utakmica pomocna = (Utakmica)Komunikacija.Komunikacija.Instance.Kreiraj(Zajednicki.Operacije.KreirajUtakmicu, u);
            if (pomocna != null)
            {
                MessageBox.Show("Sistem je zapamtio novu utakmicu!");
                raspored.Add(u);
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti novu utakmicu!");
            }
        }

        #endregion


        #region DialogUpdateUtakmice

        internal void ObradaSignalaGostStrelac(Utakmica raspored)
        {
            Utakmica u = raspored;
            if (dialogUpdateUtakmicu.DataGridGost.RowCount == 0)
            {
                MessageBox.Show("Gostujući tim nema igrače! Molimo vas da prvo kreirate igrače tima.");
                return;
            }
            Igrac i = dialogUpdateUtakmicu.DataGridGost.CurrentRow.DataBoundItem as Igrac;

            foreach (StatistikaIgraca s in listaStatistikaIgraca)
            {
                if (s.IgracID == i && s.UtakmicaID == u)
                {
                    s.Golovi += 1;

                    gostGolovi--;
                    dialogUpdateUtakmicu.LabelGostStrelac.Text = $"Strelac {strelacGost}. gola gostujuce ekipe je {i.Ime} {i.Prezime}";
                    dialogUpdateUtakmicu.LabelGostStrelac.Visible = true;
                    strelacGost++;
                    if (gostGolovi == 0)
                    {
                        dialogUpdateUtakmicu.BtnGostStrelac.Enabled = false;

                    }
                    return;
                }


            }
            StatistikaIgraca si = new StatistikaIgraca();
            si.IgracID = i;
            si.UtakmicaID = u;
            si.Golovi = 1;
            listaStatistikaIgraca.Add(si);
            gostGolovi--;
            dialogUpdateUtakmicu.LabelGostStrelac.Text = $"Strelac {strelacGost}. gola gostujuce ekipe je {i.Ime} {i.Prezime}";
            dialogUpdateUtakmicu.LabelGostStrelac.Visible = true;
            strelacGost++;
            if (gostGolovi == 0)
            {
                dialogUpdateUtakmicu.BtnGostStrelac.Enabled = false;

            }
        }

        internal void ObradaSignalaDomacinStrelac(Utakmica raspored)
        {
            Utakmica u = raspored;
            if (dialogUpdateUtakmicu.DataGridDomaci.RowCount == 0)
            {
                MessageBox.Show("Domaci tim nema igrače! Molimo vas da prvo kreirate igrače tima.");
                return;
            }
            Igrac i = dialogUpdateUtakmicu.DataGridDomaci.CurrentRow.DataBoundItem as Igrac;

            foreach (StatistikaIgraca s in listaStatistikaIgraca)
            {
                if (s.IgracID == i && s.UtakmicaID == u)
                {
                    s.Golovi += 1;

                    domacinGolovi--;
                    dialogUpdateUtakmicu.LabelDomacinStrelac.Text = $"Strelac {strelacDomaci}. gola domace ekipe je {i.Ime} {i.Prezime}";
                    dialogUpdateUtakmicu.LabelDomacinStrelac.Visible = true;
                    strelacDomaci++;
                    if (domacinGolovi == 0)
                    {
                        dialogUpdateUtakmicu.BtnDomacinStrelac.Enabled = false;

                    }
                    return;
                }


            }
            StatistikaIgraca si = new StatistikaIgraca();
            si.IgracID = i;
            si.UtakmicaID = u;
            si.Golovi = 1;
            listaStatistikaIgraca.Add(si);
            domacinGolovi--;
            dialogUpdateUtakmicu.LabelDomacinStrelac.Text = $"Strelac {strelacDomaci}. gola domaće ekipe je {i.Ime} {i.Prezime}";
            dialogUpdateUtakmicu.LabelDomacinStrelac.Visible = true;
            strelacDomaci++;
            if (domacinGolovi == 0)
            {
                dialogUpdateUtakmicu.BtnDomacinStrelac.Enabled = false;

            }
        }

        internal Utakmica GenerisiDialogUpdateUtakmicuNakonPotvrdeRezultata(Utakmica raspored)
        {
            domacinGolovi = (int)dialogUpdateUtakmicu.NumericDomacin.Value;
            gostGolovi = (int)dialogUpdateUtakmicu.NumericGost.Value;
            raspored.DomacinGolovi = (int)dialogUpdateUtakmicu.NumericDomacin.Value;
            raspored.GostGolovi = (int)dialogUpdateUtakmicu.NumericGost.Value;

            dialogUpdateUtakmicu.BtnSacuvaj.Enabled = true;
            dialogUpdateUtakmicu.BtnDomacinStrelac.Enabled = true;
            dialogUpdateUtakmicu.BtnGostStrelac.Enabled = true;

            dialogUpdateUtakmicu.BtnUnesiRezultat.Enabled = false;
            if (domacinGolovi == 0 && gostGolovi == 0)
            {
                SacuvajRezultatUtakmice(raspored);
                dialogUpdateUtakmicu.Dispose();
            }
            if (domacinGolovi == 0)
            {
                dialogUpdateUtakmicu.BtnDomacinStrelac.Enabled = false;
            }
            if (gostGolovi == 0)
            {
                dialogUpdateUtakmicu.BtnGostStrelac.Enabled = false;
            }
            return raspored;
        }

        internal void InicijalizujDialogUpdateUtakmicu(Utakmica raspored)
        {
            dialogUpdateUtakmicu.LabelDatum.Text = raspored.DatumIVremeOdigravanja.ToString("dd-MM-yyyy HH:mm");
            dialogUpdateUtakmicu.LabelDomacin.Text = raspored.DomacinID.NazivTima;
            dialogUpdateUtakmicu.LabelGost.Text = raspored.GostID.NazivTima;

            domaciIgraci = vratiIgraceTima(raspored.DomacinID);
            gostujuciIgraci = vratiIgraceTima(raspored.GostID);
            dialogUpdateUtakmicu.DataGridDomaci.DataSource = domaciIgraci;
            dialogUpdateUtakmicu.DataGridGost.DataSource = gostujuciIgraci;
            listaStatistikaIgraca = new BindingList<StatistikaIgraca>();


            dialogUpdateUtakmicu.LabelDomacinStrelac.Visible = false;
            dialogUpdateUtakmicu.LabelGostStrelac.Visible = false;
            dialogUpdateUtakmicu.BtnDomacinStrelac.Enabled = false;
            dialogUpdateUtakmicu.BtnGostStrelac.Enabled = false;

            dialogUpdateUtakmicu.DataGridDomaci.Columns[2].Visible = false;
            dialogUpdateUtakmicu.DataGridDomaci.Columns[3].Visible = false;
            dialogUpdateUtakmicu.DataGridDomaci.Columns[4].Visible = false;
            dialogUpdateUtakmicu.DataGridDomaci.Columns[5].Visible = false;

            dialogUpdateUtakmicu.DataGridGost.Columns[2].Visible = false;
            dialogUpdateUtakmicu.DataGridGost.Columns[3].Visible = false;
            dialogUpdateUtakmicu.DataGridGost.Columns[4].Visible = false;
            dialogUpdateUtakmicu.DataGridGost.Columns[5].Visible = false;

            dialogUpdateUtakmicu.BtnSacuvaj.Enabled = false;
            strelacDomaci = 1;
            strelacGost = 1;
        }

       

        internal BindingList<Igrac> vratiIgraceTima(Tim tim)
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuIgraca);
            igraci = new BindingList<Igrac>();
            foreach (Igrac o in lista)
            {
                if (o.TimID.TimID == tim.TimID)
                {
                    igraci.Add(o);
                }
            }
            return igraci;
        }

      

        

        internal void OtvoriDialogUpdateUtakmicu()
        {
            if (uCRaspored.DataGridUtakmice.RowCount == 0)
            {
                MessageBox.Show("Sistem ne moze da ucita utakmicu!");
                return;
            }
            Utakmica raspored = uCRaspored.DataGridUtakmice.CurrentRow.DataBoundItem as Utakmica;
            raspored = (Utakmica)Komunikacija.Komunikacija.Instance.VratiObjekat(Operacije.VratiObjekatUtakmica, (object)raspored)[0];
            if (raspored.UtakmicaID == 0)
            {
                MessageBox.Show("Sistem ne moze da ucita utakmicu!");
                return;
            }
            dialogUpdateUtakmicu = new DialogUpdateUtakmicu(this,raspored);
            dialogUpdateUtakmicu.ShowDialog();
        }

        

       

      

        internal void SacuvajRezultatUtakmice(Utakmica utakmica)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da sačuvate ovaj rezultat?", "Sačuvaj", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            if(domacinGolovi!=0 || gostGolovi != 0)
            {
                MessageBox.Show("Niste uneli strelce za sve golove! Sistem ne moze izmeniti utakmicu.");
                return;
            }
            try
            {
                Utakmica u = new Utakmica()
                {
                    UtakmicaID = utakmica.UtakmicaID,
                    DatumIVremeOdigravanja = utakmica.DatumIVremeOdigravanja,
                    DomacinGolovi = utakmica.DomacinGolovi,
                    GostGolovi = utakmica.GostGolovi,
                    DomacinID = utakmica.DomacinID,
                    GostID = utakmica.GostID,
                    ListaStatistikaIgraca=listaStatistikaIgraca,
                };
                Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniUtakmicu, u);
                //KreirajStatistikeIgraca(listaStatistikaIgraca);
               // UpdateIgraca(listaStatistikaIgraca);
                //UpdateTim(utakmica);
                MessageBox.Show("Sistem je uspešno izmenio podatke o utakmici!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD Izmene Utakmice");
                MessageBox.Show("Sistem ne moze da izmeni podatke o utakmici");
            }
            UcitajUtakmice();
            this.uCRaspored.DataGridUtakmice.DataSource = raspored;
            uCRaspored.TBPretraga.Text = "";
            dialogUpdateUtakmicu.Dispose();
        }
        #endregion
    }
}
