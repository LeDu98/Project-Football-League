using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{   [Serializable]
    public class AdministratorLige:IEntity
    {
        public int AdministratorLigeID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string IdName => "AdministratorLigeID";

        public string Tabela => "AdministratorLige";

        public string InsertVrednosti => "";

        public object JoinTabele => "";

        public object UpdateVrednosti => "";

        public object Uslov => $" korisnickoIme like '{KorisnickoIme}' and lozinka like '{Lozinka}'";

        public object UslovVratiListu => "";

        public object OrderBy => "";

        public override string ToString()
        {
            return KorisnickoIme;
        }

        public IEntity VratiEntity(SqlDataReader citac)
        {
            IEntity result = new AdministratorLige();
            while (citac.Read())
            {
                result = new AdministratorLige()
                {
                    AdministratorLigeID = (int)citac["AdministratorLigeID"],
                    Email = (string)citac["Email"],
                    Ime = (string)citac["ime"],
                    Prezime = (string)citac["prezime"],
                    Lozinka = (string)citac["lozinka"],
                    KorisnickoIme = (string)citac["KorisnickoIme"],
                };
            }
            return result;
        }

        public List<IEntity> VratiListu(SqlDataReader citac)
        {
            List<IEntity> result = new List<IEntity>();

            while (citac.Read())
            {
                result.Add(new AdministratorLige()
                {
                    AdministratorLigeID=(int)citac["AdministratorLigeID"],
                    Email=(string)citac["Email"],
                    Ime=(string)citac["ime"],
                    Prezime=(string)citac["prezime"],
                    Lozinka=(string)citac["lozinka"],
                    KorisnickoIme=(string)citac["KorisnickoIme"],
                    


                });
            }
            return result;
        }
    }
}
