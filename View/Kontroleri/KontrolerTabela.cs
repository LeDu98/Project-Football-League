using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.UserControls;
using Zajednicki;

namespace View.Kontroleri
{
    public class KontrolerTabela
    {
        private UCTabela uCTabela;
        private BindingList<Tim> timovi;
        private Tim selektovanTim;

        internal void InicijalizujUCTabela(UCTabela uCTabela)
        {
            this.uCTabela = uCTabela;
            UcitajTabelu();
            this.uCTabela.DataGridTabela.DataSource = timovi;
        }

        private void UcitajTabelu()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Operacije.VratiTabelu);
            timovi = new BindingList<Tim>();
            foreach(object o in lista)
            {
                //asafasf
                timovi.Add((Tim)o);
            }
        }
    }
}
