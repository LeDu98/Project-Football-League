using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.TimoviSO
{
    public class UcitajListuTimovaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            
            {
                try
                {
                    ResultList = repository.VratiListu(new Tim()).Cast<object>().ToList();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
            }
            
            
        }
    }
}
