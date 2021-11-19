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
   public class KontrolerUtakmice
    {
        UCUtakmice uCUtakmice;
        private BindingList<Utakmica> utakmice;
        private DialogKreirajUtakmicu dialogKreirajUtakmicu;

        internal void InicijalizujUCUtakmice(UCUtakmice uCUtakmice)
        {
            this.uCUtakmice = uCUtakmice;
            UcitajUtakmice();
            this.uCUtakmice.DataGridUtakmice.DataSource = utakmice;
        }

        private void UcitajUtakmice()
        {
            List<object> lista = Komunikacija.Komunikacija.Instance.VratiListu(Zajednicki.Operacije.VratiListuUtakmica);
            utakmice = new BindingList<Utakmica>();
            foreach (object o in lista)
            {
                utakmice.Add((Utakmica)o);
            }
        }

      

        internal void OtvoriDialogKreirajUtakmicu(BindingList<Tim> listaTimova)
        {
            dialogKreirajUtakmicu = new DialogKreirajUtakmicu(this,listaTimova);
            dialogKreirajUtakmicu.ShowDialog();
        }

        internal void KreirajUtakmicu(ComboBox cmbDomacin, ComboBox cmbGost, DateTimePicker dateTimePicker1)
        {
            
                Tim domacin = cmbDomacin.SelectedItem as Tim;
                Tim gost = cmbGost.SelectedItem as Tim;
                if(domacin==null || gost == null)
                {
                    MessageBox.Show("Niste selektovali validne vrednosti!");
                    return;
                }
                if (domacin == gost)
                {
                    MessageBox.Show("Ne mozete selektovati dva ista tima");
                    return;
                }


            Utakmica u = new Utakmica()
            {
                DomacinID = domacin,
                GostID = gost,
                DatumIVremeOdigravanja = dateTimePicker1.Value

            };
            Console.WriteLine(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine(dateTimePicker1.Value.GetDateTimeFormats());

            bool uspesno = (bool)Komunikacija.Komunikacija.Instance.Kreiraj(Zajednicki.Operacije.KreirajUtakmicu, u);
            if (uspesno != false)
            {
                MessageBox.Show("Sistem je zapamtio novu utakmicu!");
                utakmice.Add(u);
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti novu utakmicu!");
            }
        }
    }
}
