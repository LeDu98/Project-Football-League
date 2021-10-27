using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class RepositoryAdministratorLige : IRepositoryAdministratorLige
    {
        private List<AdministratorLige> administratori;
        public RepositoryAdministratorLige()
        {
            this.administratori = new List<AdministratorLige>()
            {
                new AdministratorLige()
                {
                    AdministratorLigeID=1,
                    Ime="Dusan",
                    Prezime="Gajic",
                    Email="dusan@gmail.com",
                    KorisnickoIme="dusan",
                    Lozinka="dusan123"
                },
                new AdministratorLige()
                {
                    AdministratorLigeID=2,
                    Ime="Pera",
                    Prezime="Peric",
                    Email="pera@gmail.com",
                    KorisnickoIme="pera",
                    Lozinka="pera123"
                },
                new AdministratorLige()
                {
                    AdministratorLigeID=3,
                    Ime="Ana",
                    Prezime="Anic",
                    Email="ana@gmail.com",
                    KorisnickoIme="ana",
                    Lozinka="ana123"
                },
                new AdministratorLige()
                {
                    AdministratorLigeID=4,
                    Ime="Admin",
                    Prezime="Adminovic",
                    Email="admin@gmail.com",
                    KorisnickoIme="admin",
                    Lozinka="admin123"
                }
            };
        }
        public AdministratorLige Prijavljivanje(AdministratorLige administrator)
        {
            return administratori.Find(a => a.KorisnickoIme == administrator.KorisnickoIme && a.Lozinka == administrator.Lozinka);
        }
    }
}
