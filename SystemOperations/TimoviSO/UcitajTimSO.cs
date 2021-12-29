using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.TimoviSO
{
    public class UcitajTimSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            List<object> list = new List<object>();
            list.Add((object)repository.VratiEntity(entity));
            ResultList = list;
        }
    }
}
