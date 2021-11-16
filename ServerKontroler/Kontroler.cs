using Domen;
using Repositories;
using Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
using SystemOperations.TabelaSO;
using SystemOperations.TimoviSO;

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

        public List<object> VratiTabelu()
        {
            SystemOperationsBase systemOperation = new VratiTabeluSO();
            systemOperation.ExecuteTemplate(new Tabela());
            return systemOperation.ResultList;
        }

        public List<object> VratiTimove()
        {
            SystemOperationsBase systemOperation = new VratiTimoveSO();
            systemOperation.ExecuteTemplate(new Tim());
            return systemOperation.ResultList;
        }

        public object KreirajTim(Tim tim)
        {
            SystemOperationsBase systemOperation = new KreirajTimSO();
            systemOperation.ExecuteTemplate(tim);
            return systemOperation.Result;
        }

        public bool ObrisiTim(Tim tim)
        {
            SystemOperationsBase systemOperation = new ObrisiTimSO();
            systemOperation.ExecuteTemplate(tim);
            return systemOperation.Uspelo;
        }

        /*  public List<object> VratiTabelu()
          {
              SystemOperationBase
          }*/
    }
}
