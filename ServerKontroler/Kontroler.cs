using Domen;
using Repositories;
using Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerKontroler
{
    public class Kontroler
    {
        private static Kontroler instance;
        private Kontroler()
        {
            this.repositoryAdministratorLige = new RepositoryAdministratorLige();
            this.repository = new GenericRepository();
        }
        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                    return instance;
            }
        }

        private IRepositoryAdministratorLige repositoryAdministratorLige;
        private IRepositoryGeneric repository;
        public AdministratorLige administratorLige { get; set; }
        public AdministratorLige Prijavljivanje(AdministratorLige administrator)
        {
            return repositoryAdministratorLige.Prijavljivanje(administrator);
        }

      /*  public List<object> VratiTabelu()
        {
            SystemOperationBase
        }*/
    }
}
