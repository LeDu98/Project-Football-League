using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.StatistikaIgracaSO
{
    public class ObrisiStatistikuIgracaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Uspelo = repository.Obrisi(entity);
        }
    }
}
