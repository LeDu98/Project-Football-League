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

namespace View.Kontroleri
{
    public class KontrolerRezultati
    {
        private UCRezultati uCRezultati;
        private DialogDetaljiOUtakmici dialogDetaljiOUtakmici;
        private BindingList<Rezultati> rezultati;
        private BindingList<StatistikaIgraca> listaStatistikaIgraca;

        internal void InicijalizujUCRezultate(UCRezultati uCRezultati)
        {
            this.uCRezultati = uCRezultati;
            UcitajUtakmice();
            this.uCRezultati.DataGridRezultati.DataSource = rezultati;
            uCRezultati.DataGridRezultati.Columns[0].HeaderText = "Termin utakmice";
            uCRezultati.DataGridRezultati.Columns[1].HeaderText = "Domaći tim";
            uCRezultati.DataGridRezultati.Columns[2].HeaderText = "Golovi";
            uCRezultati.DataGridRezultati.Columns[3].HeaderText = "Golovi";
            uCRezultati.DataGridRezultati.Columns[4].HeaderText = "Gostujući tim";
            
        }

        private void UcitajUtakmice()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuRezultata);
            rezultati = new BindingList<Rezultati>();
            foreach (object o in lista)
            {
                rezultati.Add((Rezultati)o);
            }
        }

        internal void Filtriraj()
        {
            uCRezultati.DataGridRezultati.DataSource = FiltrirajPretragu(uCRezultati.TxtPretraga.Text.ToLower());
            uCRezultati.DataGridRezultati.Refresh();
        }

        private BindingList<Rezultati> FiltrirajPretragu(string tekstPretrage)
        {

            BindingList<Rezultati> FiltriraniRezultati = new BindingList<Rezultati>();
            foreach (Rezultati r in rezultati)
            {
                string domacin = r.DomacinID.NazivTima;
                string gost = r.GostID.NazivTima;
                domacin = domacin.ToLower();
                gost = gost.ToLower();
                if (domacin.Contains(tekstPretrage) || gost.Contains(tekstPretrage))
                {
                    FiltriraniRezultati.Add(r);

                }
            }
            if (FiltriraniRezultati.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Sistem ne može da nađe utakmice po zadatoj vrednosti!");
            }
            return FiltriraniRezultati;
        }

        internal void InicijalizujDialogDetaljiOUtakmici(Rezultati rezultat)
        {
            dialogDetaljiOUtakmici.LabelDomacin.Text = rezultat.DomacinID.NazivTima;
            dialogDetaljiOUtakmici.LabelGost.Text = rezultat.GostID.NazivTima;
            dialogDetaljiOUtakmici.LabelDomacinGolovi.Text = rezultat.DomacinGolovi.ToString();
            dialogDetaljiOUtakmici.LabelGostGolovi.Text = rezultat.GostGolovi.ToString();
            dialogDetaljiOUtakmici.LabelDatum.Text = rezultat.DatumIVremeOdigravanja.ToString("dd.MM.yyyy. HH:mm");

            NapuniListBox(rezultat);
        }

        internal void OtvoriDialogDetaljiOUtakmici()
        {
            Rezultati rezultat = uCRezultati.DataGridRezultati.CurrentRow.DataBoundItem as Rezultati;
            dialogDetaljiOUtakmici = new DialogDetaljiOUtakmici(this,rezultat); 
            dialogDetaljiOUtakmici.ShowDialog();
        }

        private void NapuniListBox(Rezultati rezultat)
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
