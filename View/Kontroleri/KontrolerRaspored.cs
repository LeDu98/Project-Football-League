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
        internal void InicijalizujUCRaspored(UCRaspored uCRaspored)
        {
            this.uCRaspored = uCRaspored;

            UcitajUtakmice();
            this.uCRaspored.DataGridUtakmice.DataSource = raspored;

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

        internal void OtvoriDialogUpdateUtakmicu(Raspored raspored)
        {
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

        internal void SacuvajRezultatUtakmice(BindingList<StatistikaIgraca> listaStatistikaIgraca, Raspored utakmica)
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
