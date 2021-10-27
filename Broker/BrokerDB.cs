using Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker
{
    public class BrokerDB
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public BrokerDB()
        {
            this.connection = new SqlConnection(@"Data Source=DESKTOP-81FQGHK\SQLEXPRESS;Initial Catalog=FootballLeague;Integrated Security=True;Connect Timeout=30;");
        }
        
        #region Konekcija
        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void ZapocniTransakciju()
        {
            this.transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public IEntity Sacuvaj(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> vratiListu(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Izmeni(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Obrisi(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity VratiEntity(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        #endregion
    }
}
