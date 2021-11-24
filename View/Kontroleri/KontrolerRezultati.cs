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

        internal void OtvoriDialogDetaljiOUtakmici(Rezultati rezultat)
        {
            dialogDetaljiOUtakmici = new DialogDetaljiOUtakmici(this);
            
            dialogDetaljiOUtakmici.LabelDomacin.Text = rezultat.DomacinID.NazivTima;
            dialogDetaljiOUtakmici.LabelGost.Text = rezultat.GostID.NazivTima;
            dialogDetaljiOUtakmici.LabelDomacinGolovi.Text = rezultat.DomacinGolovi.ToString();
            dialogDetaljiOUtakmici.LabelGostGolovi.Text = rezultat.GostGolovi.ToString();
            dialogDetaljiOUtakmici.LabelDatum.Text = rezultat.DatumIVremeOdigravanja.ToString("dd.MM.yyyy. HH:mm");

            NapuniListBox(rezultat);

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
                        dialogDetaljiOUtakmici.LabelDomaciStrelci.Text += $"{si.IgracID.Ime} {si.IgracID.Prezime} x {si.Golovi} \n";
                        dialogDetaljiOUtakmici.LBDomaci.Items.Add(si);
                    }
                    if (si.UtakmicaID.GostID.TimID == rezultat.GostID.TimID && si.IgracID.TimID.TimID == rezultat.GostID.TimID)
                    {
                        dialogDetaljiOUtakmici.LabelGostStrelci.Text += $"{si.IgracID.Ime} {si.IgracID.Prezime} x {si.Golovi} \n";
                        dialogDetaljiOUtakmici.LBGosti.Items.Add(si);
                    }
                }
                listaStatistikaIgraca.Add(si);
            }
            

           

        }
    }
}
