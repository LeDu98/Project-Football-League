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
        private BindingList<Tabela> tabelaTimovi;
        

        internal void InicijalizujUCTabela(UCTabela uCTabela)
        {
            this.uCTabela = uCTabela;
            UcitajTabelu();
            this.uCTabela.DataGridTabela.DataSource = tabelaTimovi;
            uCTabela.DataGridTabela.Columns[1].HeaderText = "Tim";
            uCTabela.DataGridTabela.Columns[2].HeaderText = "Utakmice";
            uCTabela.DataGridTabela.Columns[4].HeaderText = "Nerešene";
        }

        private void UcitajTabelu()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Operacije.VratiTabelu);
            tabelaTimovi = new BindingList<Tabela>();
            foreach(object o in lista)
            {
                
                tabelaTimovi.Add((Tabela)o);
            }
        }
    }
}
