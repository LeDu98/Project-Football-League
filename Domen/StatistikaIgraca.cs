using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class StatistikaIgraca:IEntity
    {
     
        public Raspored UtakmicaID { get; set; }
        public Igrac IgracID { get; set; }
        public int Golovi { get; set; }
        public string Prikaz => $"{IgracID.Ime} {IgracID.Prezime} : {Golovi}";


        public string IdName => "UtakmicaID";

        public string Tabela => "StatistikaIgraca";

        public string InsertVrednosti => $"{UtakmicaID.UtakmicaID},{IgracID.IgracID},{Golovi}";
        public object JoinTabele => " si join Utakmica u on (si.UtakmicaID = u.UtakmicaID) join Igrac i on (si.IgracID = i.IgracID) ";

        public object UpdateVrednosti => $"Golovi={Golovi}";

        public object UslovIzmeni => "";

        public object UslovVratiListu => "";

        public object OrderBy => "";

        public override string ToString()
        {
            return IgracID.Ime + " " + IgracID.Prezime + " x " + Golovi;
        }

        public IEntity VratiEntity(SqlDataReader citac)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> VratiListu(SqlDataReader citac)
        {
            List<IEntity> result = new List<IEntity>();

            while (citac.Read())
            {
                result.Add(new StatistikaIgraca()
                {
                   UtakmicaID= new Raspored()
                   {
                       UtakmicaID = (int)citac["utakmicaID"],
                       DatumIVremeOdigravanja=(DateTime)citac["DatumIVremeOdigravanja"],
                       DomacinGolovi=(int)citac["DomacinGolovi"],
                       GostGolovi=(int)citac["GostGolovi"],
                       DomacinID=new Tim()
                       {
                           TimID = citac.GetInt32(7),

                       },
                       GostID=new Tim()
                       {
                           TimID= citac.GetInt32(8),
                       }
                      
                       },
                   IgracID=new Igrac()
                   {
                       IgracID=(int)citac["igracID"],
                       Ime = (string)citac["Ime"],
                       Prezime = (string)citac["Prezime"],
                       DrzavaID = new Drzava
                       {
                           DrzavaID = citac.GetInt32(14),
                       },
                       TimID =new Tim()
                       {
                           TimID=citac.GetInt32(15),
                       },
                       
                       
                   },
                   Golovi=(int)citac["Golovi"],


                   });
            }
            return result;
        }
    }
}
