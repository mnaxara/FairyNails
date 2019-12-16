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
    /// A CSInterface definition.
    /// </summary>
    public interface IPrestationService
    {
        #region properties

        #endregion

        #region methods
        public List<T> GetAllPrestations<T>() where T : IPrestation, new();
        public T GetPrestationById<T>(Int32 idPrestation) where T : IPrestation, new();
        public Boolean UpdatePrestation<T>(T prestation) where T : IPrestation, new();
        public Boolean DeletePrestation(Int32 idPrestation);
        public Boolean AddPrestation(IPrestation prestation);
        #endregion
    }
}
