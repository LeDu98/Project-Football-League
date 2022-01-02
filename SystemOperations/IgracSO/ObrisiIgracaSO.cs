using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.IgracSO
{
    public class ObrisiIgracaSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Igrac igrac = entity as Igrac;
            List<object> listaStatistika = new List<object>();
            try
            {
                listaStatistika = repository.VratiListu(new StatistikaIgraca()).Cast<object>().ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            foreach (StatistikaIgraca si in listaStatistika)
            {
                if (si.IgracID.IgracID == igrac.IgracID)
                {
                bool obrisanaStatistika = repository.Obrisi(si);

                }
            }

            Uspelo = repository.Obrisi(entity);
        }
    }
}
