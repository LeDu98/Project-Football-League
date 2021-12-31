using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepositoryGeneric
    {
        IEntity Sacuvaj(IEntity entity);


        List<IEntity> VratiListu(IEntity entity);
        List<IEntity> Pretrazi(IEntity entity);

        IEntity VratiEntity(IEntity entity);
        bool Izmeni(IEntity entity);
        int VratiID(IEntity entity);
        bool Obrisi(IEntity entity);

        void OtvoriKonekciju();

        void ZatvoriKonekciju();

        void ZapocniTransakciju();

        void Commit();

        void Rollback();

    }
}
