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
        private Utakmica raspored;

        public Label LabelDatum { get => lblDatum; }
        public Label LabelDomacin { get => lblDomacin; }
        public Label LabelGost { get => lblGost; }
        public Label LabelDomacinStrelac { get => lblDomacinStrelac; }
        public Label LabelGostStrelac { get => lblGostStrelac; }
        public DataGridView DataGridDomaci { get => dgDomacin; }
        public DataGridView DataGridGost { get => dgGost; }
        public Button BtnDomacinStrelac { get => btnDomacinStrelac; }
        public Button BtnGostStrelac { get => btnGostiStrelac; }
        public Button BtnUnesiRezultat { get => btnUnesiRezultat; }
        public Button BtnSacuvaj { get => btnSacuvaj; }
        public NumericUpDown NumericDomacin { get => numericDomacinGolovi; }
        public NumericUpDown NumericGost { get => numericGostGolovi; }

        public DialogUpdateUtakmicu(Kontroleri.KontrolerRaspored kontrolerRaspored, Domen.Utakmica raspored)
        {
            InitializeComponent();
            this.kontrolerRaspored = kontrolerRaspored;
            this.raspored = raspored;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           raspored = kontrolerRaspored.GenerisiDialogUpdateUtakmicuNakonPotvrdeRezultata(raspored);

        }

        private void btnDomacinStrelac_Click(object sender, EventArgs e)
        {
            kontrolerRaspored.ObradaSignalaDomacinStrelac(raspored);
            

        }

        private void btnGostiStrelac_Click(object sender, EventArgs e)
        {
            kontrolerRaspored.ObradaSignalaGostStrelac(raspored);
            
        }

        private void DialogUpdateUtakmicu_Load(object sender, EventArgs e)
        {
            kontrolerRaspored.InicijalizujDialogUpdateUtakmicu(raspored);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
                kontrolerRaspored.SacuvajRezultatUtakmice(raspored);
               
        }
    }
}
