using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IEntity
    {
        string Tabela { get; }

        string InsertVrednosti { get; }

        object JoinTabele { get; }

        object UpdateVrednosti { get; }

        object Uslov { get; }

        List<IEntity> VratiListu(SqlDataReader citac);
        IEntity VratiEntity(SqlDataReader citac);
    }
}
