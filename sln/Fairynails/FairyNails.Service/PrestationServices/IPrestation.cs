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
    public interface IPrestation
    {
        #region properties
        public int IdPrestation { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public TimeSpan Duree { get; set; }
        public ICollection<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set; }
        #endregion

        #region methods

        #endregion
    }
}
