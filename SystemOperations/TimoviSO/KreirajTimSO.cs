using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.TimoviSO
{
    public class KreirajTimSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Tim tim = (Tim)entity;
            tim.TimID = repository.VratiID(tim); 
            Result = repository.Sacuvaj(tim);
        }
    }
}
