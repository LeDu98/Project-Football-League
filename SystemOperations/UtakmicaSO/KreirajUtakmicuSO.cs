using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.UtakmicaSO
{
    public class KreirajUtakmicuSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Raspored utakmica = (Raspored)entity;
            utakmica.UtakmicaID = repository.VratiID(utakmica);
            Result = repository.Sacuvaj(utakmica);
        }
    }
}
