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
    public class KontrolerRezultati
    {
        private UCRezultati uCRezultati;
        private DialogDetaljiOUtakmici dialogDetaljiOUtakmici;
        private BindingList<Utakmica> utakmice;
        private BindingList<StatistikaIgraca> listaStatistikaIgraca;

        private BindingList<Utakmica> filtriraneUtakmice;

      

        internal void InicijalizujUCRezultate(UCRezultati uCRezultati)
        {
            this.uCRezultati = uCRezultati;
            UcitajUtakmice();
            this.uCRezultati.DataGridRezultati.DataSource = utakmice;
            
            
            
            uCRezultati.DataGridRezultati.Columns[0].HeaderText = "Termin";
            uCRezultati.DataGridRezultati.Columns[1].HeaderText = "Domaći tim";
            uCRezultati.DataGridRezultati.Columns[2].HeaderText = "Golovi";
            uCRezultati.DataGridRezultati.Columns[3].HeaderText = "Golovi";
            uCRezultati.DataGridRezultati.Columns[4].HeaderText = "Gostujući tim";
            
        }

      

        private void UcitajUtakmice()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuUtakmica);
            utakmice = new BindingList<Utakmica>();
            if (lista == null)
            {
                return;
            }
            foreach (Utakmica o in lista)
            {
                if(o.DomacinGolovi!=-1 && o.GostGolovi  != -1)
                {
                utakmice.Add(o);

                }
            }
        }

        internal void ObrisiUtakmicu()
        {
            var result = System.Windows.Forms.MessageBox.Show("Ukoliko potvrdite, pored obrisane utakmice će se obrisati i sve statistike igrača na utakmici. Da li ste sigurni da želite da obrišete utakmicu?", "Obriši", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            try
            {
                Utakmica utakmica = uCRezultati.DataGridRezultati.CurrentRow.DataBoundItem as Utakmica;

                Komunikacija.Komunikacija.Instance.Obrisi(Operacije.ObrisiUtakmicu, utakmica);
                utakmice.Remove(utakmica);
                System.Windows.Forms.MessageBox.Show("Sistem je obrisao utakmicu");
                UcitajUtakmice();
                this.uCRezultati.DataGridRezultati.DataSource = utakmice;
            }
            catch (Exception e)
            {

                Console.WriteLine(e + "EXCEPTION KOD BRISANJA UTAKMICE");
                System.Windows.Forms.MessageBox.Show("Sistem ne moze da obrise utakmicu");
            }
        }

        internal void Filtriraj()
        {
          
            uCRezultati.DataGridRezultati.DataSource = FiltrirajPretragu(uCRezultati.TBPretraga.Text.ToLower());
            uCRezultati.DataGridRezultati.Refresh();
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
                    if(u.DomacinGolovi!=-1 && u.GostGolovi != -1)
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

        internal void InicijalizujDialogDetaljiOUtakmici(Utakmica rezultat)
        {
            dialogDetaljiOUtakmici.LabelDomacin.Text = rezultat.DomacinID.NazivTima;
            dialogDetaljiOUtakmici.LabelGost.Text = rezultat.GostID.NazivTima;
            dialogDetaljiOUtakmici.LabelDomacinGolovi.Text = rezultat.DomacinGolovi.ToString();
            dialogDetaljiOUtakmici.LabelGostGolovi.Text = rezultat.GostGolovi.ToString();
            dialogDetaljiOUtakmici.LabelDatum.Text = rezultat.DatumIVremeOdigravanja.ToString("dd.MM.yyyy. HH:mm");

            VratiStatistikeIgracaUtakmice(rezultat);
        }

        internal void OtvoriDialogDetaljiOUtakmici()
        {
            if (uCRezultati.DataGridRezultati.RowCount == 0)
            {
                MessageBox.Show("Sistem ne moze da ucita utakmicu");
                return;
            }
            Utakmica rezultat = uCRezultati.DataGridRezultati.CurrentRow.DataBoundItem as Utakmica;
            rezultat=(Utakmica)Komunikacija.Komunikacija.Instance.VratiObjekat(Operacije.VratiObjekatUtakmica, (object)rezultat)[0];
            if (rezultat.UtakmicaID == 0)
            {
                MessageBox.Show("Sistem ne moze da ucita utakmicu!");
                return;
            }
            dialogDetaljiOUtakmici = new DialogDetaljiOUtakmici(this,rezultat); 
            dialogDetaljiOUtakmici.ShowDialog();
        }

        private void VratiStatistikeIgracaUtakmice(Utakmica rezultat)
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuStatistikaIgraca);
            listaStatistikaIgraca = new BindingList<StatistikaIgraca>();
            foreach (StatistikaIgraca si in lista)
            {
                Console.WriteLine(si.UtakmicaID.UtakmicaID);
                Console.WriteLine(rezultat.UtakmicaID);
                if (si.UtakmicaID.UtakmicaID == rezultat.UtakmicaID)
                {
                    Console.WriteLine(si.UtakmicaID.DomacinID.TimID);
                    Console.WriteLine(rezultat.DomacinID.TimID);
                    
                    if (si.UtakmicaID.DomacinID.TimID == rezultat.DomacinID.TimID && si.IgracID.TimID.TimID==rezultat.DomacinID.TimID)
                    {
                        Console.WriteLine($"{si.IgracID.Ime} {si.IgracID.Prezime} : {si.Golovi} \n");
                        dialogDetaljiOUtakmici.LabelDomaciStrelci.Text += $"{si.IgracID.Ime} {si.IgracID.Prezime} x {si.Golovi}, ";
                        
                    }
                    if (si.UtakmicaID.GostID.TimID == rezultat.GostID.TimID && si.IgracID.TimID.TimID == rezultat.GostID.TimID)
                    {
                        dialogDetaljiOUtakmici.LabelGostStrelci.Text += $"{si.IgracID.Ime} {si.IgracID.Prezime} x {si.Golovi}, ";
                        
                    }
                }
                listaStatistikaIgraca.Add(si);
            }
            if (dialogDetaljiOUtakmici.LabelDomaciStrelci.Text == "(")
            {
                dialogDetaljiOUtakmici.LabelDomaciStrelci.Text = "";
            }
            else
            {
                string s1 = dialogDetaljiOUtakmici.LabelDomaciStrelci.Text;
                dialogDetaljiOUtakmici.LabelDomaciStrelci.Text = s1.Substring(0, s1.Length - 2);
                dialogDetaljiOUtakmici.LabelDomaciStrelci.Text += ")";
            }
            if (dialogDetaljiOUtakmici.LabelGostStrelci.Text == "(")
            {
                dialogDetaljiOUtakmici.LabelGostStrelci.Text = "";
            }
            else
            {
                string s2 = dialogDetaljiOUtakmici.LabelGostStrelci.Text;
                dialogDetaljiOUtakmici.LabelGostStrelci.Text = s2.Substring(0, s2.Length - 2);
                dialogDetaljiOUtakmici.LabelGostStrelci.Text += ")";
            }
            
            

            
            

        }
    }
}
