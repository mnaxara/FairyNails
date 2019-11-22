using FairyNails.Service.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace FairyNails.Service.RendezVousServices
{
    /// <summary>
    /// RendezVousService definition
    /// </summary>
    public interface IRendezVousService
    {
        #region properties

        #endregion

        #region methods

        public List<T> GetAllRendezVous<T>() where T : IRendezVous, new();
        public bool AddRendezVous(TRendezVous rdv);
        public bool DeleteRendezVous(Int32 idRdv);

        #endregion
    }
}
