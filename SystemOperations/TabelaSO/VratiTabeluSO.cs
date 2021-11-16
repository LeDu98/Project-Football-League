using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.TabelaSO
{
    public class VratiTabeluSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            ResultList = repository.VratiListu(new Tabela()).Cast<object>().ToList();
        }
    }
}
