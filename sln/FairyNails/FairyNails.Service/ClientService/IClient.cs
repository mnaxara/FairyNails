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
    public interface IClient
    {
        #region properties
        public ApplicationUser User { get; set; }
        public List<DateTime> DatesRendezVous { get; set; }
        public IRendezVous LastRendezVous { get; set; }
        public IRendezVous NextRendezVous { get; set; }
        public Int32 CA { get; set; }
        #endregion

        #region methods

        #endregion
    }
}
