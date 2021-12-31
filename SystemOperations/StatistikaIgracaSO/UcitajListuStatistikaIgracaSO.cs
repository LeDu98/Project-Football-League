using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.StatistikaIgracaSO
{
    public class UcitajListuStatistikaIgracaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            try
            {
                ResultList = repository.VratiListu(new StatistikaIgraca()).Cast<object>().ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
