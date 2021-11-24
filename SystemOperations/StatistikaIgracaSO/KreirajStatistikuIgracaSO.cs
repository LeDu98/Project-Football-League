using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.StatistikaIgracaSO
{
    public class KreirajStatistikuIgracaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            StatistikaIgraca statistikaIgraca = (StatistikaIgraca)entity;
            
           
            Result = repository.Sacuvaj(statistikaIgraca);
        }
    }
}
