using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class Utakmica:IEntity
    {   [Browsable(false)]
        public int UtakmicaID { get; set; }
        public Tim DomacinID { get; set; }
        public int DomacinGolovi { get; set; }
        public int GostGolovi { get; set; }
        public Tim GostID { get; set; }
        public DateTime DatumIVremeOdigravanja { get; set; }
        
       
      
        [Browsable(false)]
        public bool OdigranaUtakmica { get; set; }
        [Browsable(false)]
        public string IdName => "UtakmicaID";
        [Browsable(false)]
        public string Tabela => "Utakmica";
        [Browsable(false)]
        public string InsertVrednosti => $"{UtakmicaID},'{DatumIVremeOdigravanja}',999,999,{DomacinID.TimID},{GostID.TimID}";
        [Browsable(false)]
        public object JoinTabele => " u join Tim d on(u.domacinID = d.timID) join Tim g on (u.gostID = g.timID)";
        [Browsable(false)]
        public object UpdateVrednosti => "";
        [Browsable(false)]
        public object Uslov => "";
        [Browsable(false)]
        public object OrderBy => "";

        public IEntity VratiEntity(SqlDataReader citac)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> VratiListu(SqlDataReader citac)
        {
            List<IEntity> result = new List<IEntity>();
            
            while (citac.Read())
            {
                result.Add(new Utakmica()
                {
                    UtakmicaID=(int)citac["utakmicaID"],
                    DatumIVremeOdigravanja=(DateTime)citac["DatumIVremeOdigravanja"],
                    DomacinGolovi=(int)citac["DomacinGolovi"],
                    GostGolovi=(int)citac["GostGolovi"],
                    DomacinID=new Tim()
                    {
                        TimID=(int)citac["timId"],
                        NazivTima=(string)citac["NazivTima"],
                        
                    },
                    GostID= new Tim()
                    {
                        TimID = citac.GetInt32(14),
                        NazivTima = citac.GetString(15),

                    },


                });
            }
            return result;
        }
    }
}
