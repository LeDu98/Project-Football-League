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
        private BindingList<Raspored> raspored;
        private DialogKreirajUtakmicu dialogKreirajUtakmicu;
        private DialogUpdateUtakmicu dialogUpdateUtakmicu;
        private BindingList<Tim> timovi;
        private BindingList<Igrac> igraci;
        private BindingList<Igrac> domaciIgraci;
        private BindingList<Igrac> gostujuciIgraci;
        private BindingList<StatistikaIgraca> listaStatistikaIgraca;
        private int domacinGolovi;
        private int gostGolovi;
        private int strelacDomaci = 1;
        private int strelacGost = 1;
        internal void InicijalizujUCRaspored(UCRaspored uCRaspored)
        {
            this.uCRaspored = uCRaspored;

            UcitajUtakmice();
            this.uCRaspored.DataGridUtakmice.DataSource = raspored;
            uCRaspored.DataGridUtakmice.Columns[0].HeaderText = "Termin utakmice";
            uCRaspored.DataGridUtakmice.Columns[1].HeaderText = "Domaći tim";
            uCRaspored.DataGridUtakmice.Columns[2].HeaderText = "Gostujući tim";

        }

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

        internal void Filtriraj()
        {
            uCRaspored.DataGridUtakmice.DataSource = FiltrirajPretragu(uCRaspored.TxtPretraga.Text.ToLower());
            uCRaspored.DataGridUtakmice.Refresh();
        }

        private BindingList<Raspored> FiltrirajPretragu(string tekstPretrage)
        {
            BindingList<Raspored> filtriranRaspored = new BindingList<Raspored>();
            foreach (Raspored r in raspored)
            {
                string domacin = r.DomacinID.NazivTima;
                string gost = r.GostID.NazivTima;
                domacin = domacin.ToLower();
                gost = gost.ToLower();
                if (domacin.Contains(tekstPretrage) || gost.Contains(tekstPretrage))
                {
                    filtriranRaspored.Add(r);

                }
            }
            if (filtriranRaspored.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Sistem ne može da nađe utakmice po zadatoj vrednosti!");
            }
            return filtriranRaspored;
        }

        internal void ObradaSignalaGostStrelac(Raspored raspored)
        {
            Raspored u = raspored;
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

        internal void ObradaSignalaDomacinStrelac(Raspored raspored)
        {
            Raspored u = raspored;
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

        internal Raspored GenerisiDialogUpdateUtakmicuNakonPotvrdeRezultata(Raspored raspored)
        {
            domacinGolovi = (int)dialogUpdateUtakmicu.NumericDomacin.Value;
            gostGolovi = (int)dialogUpdateUtakmicu.NumericGost.Value;
            raspored.DomacinGolovi = (int)dialogUpdateUtakmicu.NumericDomacin.Value;
            raspored.GostGolovi = (int)dialogUpdateUtakmicu.NumericGost.Value;

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

        internal void InicijalizujDialogUpdateUtakmicu(Raspored raspored)
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

            strelacDomaci = 1;
            strelacGost = 1;
        }

        private void UcitajUtakmice()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuUtakmica);
            raspored = new BindingList<Raspored>();
            foreach (object o in lista)
            {
                raspored.Add((Raspored)o);
            }
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

        internal void UpdateUtakmicu(Raspored utakmica)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da sačuvate ovaj rezultat?", "Sačuvaj", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniUtakmicu, utakmica);
                MessageBox.Show("Sistem je uspešno izmenio podatke o utakmici!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD Izmene Utakmice");
               MessageBox.Show("Sistem ne moze da izmeni podatke o utakmici");
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

        internal void OtvoriDialogUpdateUtakmicu()
        {
            Raspored raspored = uCRaspored.DataGridUtakmice.CurrentRow.DataBoundItem as Raspored;
            dialogUpdateUtakmicu = new DialogUpdateUtakmicu(this,raspored);
            dialogUpdateUtakmicu.ShowDialog();
        }

        internal void OtvoriDialogKreirajUtakmicu()
        {
            dialogKreirajUtakmicu = new DialogKreirajUtakmicu(this);
            dialogKreirajUtakmicu.ShowDialog();
        }

        internal void KreirajUtakmicu()
        {
            Tim domacin = dialogKreirajUtakmicu.CbDomacin.SelectedItem as Tim;
            Tim gost= dialogKreirajUtakmicu.CbGost.SelectedItem as Tim;
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

            
            Raspored u = new Raspored()
            {
                DomacinID = domacin,
                GostID = gost,
                DatumIVremeOdigravanja = dialogKreirajUtakmicu.DatumIVreme.Value
                
            };
            Raspored pomocna = (Raspored)Komunikacija.Komunikacija.Instance.Kreiraj(Zajednicki.Operacije.KreirajUtakmicu, u);
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

        internal void KreirajStatistikeIgraca(BindingList<StatistikaIgraca> listaStatistikaIgraca)
        {
            StatistikaIgraca pom = new StatistikaIgraca();
            foreach(StatistikaIgraca si in listaStatistikaIgraca)
            {
                pom = (StatistikaIgraca)Komunikacija.Komunikacija.Instance.Kreiraj(Operacije.KreirajStatistikeIgraca, si);
                if (pom == null)
                {
                    MessageBox.Show("Doslo je do greske prilikom cuvanja statistika");
                    return;
                }
            }
        }

        internal void UpdateIgraca(BindingList<StatistikaIgraca> listaStatistikaIgraca)
        {
            try
            {
                foreach(StatistikaIgraca si in listaStatistikaIgraca)
                {
                    Igrac i = si.IgracID;
                    i.Golovi += si.Golovi;
                Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniIgraca, i);
                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD Izmene IGRACA");
                MessageBox.Show("Sistem ne moze da izmeni podatke o igracima");
            }
        }

        internal void UpdateTim(Raspored utakmica)
        {
            try
            {
                Tim domacin = utakmica.DomacinID;
                Tim gost = utakmica.GostID;
                if (utakmica.DomacinGolovi > utakmica.GostGolovi)
                {
                    domacin.Bodovi += 3;

                    domacin.Pobede += 1;
                    gost.Porazi += 1;

                    Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, domacin);
                    Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, gost);
                    return;
                }
                if (utakmica.DomacinGolovi == utakmica.GostGolovi)
                {
                    domacin.Bodovi += 1;
                    gost.Bodovi += 1;
                    domacin.Neresene += 1;
                    gost.Neresene += 1;

                    Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, domacin);
                    Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, gost);
                    return;
                }
                if(utakmica.DomacinGolovi<utakmica.GostGolovi)
                {
                    gost.Bodovi += 3;

                    gost.Pobede += 1;
                    domacin.Porazi += 1;

                    Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, domacin);
                    Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniTim, gost);
                    return;
                }

                
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD Izmene TIMA");
                MessageBox.Show("Sistem ne moze da izmeni podatke o timu");
            }
        }

        internal void SacuvajRezultatUtakmice(Raspored utakmica)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da sačuvate ovaj rezultat?", "Sačuvaj", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                Komunikacija.Komunikacija.Instance.Update(Operacije.IzmeniUtakmicu, utakmica);
                KreirajStatistikeIgraca(listaStatistikaIgraca);
                UpdateIgraca(listaStatistikaIgraca);
                UpdateTim(utakmica);
                MessageBox.Show("Sistem je uspešno izmenio podatke o utakmici!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD Izmene Utakmice");
                MessageBox.Show("Sistem ne moze da izmeni podatke o utakmici");
            }
            UcitajUtakmice();
            this.uCRaspored.DataGridUtakmice.DataSource = raspored;
        }
    }
}
