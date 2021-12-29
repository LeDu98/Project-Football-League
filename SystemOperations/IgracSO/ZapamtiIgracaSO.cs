using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.IgracSO
{
    public class ZapamtiIgracaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Igrac igrac = (Igrac)entity;
            igrac.IgracID = repository.VratiID(igrac);
            Result = repository.Sacuvaj(igrac);
            
        }
    }
}
