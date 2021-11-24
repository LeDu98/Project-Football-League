using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class Raspored:IEntity
    {   [Browsable(false)]
        public int UtakmicaID { get; set; }
        public DateTime DatumIVremeOdigravanja { get; set; }
        public Tim DomacinID { get; set; }
        [Browsable(false)]
        public int DomacinGolovi { get; set; }
        [Browsable(false)]
        public int GostGolovi { get; set; }
        public Tim GostID { get; set; }
        
        
       
      
        [Browsable(false)]
        public bool OdigranaUtakmica { get; set; }
        [Browsable(false)]
        public string IdName => "UtakmicaID";
        [Browsable(false)]
        public string Tabela => "Utakmica";
        [Browsable(false)]
        public string InsertVrednosti => $"{UtakmicaID},'{DatumIVremeOdigravanja}',-1,-1,{DomacinID.TimID},{GostID.TimID}";
        [Browsable(false)]
        public object JoinTabele => " u join Tim d on(u.domacinID = d.timID) join Tim g on (u.gostID = g.timID)";
        [Browsable(false)]
        public object UpdateVrednosti => $"DomacinGolovi = {DomacinGolovi}, GostGolovi = {GostGolovi}";
        [Browsable(false)]
        public object UslovIzmeni => $"utakmicaID = {UtakmicaID}";
        [Browsable(false)]
        public object OrderBy => "order by datumIVremeOdigravanja ASC";
        [Browsable(false)]
        public object UslovVratiListu => "where domacinGolovi = -1 and gostGolovi = -1";

        public IEntity VratiEntity(SqlDataReader citac)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> VratiListu(SqlDataReader citac)
        {
            List<IEntity> result = new List<IEntity>();
            
            while (citac.Read())
            {
                result.Add(new Raspored()
                {
                    UtakmicaID=(int)citac["utakmicaID"],
                    DatumIVremeOdigravanja=(DateTime)citac["DatumIVremeOdigravanja"],
                    DomacinGolovi=(int)citac["DomacinGolovi"],
                    GostGolovi=(int)citac["GostGolovi"],
                    DomacinID=new Tim()
                    {
                        TimID=(int)citac["timId"],
                        NazivTima=(string)citac["NazivTima"],
                        Grad=(string)citac["Grad"],
                        BojaKluba=(string)citac["BojaKluba"],
                        Pobede=(int)citac["Pobede"],
                        Neresene=(int)citac["neresene"],
                        Porazi=(int)citac["porazi"],
                        Bodovi=(int)citac["bodovi"],
                        
                    },
                    GostID= new Tim()
                    {
                        TimID = citac.GetInt32(14),
                        NazivTima = citac.GetString(15),
                        Grad = citac.GetString(16),
                        BojaKluba = citac.GetString(17),
                        Pobede = citac.GetInt32(18),
                        Neresene = citac.GetInt32(19),
                        Porazi = citac.GetInt32(20),
                        Bodovi = citac.GetInt32(21),

                    },


                });
            }
            return result;
        }

        public static implicit operator Raspored(Rezultati v)
        {
            throw new NotImplementedException();
        }
    }
}
