using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.IgracSO
{
    public class ObrisiIgracaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Uspelo = repository.Obrisi(entity);
        }
    }
}
