using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.TimoviSO
{
    public class ObrisiTimSO : SystemOperationsBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Tim tim = entity as Tim;

            foreach (Igrac i in tim.ListaIgraca)
            {
                foreach (StatistikaIgraca si in tim.statistikaIgracas)
                {
                    if (si.IgracID.IgracID == i.IgracID)
                    {
                        i.Golovi -= si.Golovi;
                        bool obrisanaStatistika = repository.Obrisi(si);
                       
                    }
                }

                if (i.TimID.TimID == tim.TimID)
                {
                    bool obrisanIgrac = repository.Obrisi(i);
                }
                else
                {
                    bool izmenjenIgrac = repository.Izmeni(i);
                }

            }

            
            foreach(Utakmica u in tim.ListaUtakmica)
            {
                Tim drugiTim = new Tim();
                bool izmenaTima;
                
                if (tim.TimID == u.DomacinID.TimID)
                {
                    drugiTim = (Tim)repository.VratiEntity(u.GostID);


                    if (u.DomacinGolovi != -1 && u.GostGolovi != -1)
                    {
                        if (u.DomacinGolovi == u.GostGolovi)
                        {
                            drugiTim.Neresene -= 1;
                            drugiTim.Bodovi -= 1;
                            izmenaTima = repository.Izmeni(drugiTim);
                        }
                        if (u.DomacinGolovi > u.GostGolovi)
                        {
                            drugiTim.Porazi -= 1;
                            
                            izmenaTima = repository.Izmeni(drugiTim);
                        }
                        if (u.DomacinGolovi < u.GostGolovi)
                        {
                            drugiTim.Pobede -= 1;
                            drugiTim.Bodovi -= 3;
                            izmenaTima = repository.Izmeni(drugiTim);
                        }

                    }
                    
                }
                if (tim.TimID == u.GostID.TimID)
                {
                    drugiTim = (Tim)repository.VratiEntity(u.DomacinID);
                    drugiTim = u.DomacinID;
                    
                    
                    if (u.DomacinGolovi != -1 && u.GostGolovi != -1)
                    {
                        if (u.DomacinGolovi == u.GostGolovi)
                        {
                            drugiTim.Neresene -= 1;
                            drugiTim.Bodovi -= 1;
                            izmenaTima = repository.Izmeni(drugiTim);
                        }
                        if (u.DomacinGolovi < u.GostGolovi)
                        {
                            drugiTim.Porazi -= 1;

                            izmenaTima = repository.Izmeni(drugiTim);
                        }
                        if (u.DomacinGolovi > u.GostGolovi)
                        {
                            drugiTim.Pobede -= 1;
                            drugiTim.Bodovi -= 3;
                            izmenaTima = repository.Izmeni(drugiTim);
                        }

                    }
                   
                }
                bool obrisanaUtakmica = repository.Obrisi(u);
            }

            Uspelo = repository.Obrisi(entity);
        }
    }
}
