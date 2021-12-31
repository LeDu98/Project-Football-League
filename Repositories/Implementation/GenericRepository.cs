using Broker;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class GenericRepository : IRepositoryGeneric
    {
        private BrokerDB broker = new BrokerDB();
        public void OtvoriKonekciju()
        {
            broker.OtvoriKonekciju();
        }

        public void ZatvoriKonekciju()
        {
            broker.ZatvoriKonekciju();
        }

        public void ZapocniTransakciju()
        {
            broker.ZapocniTransakciju();
        }

        public void Commit()
        {
            broker.Commit();
        }

        public void Rollback()
        {
            broker.Rollback();
        }

        public IEntity Sacuvaj(IEntity entity)
        {
            return broker.Sacuvaj(entity);
        }

        public List<IEntity> VratiListu(IEntity entity)
        {
            return broker.vratiListu(entity);
        }

        public IEntity VratiEntity(IEntity entity)
        {
            return broker.VratiEntity(entity);
        }

        public bool Izmeni(IEntity entity)
        {
            return broker.Izmeni(entity);
        }

        public bool Obrisi(IEntity entity)
        {
            return broker.Obrisi(entity);
        }

        public int VratiID(IEntity entity)
        {
            return broker.VratiID(entity);
        }

        public List<IEntity> Pretrazi(IEntity entity)
        {
            return broker.Pretraga(entity);
        }
    }
}
