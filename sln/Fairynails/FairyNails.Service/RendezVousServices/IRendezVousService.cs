using FairyNails.Service.Entity;
using FairyNails.Service.PrestationServices;
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
        public bool AddRendezVous(String idUser, List<Int32> prestationsId, String dateCode);
        public bool DeleteRendezVous(Int32 idRdv);
        public List<String> GetTakenRendezVousTimeCode();

        #endregion
    }
}
