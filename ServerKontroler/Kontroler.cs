using Domen;
using Repositories;
using Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
using SystemOperations.AdministratorLigeSO;
using SystemOperations.DrzavaSO;
using SystemOperations.IgracSO;
using SystemOperations.StatistikaIgracaSO;
using SystemOperations.TabelaSO;
using SystemOperations.TimoviSO;
using SystemOperations.UtakmicaSO;

namespace ServerKontroler
{
    public class Kontroler
    {
        private static Kontroler instance;
        private Kontroler()
        {
            
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

        
        private IRepositoryGeneric repository;
        

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

        public List<object> VratiIgrace()
        {
            SystemOperationsBase systemOperation = new VratiIgraceSO();
            systemOperation.ExecuteTemplate(new Igrac());
            return systemOperation.ResultList;
        }

        public List<object> VratiDrzave()
        {
            SystemOperationsBase systemOperation = new VratiDrzaveSO();
            systemOperation.ExecuteTemplate(new Drzava());
            return systemOperation.ResultList;
        }

        public object KreirajIgraca(Igrac igrac)
        {
            SystemOperationsBase systemOperation = new KreirajIgracaSO();
            systemOperation.ExecuteTemplate(igrac);
            return systemOperation.Result;
        }

        public bool ObrisiIgraca(Igrac igrac)
        {
            SystemOperationsBase systemOperation = new ObrisiIgracaSO();
            systemOperation.ExecuteTemplate(igrac);
            return systemOperation.Uspelo;
        }

        public bool UpdateTima(Tim tim)
        {
            SystemOperationsBase systemOperation = new IzmeniTimSO();
            systemOperation.ExecuteTemplate(tim);
            return systemOperation.Uspelo;
        }

        public List<object> VratiUtakmice()
        {
            SystemOperationsBase systemOperation = new VratiUtakmiceSO();
            systemOperation.ExecuteTemplate(new Utakmica());
            return systemOperation.ResultList;

        }

        public object KreirajUtakmicu(Utakmica utakmica)
        {
            SystemOperationsBase systemOperation = new KreirajUtakmicuSO();
            systemOperation.ExecuteTemplate(utakmica);
            return systemOperation.Result;
        }

        public bool UpdateUtakmice(Utakmica utakmica)
        {
            SystemOperationsBase systemOperation = new IzmeniUtakmicuSO();
            systemOperation.ExecuteTemplate(utakmica);
            return systemOperation.Uspelo;
        }

        public List<object> VratiRezultate()
        {
            SystemOperationsBase systemOperation = new VratiRezultateSO();
            systemOperation.ExecuteTemplate(new Rezultati());
            return systemOperation.ResultList;
        }

        public object KreirajStatistiku(StatistikaIgraca statistikaIgraca)
        {
            SystemOperationsBase systemOperation = new KreirajStatistikuIgracaSO();
            systemOperation.ExecuteTemplate(statistikaIgraca);
            return systemOperation.Result;
        }

        public bool UpdateIgraca(Igrac igrac)
        {
            SystemOperationsBase systemOperation = new IzmeniIgracaSO();
            systemOperation.ExecuteTemplate(igrac);
            return systemOperation.Uspelo;
        }

        public List<object> VratiStatistikeIgraca()
        {
            SystemOperationsBase systemOperation = new VratiStatistikeIgracaSO();
            systemOperation.ExecuteTemplate(new StatistikaIgraca());
            return systemOperation.ResultList;
        }

        public bool ObrisiStatistikuIgraca(StatistikaIgraca si)
        {
            SystemOperationsBase systemOperation = new ObrisiStatistikuIgracaSO();
            systemOperation.ExecuteTemplate(si);
            return systemOperation.Uspelo;
        }

        public bool ObrisiUtakmicu(Utakmica utakmica)
        {
            SystemOperationsBase systemOperation = new ObrisiUtakmicuSO();
            systemOperation.ExecuteTemplate(utakmica);
            return systemOperation.Uspelo;
        }

        public List<object> VratiListuStrelaca()
        {
            SystemOperationsBase systemOperation = new VratiListuStrelaca();
            systemOperation.ExecuteTemplate(new ListaStrelaca());
            return systemOperation.ResultList;
        }

        public List<object> VratiListuAdministratoraLige()
        {
            SystemOperationsBase systemOperation = new VratiAdministratoreLigeSO();
            systemOperation.ExecuteTemplate(new AdministratorLige());
            return systemOperation.ResultList;
        }
    }
}
