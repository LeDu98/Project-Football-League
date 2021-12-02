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
    public partial class DialogDetaljiOUtakmici : Form
    {
       
        private KontrolerRezultati kontrolerRezultati;
        private Utakmica rezultat;

        public Label LabelDomacin { get => lblDomacin; }
        public Label LabelGost { get => lblGost; }
        public Label LabelDomacinGolovi { get => lblDomacinGolovi; }
        public Label LabelGostGolovi { get => lblGostGolovi; }
        public Label LabelDatum { get => lblDatum; }
        public Label LabelDomaciStrelci { get => lblDomaciStrelci; }
        public Label LabelGostStrelci { get => lblGostStrelci; }
        
        public DialogDetaljiOUtakmici(Kontroleri.KontrolerRezultati kontrolerRezultati, Utakmica rezultat)
        {
            InitializeComponent();
            
            this.kontrolerRezultati = kontrolerRezultati;
            this.rezultat = rezultat;
            
        }

        private void DialogDetaljiOUtakmici_Load(object sender, EventArgs e)
        {
            kontrolerRezultati.InicijalizujDialogDetaljiOUtakmici(rezultat);
        }
    }
}
