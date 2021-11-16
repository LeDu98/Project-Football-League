﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Kontroleri;

namespace View.Dialogs.Timovi
{
    public partial class DialogKreirajTim : Form
    {
        private KontrolerTimovi kontrolerTimovi;
        public TextBox TxtNaziv { get => txtNaziv; }
        public TextBox TxtGrad { get => txtGrad; }
        public TextBox TxtBojaKluba { get => txtBojaKluba; }
        public TextBox TxtPobede { get => txtPobede; }
        public TextBox TxtNeresene { get => txtNeresene; }
        public TextBox TxtPorazi { get => txtPorazi; }
        public DialogKreirajTim(Kontroleri.KontrolerTimovi kontrolerTimovi)
        {
            InitializeComponent();
            this.kontrolerTimovi = kontrolerTimovi;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            kontrolerTimovi.DodajTim();
        }
    }
}
