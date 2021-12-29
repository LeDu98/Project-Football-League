using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.UtakmicaSO
{
    public class ZapamtiUtakmicuSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Utakmica utakmica = (Utakmica)entity;
            utakmica.UtakmicaID = repository.VratiID(utakmica);
            Result = repository.Sacuvaj(utakmica);
        }
    }
}
