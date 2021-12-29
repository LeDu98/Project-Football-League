using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.IgracSO
{
    public class ObrisiIgracaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Igrac igrac = entity as Igrac;

            foreach(StatistikaIgraca si in igrac.ListaStatistika)
            {
                bool obrisanaStatistika = repository.Obrisi(si);
            }

            Uspelo = repository.Obrisi(entity);
        }
    }
}
