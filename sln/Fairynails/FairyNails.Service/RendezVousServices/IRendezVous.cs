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
    /// A CSInterface definition.
    /// </summary>
    public interface IRendezVous
    {
        #region properties

        #endregion
        public int IdRdv { get; set; }
        public DateTime DateRdv { get; set; }
        public decimal PrixTotal { get; set; }
        public DateTime DureeTotal { get; set; }
        public string IdClient { get; set; }
        public ApplicationUser IdClientNavigation { get; set; }
        public ICollection<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set; }
        #region methods

        #endregion
    }
}
