using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.UtakmicaSO
{
    public class IzmeniUtakmicuSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Utakmica utakmica = entity as Utakmica;
            BindingList<StatistikaIgraca> listaStatistikaIgraca = utakmica.ListaStatistikaIgraca;
            bool pomocna;
            foreach (StatistikaIgraca si in listaStatistikaIgraca)
            {
                
                Result=(repository.Sacuvaj(si));

                Igrac igrac = si.IgracID;
                igrac.Golovi += si.Golovi;
                pomocna= repository.Izmeni(igrac);
                

            }

            bool izmenaDomacina;
            bool izmenaGosta;

            Tim domacin = utakmica.DomacinID;
            Tim gost = utakmica.GostID;
            if (utakmica.DomacinGolovi > utakmica.GostGolovi)
            {
                domacin.Bodovi += 3;

                domacin.Pobede += 1;
                gost.Porazi += 1;

                izmenaDomacina = repository.Izmeni(domacin);
                izmenaGosta = repository.Izmeni(gost);
                
            }
            if (utakmica.DomacinGolovi == utakmica.GostGolovi)
            {
                domacin.Bodovi += 1;
                gost.Bodovi += 1;
                domacin.Neresene += 1;
                gost.Neresene += 1;

                izmenaDomacina = repository.Izmeni(domacin);
                izmenaGosta = repository.Izmeni(gost);
                
            }
            if (utakmica.DomacinGolovi < utakmica.GostGolovi)
            {
                gost.Bodovi += 3;

                gost.Pobede += 1;
                domacin.Porazi += 1;

                izmenaDomacina = repository.Izmeni(domacin);
                izmenaGosta = repository.Izmeni(gost);
                
            }





            Uspelo = repository.Izmeni(entity);
        }
    }
}
