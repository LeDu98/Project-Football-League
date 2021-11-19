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
            Console.WriteLine(entity.InsertVrednosti);
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = $"INSERT into {entity.Tabela} values ({entity.InsertVrednosti})";
            if (command.ExecuteNonQuery() != 1)
            {
                return null;
            }
            return entity;
        }

        public List<IEntity> vratiListu(IEntity entity)
        {
            List<IEntity> result;
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = $"SELECT * from {entity.Tabela} {entity.JoinTabele} {entity.OrderBy}";
            SqlDataReader reader = command.ExecuteReader();
            result = entity.VratiListu(reader);
            reader.Close();

            Console.WriteLine(result);

            return result;
        }

        public int VratiID(IEntity entity)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select max({entity.IdName}) from {entity.Tabela}";
            object result = command.ExecuteScalar();
            if (result is DBNull)
            {
                return 1;
            }
            else
            {
                return (int)result + 1;
            }
        }

        public bool Izmeni(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = $"UPDATE {entity.Tabela} SET {entity.UpdateVrednosti}" +
                $"WHERE {entity.Uslov}";
            Console.WriteLine(command.CommandText);
            if (command.ExecuteNonQuery() != 1)
            {
                return false;
            }
            return true;
        }

        public bool Obrisi(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = $"DELETE from {entity.Tabela} Where {entity.Uslov}";
            Console.WriteLine(command.CommandText);
            if (command.ExecuteNonQuery() != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
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
