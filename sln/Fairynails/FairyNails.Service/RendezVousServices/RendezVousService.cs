using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FairyNails.Service.Entity;

namespace FairyNails.Service.RendezVousServices
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RendezVousService : IRendezVousService
    {
        #region fields
        private FairynailsContext _context;
        #endregion

        #region properties

        #endregion

        #region constructors

        public RendezVousService(FairynailsContext context)
        {
            this._context = context;
        }
        #endregion

        #region methods

        public bool AddRendezVous(TRendezVous rdv)
        {
            _context.Add(rdv);
            return true;
        }

        public bool DeleteRendezVous(int idRdv)
        {
            TRendezVous toDelete = _context.TRendezVous.Find(idRdv);
            _context.Remove(toDelete);
            return true;
        }

        public List<T> GetAllRendezVous<T>() where T : IRendezVous, new()
        {
            return _context.TRendezVous
                .Select(item => new T()
                {
                    IdRdv = item.IdRdv,
                    DateRdv = item.DateRdv,
                    DureeTotal = item.DureeTotal,
                    PrixTotal = item.PrixTotal,
                    TRendezVousHasPrestation = item.TRendezVousHasPrestation,
                    IdClientNavigation = item.IdClientNavigation
                })
                .ToList();
        }

        #endregion
    }
}
