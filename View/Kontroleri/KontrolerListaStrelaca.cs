using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Dialogs.Igraci;
using View.UserControls;
using Zajednicki;

namespace View.Kontroleri
{
    public class KontrolerListaStrelaca
    {
        private UCListaStrelaca uCListaStrelaca;
        private BindingList<ListaStrelaca> listaStrelaca;
       

        #region UCListaStrelaca
        internal void InicijalizujUCListaStrelaca(UCListaStrelaca uCListaStrelaca)
        {
            this.uCListaStrelaca = uCListaStrelaca;
            UcitajListuStrelaca();
            this.uCListaStrelaca.DataGridListaStrelaca.DataSource = listaStrelaca;

            uCListaStrelaca.DataGridListaStrelaca.Columns[4].HeaderText = "Država";
            uCListaStrelaca.DataGridListaStrelaca.Columns[5].HeaderText = "Tim";
        }

        private void UcitajListuStrelaca()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Operacije.VratiListuStrelaca);
            listaStrelaca = new BindingList<ListaStrelaca>();
            foreach (object o in lista)
            {

                listaStrelaca.Add((ListaStrelaca)o);
            }
        }

        #endregion

       
    }
}
