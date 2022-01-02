using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class Drzava:IEntity
    {
        public int DrzavaID { get; set; }
        public string NazivDrzave { get; set; }

        public override string ToString()
        {
            return NazivDrzave;
        }

        public string IdName => "DrzavaID";

        public string Tabela => "Drzava";

        public string InsertVrednosti => $"{DrzavaID},'{NazivDrzave}'";

        public object JoinTabele => "";

        public object UpdateVrednosti => $"NazivDrzave='{NazivDrzave}'";

        public object Uslov => "";

        public object OrderBy => "";

        public object UslovVratiListu => "";

       

        public IEntity VratiEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> VratiListu(SqlDataReader citac)
        {

            List<IEntity> result = new List<IEntity>();
            
            while (citac.Read())
            {
                result.Add(new Drzava()
                {
                    DrzavaID=(int)citac["DrzavaID"],
                    NazivDrzave=(string)citac["NazivDrzave"],


                });
            }
            return result;
        }
    }
}
