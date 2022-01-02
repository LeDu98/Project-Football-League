using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class Igrac:IEntity
    {
        [Browsable(false)]
        public int IgracID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
        public int Golovi { get; set; }
      
        public Drzava DrzavaID { get; set; }
       
        public Tim TimID { get; set; }
        [Browsable(false)]
        public BindingList<StatistikaIgraca> ListaStatistika { get; set; }
        public override string ToString()
        {
            return IgracID + "_" + Ime + " " + Prezime + "_";
        }


        [Browsable(false)]
        public string IdName => "IgracID";
        [Browsable(false)]
        public string Tabela => "Igrac";
        [Browsable(false)]
        public string InsertVrednosti => $"{IgracID},'{Ime}','{Prezime}','{Pozicija}',{Golovi},{DrzavaID.DrzavaID},{TimID.TimID}";
        [Browsable(false)]
        public object JoinTabele => " i join Drzava d on (i.DrzavaId = d.DrzavaId) join Tim t on (i.TimId = t.TimId)";
        [Browsable(false)]
        public object UpdateVrednosti => $"Ime='{Ime}',Prezime='{Prezime}',Pozicija='{Pozicija}', Golovi={Golovi}, DrzavaId={DrzavaID.DrzavaID}, TimId={TimID.TimID} ";
        [Browsable(false)]
        public object Uslov => $"IgracId={IgracID}";
        [Browsable(false)]
        public object OrderBy => "";
        [Browsable(false)]
        public object UslovVratiListu => $"where lower(concat(ime,prezime)) like '%{Ime}%' or lower(concat(prezime,ime)) like '%{Ime}%'";
        

        public IEntity VratiEntity(SqlDataReader citac)
        {
            IEntity result = new Igrac();
            while (citac.Read())
            {
                result = new Igrac()
                {
                    IgracID = (int)citac["IgracID"],
                    Ime = (string)citac["Ime"],
                    Prezime = (string)citac["Prezime"],
                    Pozicija = (string)citac["Pozicija"],
                    Golovi = (int)citac["Golovi"],
                    TimID = new Tim()
                    {
                        TimID = (int)citac["TimID"],
                        NazivTima = (string)citac["NazivTima"],

                    },

                    DrzavaID = new Drzava()
                    {
                        DrzavaID = (int)citac["DrzavaId"],
                        NazivDrzave = (string)citac["NazivDrzave"],
                    },

                };
            }
            return result;
        }

        public List<IEntity> VratiListu(SqlDataReader citac)
        {

            List<IEntity> result = new List<IEntity>();
            
            while (citac.Read())
            {
                result.Add(new Igrac()
                {
                   IgracID=(int)citac["IgracID"],
                   Ime=(string)citac["Ime"],
                   Prezime=(string)citac["Prezime"],
                   Pozicija=(string)citac["Pozicija"],
                   Golovi=(int)citac["Golovi"],
                   TimID= new Tim()
                   {
                       TimID = (int)citac["TimID"],
                       NazivTima=(string)citac["NazivTima"],
                       
                   },
                    
                   DrzavaID=new Drzava()
                   {
                       DrzavaID=(int)citac["DrzavaId"],
                       NazivDrzave=(string)citac["NazivDrzave"],
                   },
                   

                });
            }
            return result;
        }
    }
}
