using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class Tim:IEntity
    {
        [Browsable(false)]
        public int TimID { get; set; }
        [Browsable(false)]
        public int Pozicija { get; set; }
        public string NazivTima { get; set; }
        public string Grad { get; set; }
        public string BojaKluba { get; set; }
        [Browsable(false)]
        public int OdigraneUtakmice { get; set; }
        [Browsable(false)]
        public int Pobede { get; set; }
        [Browsable(false)]
        public int Neresene { get; set; }
        [Browsable(false)]
        public int Porazi { get; set; }
        [Browsable(false)]
        public int Bodovi { get; set; }
        public BindingList<Igrac> ListaIgraca { get; set; }
        public BindingList<StatistikaIgraca> statistikaIgracas { get; set; }
        public BindingList<Utakmica> ListaUtakmica { get; set; }

        public override string ToString()
        {
            return NazivTima;
        }



        [Browsable(false)]
        public string Tabela => "Tim";
        [Browsable(false)]
        public string InsertVrednosti => $"{TimID},'{NazivTima}','{Grad}','{BojaKluba}',{Pobede},{Neresene},{Porazi},{Bodovi}";
        [Browsable(false)]
        public object JoinTabele => "";
        [Browsable(false)]
        public object UpdateVrednosti => $"NazivTima = '{NazivTima}', Grad = '{Grad}', BojaKluba = '{BojaKluba}', Pobede={Pobede}, Neresene={Neresene}, Porazi={Porazi}, Bodovi={Bodovi} ";
        [Browsable(false)]
        public object Uslov => $"TimID = {TimID}";
        [Browsable(false)]
        public object OrderBy => $"order by NazivTima";
        [Browsable(false)]
        public string IdName => "TimID";
        [Browsable(false)]
        public object UslovVratiListu => $"where lower(NazivTima) like '%{NazivTima}%'";

       

        public List<IEntity> VratiListu(SqlDataReader citac)
        {
            List<IEntity> result = new List<IEntity>();
            int x = 1;
            while (citac.Read())
            {
                result.Add(new Tim()
                {
                    TimID = (int)citac["TimID"],
                    Pozicija=x++,
                    NazivTima = (string)citac["NazivTima"],
                    Grad = (string)citac["Grad"],
                    BojaKluba = (string)citac["BojaKluba"],
                    Pobede = (int)citac["Pobede"],
                    Neresene = (int)citac["neresene"],
                    Porazi = (int)citac["porazi"],
                    OdigraneUtakmice= (int)citac["Pobede"]+ (int)citac["neresene"]+ (int)citac["porazi"],
                    Bodovi=(int)citac["bodovi"],

                    
                });
            }
            return result;
        }

        public IEntity VratiEntity(SqlDataReader citac)
        {
            IEntity result = new Tim();
            while (citac.Read())
            {
                result = new Tim()
                {
                    TimID = (int)citac["TimId"],
                    NazivTima=(string)citac["NazivTima"],
                    Grad=(string)citac["Grad"],
                    BojaKluba=(string)citac["BojaKluba"],
                    Pobede=(int)citac["Pobede"],
                    Neresene=(int)citac["neresene"],
                    Porazi=(int)citac["porazi"],
                    Bodovi=(int)citac["bodovi"],
                    OdigraneUtakmice = (int)citac["Pobede"] + (int)citac["neresene"] + (int)citac["porazi"],


                    
                };
            }
            return result;
        }
    }
}
