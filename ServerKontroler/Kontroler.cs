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
        private IRepositoryGeneric repository;
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

        public List<object> VratiTabelu()
        {
            SystemOperationsBase systemOperation = new VratiTabeluSO();
            systemOperation.ExecuteTemplate(new Tabela());
            return systemOperation.ResultList;
        }

        public List<object> VratiTimove()
        {
            SystemOperationsBase systemOperation = new UcitajListuTimovaSO();
            systemOperation.ExecuteTemplate(new Tim());
            return systemOperation.ResultList;
        }
        public object KreirajTim(Tim tim)
        {
            SystemOperationsBase systemOperation = new ZapamtiTimSO();
            systemOperation.ExecuteTemplate(tim);
            return systemOperation.Result;
        }
        
        public List<object> Prijavljivanje(AdministratorLige objekat)
        {
            SystemOperationsBase systemOperation = new PrijavljivanjeSO();
            systemOperation.ExecuteTemplate(objekat);
            return systemOperation.ResultList;
        }

        public bool ObrisiTim(Tim tim)
        {
            SystemOperationsBase systemOperation = new ObrisiTimSO();
            systemOperation.ExecuteTemplate(tim);
            return systemOperation.Uspelo;
        }

        public List<object> VratiIgrace()
        {
            SystemOperationsBase systemOperation = new UcitajListuIgraca();
            systemOperation.ExecuteTemplate(new Igrac());
            return systemOperation.ResultList;
        }

        public List<object> VratiDrzave()
        {
            SystemOperationsBase systemOperation = new UcitajListuDrzavaSO();
            systemOperation.ExecuteTemplate(new Drzava());
            return systemOperation.ResultList;
        }

        public object KreirajIgraca(Igrac igrac)
        {
            SystemOperationsBase systemOperation = new ZapamtiIgracaSO();
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
            SystemOperationsBase systemOperation = new UcitajListuUtakmicaSO();
            systemOperation.ExecuteTemplate(new Utakmica());
            return systemOperation.ResultList;

        }

        public object KreirajUtakmicu(Utakmica utakmica)
        {
            SystemOperationsBase systemOperation = new ZapamtiUtakmicuSO();
            systemOperation.ExecuteTemplate(utakmica);
            return systemOperation.Result;
        }

        public bool UpdateUtakmice(Utakmica utakmica)
        {
            SystemOperationsBase systemOperation = new IzmeniUtakmicuSO();
            systemOperation.ExecuteTemplate(utakmica);
            return systemOperation.Uspelo;
        }
        public bool UpdateIgraca(Igrac igrac)
        {
            SystemOperationsBase systemOperation = new IzmeniIgracaSO();
            systemOperation.ExecuteTemplate(igrac);
            return systemOperation.Uspelo;
        }

        public List<object> VratiStatistikeIgraca()
        {
            SystemOperationsBase systemOperation = new UcitajListuStatistikaIgracaSO();
            systemOperation.ExecuteTemplate(new StatistikaIgraca());
            return systemOperation.ResultList;
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


        public List<object> VratiIgraca(Igrac objekat)
        {
            SystemOperationsBase systemOperation = new UcitajIgracaSO();
            systemOperation.ExecuteTemplate(objekat);
            return systemOperation.ResultList;
        }

        public List<object> VratiUtakmicu(Utakmica objekat)
        {
            SystemOperationsBase systemOperation = new UcitajIgracaSO();
            systemOperation.ExecuteTemplate(objekat);
            return systemOperation.ResultList;
        }

        public List<object> VratiPronadjeneTimove(Tim objekat)
        {
            SystemOperationsBase systemOperation = new PretraziTimoveSO();
            systemOperation.ExecuteTemplate(objekat);
            return systemOperation.ResultList;
        }

        public List<object> VratiPronadjeneIgrace(Igrac objekat)
        {
            SystemOperationsBase systemOperation = new PretraziIgraceSO();
            systemOperation.ExecuteTemplate(objekat);
            return systemOperation.ResultList;
        }

        public List<object> VratiPronadjeneUtakmice(Utakmica objekat)
        {
            SystemOperationsBase systemOperation = new PretraziUtakmiceSO();
            systemOperation.ExecuteTemplate(objekat);
            return systemOperation.ResultList;
        }

        public List<object> VratiTim(Tim objekat)
        {
            SystemOperationsBase systemOperation = new UcitajTimSO();
            systemOperation.ExecuteTemplate(objekat);
            return systemOperation.ResultList;
        }
      

       


    }
}
