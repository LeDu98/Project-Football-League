using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Kontroleri;

namespace View.Dialogs.Utakmice
{
    public partial class DialogUpdateUtakmicu : Form
    {
        private KontrolerRaspored kontrolerRaspored;
        private Raspored utakmica;
        private int domacinGolovi;
        private int gostGolovi;
        private BindingList<Igrac> listaDomacih;
        private BindingList<Igrac> listaGostiju;
        private BindingList<StatistikaIgraca> listaStatistikaIgraca;
        private int strelacDomaci = 1;
        private int strelacGost = 1;

        public DialogUpdateUtakmicu(Kontroleri.KontrolerRaspored kontrolerRaspored, Domen.Raspored raspored)
        {
            InitializeComponent();
            this.kontrolerRaspored = kontrolerRaspored;
            lblDatum.Text = raspored.DatumIVremeOdigravanja.ToString("dd-MM-yyyy HH:mm");
            lblDomacin.Text = raspored.DomacinID.NazivTima;
            lblGost.Text = raspored.GostID.NazivTima;
            utakmica = raspored;
            listaDomacih = kontrolerRaspored.vratiIgraceTima(raspored.DomacinID);
            listaGostiju = kontrolerRaspored.vratiIgraceTima(raspored.GostID);
            dgDomacin.DataSource = listaDomacih;
            dgGost.DataSource = listaGostiju;
            listaStatistikaIgraca = new BindingList<StatistikaIgraca>();
            lblDomacinStrelac.Visible = false;
            lblGostStrelac.Visible = false;
            btnDomacinStrelac.Enabled = false;
            btnGostiStrelac.Enabled = false;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            domacinGolovi = (int)numericDomacinGolovi.Value;
            gostGolovi = (int)numericGostGolovi.Value;
            utakmica.DomacinGolovi = (int)numericDomacinGolovi.Value;
            utakmica.GostGolovi = (int)numericGostGolovi.Value;

            btnDomacinStrelac.Enabled = true;
            btnGostiStrelac.Enabled = true;

            btnUnesiRezultat.Enabled = false;
            if (domacinGolovi == 0 && gostGolovi == 0)
            {
                kontrolerRaspored.SacuvajRezultatUtakmice(listaStatistikaIgraca, utakmica);
                this.Dispose();
            }
            if (domacinGolovi == 0)
            {
                btnDomacinStrelac.Enabled = false;
            }
            if (gostGolovi == 0)
            {
                btnGostiStrelac.Enabled = false;
            }

        }

        private void btnDomacinStrelac_Click(object sender, EventArgs e)
        {

            Raspored u = utakmica;
            Igrac i = dgDomacin.CurrentRow.DataBoundItem as Igrac;

            foreach (StatistikaIgraca s in listaStatistikaIgraca)
            {
                if (s.IgracID == i && s.UtakmicaID == u)
                {
                    s.Golovi += 1;

                    domacinGolovi--;
                    lblDomacinStrelac.Text = $"Strelac {strelacDomaci}. gola domace ekipe je {i.Ime} {i.Prezime}";
                    lblDomacinStrelac.Visible = true;
                    strelacDomaci++;
                    if (domacinGolovi == 0)
                    {
                        btnDomacinStrelac.Enabled = false;

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
            lblDomacinStrelac.Text = $"Strelac {strelacDomaci}. gola domace ekipe je {i.Ime} {i.Prezime}";
            lblDomacinStrelac.Visible = true;
            strelacDomaci++;
            if (domacinGolovi == 0)
            {
                btnDomacinStrelac.Enabled = false;

            }

        }

        private void btnGostiStrelac_Click(object sender, EventArgs e)
        {
            Raspored u = utakmica;
            Igrac i = dgGost.CurrentRow.DataBoundItem as Igrac;




            foreach (StatistikaIgraca s in listaStatistikaIgraca)
            {
                if (s.IgracID == i && s.UtakmicaID == u)
                {
                    s.Golovi += 1;

                    gostGolovi--;
                    lblGostStrelac.Text = $"Strelac {strelacGost}. gola gostujuce ekipe je {i.Ime} {i.Prezime}";
                    lblGostStrelac.Visible = true;
                    strelacGost++;
                    if (gostGolovi == 0)
                    {
                        btnGostiStrelac.Enabled = false;

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
            lblGostStrelac.Text = $"Strelac {strelacGost}. gola gostujuce ekipe je {i.Ime} {i.Prezime}";
            lblGostStrelac.Visible = true;
            strelacGost++;
            if (gostGolovi == 0)
            {
                btnGostiStrelac.Enabled = false;

            }
        }



        private void DialogUpdateUtakmicu_Load(object sender, EventArgs e)
        {

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            foreach (StatistikaIgraca si in listaStatistikaIgraca)
            {

                kontrolerRaspored.SacuvajRezultatUtakmice(listaStatistikaIgraca, utakmica);

                this.Dispose();
            }
        }
    }
}
