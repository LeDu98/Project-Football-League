using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
   public class Tabela:IEntity
    {
        [Browsable(false)]
        public int TimID { get; set; }
        public int Pozicija { get; set; }
        public string Naziv { get; set; }
        [Browsable(false)]
        public string Grad { get; set; }
        [Browsable(false)]
        public string BojaKluba { get; set; }
       
        public int OdigraneUtakmice { get; set; }

        public int Pobede { get; set; }
       
        public int Neresene { get; set; }
       
        public int Porazi { get; set; }
        
        public int Bodovi { get; set; }
        [Browsable(false)]
        public List<Igrac> ListaIgraca { get; set; }

        
        [Browsable(false)]
        public string InsertVrednosti => $"'{Naziv}','{Grad}','{BojaKluba}',{Pobede},{Neresene},{Porazi},{Bodovi}";
        [Browsable(false)]
        public object JoinTabele => "";
        [Browsable(false)]
        public object UpdateVrednosti => $"NazivTima = '{Naziv}', Grad = '{Grad}', BojaKluba = '{BojaKluba}', Pobede = {Pobede}, Neresene = {Neresene}, Porazi = {Porazi}, Bodovi={Bodovi}";
        [Browsable(false)]
        public object Uslov => $"TimID = {TimID}";
        [Browsable(false)]
        public object OrderBy => $"order by Bodovi DESC";
        [Browsable(false)]
        public string IdName => "TimID";
        [Browsable(false)]
        public object UslovVratiListu => "";

        [Browsable(false)]
        string IEntity.Tabela => "Tim";

        public IEntity VratiEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> VratiListu(SqlDataReader citac)
        {
            List<IEntity> result = new List<IEntity>();
            int x = 1;
            while (citac.Read())
            {
                result.Add(new Tabela()
                {
                    TimID = (int)citac["TimID"],
                    Pozicija = x++,
                    Naziv = (string)citac["NazivTima"],
                    Grad = (string)citac["Grad"],
                    BojaKluba = (string)citac["BojaKluba"],
                    Pobede = (int)citac["Pobede"],
                    Neresene = (int)citac["neresene"],
                    Porazi = (int)citac["porazi"],
                    Bodovi = (int)citac["bodovi"],
                    OdigraneUtakmice= (int)citac["Pobede"]+ (int)citac["neresene"]+ (int)citac["porazi"],

                }); 
            }
            return result;
        }
    }
}
