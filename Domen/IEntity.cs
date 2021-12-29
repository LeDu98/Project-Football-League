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
        string IdName { get; }
        string Tabela { get; }

        string InsertVrednosti { get; }

        object JoinTabele { get; }

        object UpdateVrednosti { get; }

        object Uslov { get; }
        object UslovVratiListu { get; }
        object OrderBy { get; }

        List<IEntity> VratiListu(SqlDataReader citac);
        IEntity VratiEntity(SqlDataReader reader);

    }
}
