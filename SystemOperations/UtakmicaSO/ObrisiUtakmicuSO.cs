using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.UtakmicaSO
{
    public class ObrisiUtakmicuSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Utakmica utakmica = entity as Utakmica;
            if(utakmica.DomacinGolovi==-1 && utakmica.GostGolovi == -1)
            {
                Uspelo = repository.Obrisi(entity);
                return;
            }
            List<object> listaStatistikaIgraca= repository.VratiListu(new StatistikaIgraca()).Cast<object>().ToList();
            if (listaStatistikaIgraca != null)
            {

                foreach (StatistikaIgraca si in listaStatistikaIgraca)
                {
                    if (si.UtakmicaID.UtakmicaID == utakmica.UtakmicaID)
                    {
                    Igrac igrac = new Igrac();
                    igrac = si.IgracID;
                    igrac = repository.VratiEntity(igrac) as Igrac;
                    igrac.Golovi -= si.Golovi;
                    bool obrisanaStatistika = repository.Obrisi(si);
                    bool IzmenjenIgrac = repository.Izmeni(igrac);

                    }
                }
                Tim domacin = utakmica.DomacinID;
                Tim gost = utakmica.GostID;
                bool izmenaDomacina;
                bool izmenaGosta;
                if (utakmica.DomacinGolovi > utakmica.GostGolovi)
                {
                    domacin.Pobede -= 1;
                    domacin.Bodovi -= 3;
                    gost.Porazi -= 1;
                    izmenaDomacina = repository.Izmeni(domacin);
                    izmenaGosta = repository.Izmeni(gost);
                }
                if (utakmica.DomacinGolovi == utakmica.GostGolovi)
                {
                    domacin.Neresene -= 1;
                    domacin.Bodovi -= 1;
                    gost.Neresene -= 1;
                    gost.Bodovi -= 1;
                    izmenaDomacina = repository.Izmeni(domacin);
                    izmenaGosta = repository.Izmeni(gost);
                }
                if (utakmica.DomacinGolovi < utakmica.GostGolovi)
                {
                    domacin.Porazi -= 1;

                    gost.Pobede -= 1;
                    gost.Bodovi -= 3;
                    izmenaDomacina = repository.Izmeni(domacin);
                    izmenaGosta = repository.Izmeni(gost);
                }

            }
          

            Uspelo = repository.Obrisi(entity);
        }
    }
}
