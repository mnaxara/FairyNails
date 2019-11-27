using FairyNails.Service.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace FairyNails.Service.PrestationServices
{
    /// <summary>
    /// All the services which aimed the "prestation"
    /// In order not to expose entity, generic methode are used.
    /// </summary>
    public sealed class PrestationService : IPrestationService
    {
        #region fields
        private readonly FairynailsContext _context;
        #endregion

        #region properties

        #endregion

        #region constructors

        public PrestationService(FairynailsContext context)
        {
            this._context = context;
        }
        #endregion

        #region methods
        public List<T> GetAllPrestations<T>() where T : IPrestation, new()
        {
            return _context.TPrestation
                .Select(item => new T() {
                    IdPrestation = item.IdPrestation,
                    Description = item.Description,
                    Duree = item.Duree,
                    Nom = item.Nom,
                    Prix = item.Prix
                })
                .ToList();
        }

        public T GetPrestationById<T>(Int32 idPrestation) where T : IPrestation, new()
        {
            return _context.TPrestation
                .Where(prest => prest.IdPrestation == idPrestation)
                .Select(prest => new T()
                {
                    IdPrestation = prest.IdPrestation,
                    Description = prest.Description,
                    Duree = prest.Duree,
                    Nom = prest.Nom,
                    Prix = prest.Prix
                })
                .FirstOrDefault();
        }

        public Boolean UpdatePrestation<T>(T prestation) where T : IPrestation, new()
        {
            TPrestation prestationToUpdate = new TPrestation()
            {
                IdPrestation = prestation.IdPrestation,
                Description = prestation.Description,
                Duree = prestation.Duree,
                Nom = prestation.Nom,
                Prix = prestation.Prix,
            };
            _context.TPrestation.Update(prestationToUpdate);
            _context.SaveChanges();

            return true;
            
        }
        public Boolean DeletePrestation(Int32 idPrestation)
        {
            TPrestation toDelete = _context.TPrestation.Find(idPrestation);
            _context.TPrestation.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }
        #endregion
    }
}
