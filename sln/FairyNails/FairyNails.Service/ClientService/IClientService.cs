using FairyNails.Service.RendezVousServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace FairyNails.Service.ClientService
{
    /// <summary>
    /// A CSInterface definition.
    /// </summary>
    public interface IClientService
    {
        #region properties

        #endregion

        #region methods
        public List<T> GetAllClientWithAdminData<T, U>() where T : IClient, new() where U : IRendezVous, new();
        public T GetClientById<T>(String userId) where T : IClient, new ();
        #endregion
    }
}
