using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.UtakmicaSO
{
    public class PretraziUtakmiceSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            try
            {
                ResultList = repository.Pretrazi(entity).Cast<object>().ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
