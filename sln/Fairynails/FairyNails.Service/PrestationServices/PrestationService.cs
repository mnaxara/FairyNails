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
    /// A CSClass definition.
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
        #endregion
    }
}
