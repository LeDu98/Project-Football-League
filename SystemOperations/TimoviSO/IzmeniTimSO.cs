using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.TimoviSO
{
    public class IzmeniTimSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Uspelo = repository.Izmeni(entity);
        }
    }
}
