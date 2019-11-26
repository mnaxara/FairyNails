using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FairyNails.Service.Entity
{
    public partial class TRendezVous
    {
        public TRendezVous()
        {
            TRendezVousHasPrestation = new HashSet<TRendezVousHasPrestation>();
        }

        public int IdRdv { get; set; }
        public DateTime DateRdv { get; set; }
        [NotMapped]
        public decimal PrixTotal
        {
            get
            {
                return this.TRendezVousHasPrestation.Sum(item =>item.IdPrestationNavigation.Prix);
            }
            private set { }
        }
        [NotMapped]
        public TimeSpan DureeTotal
        {
            get
            {
                return this.TRendezVousHasPrestation.Aggregate(new TimeSpan(0, 0, 0), (total, item) => total.Add(item.IdPrestationNavigation.Duree));
            }
            private set { }
        }
        public string IdClient { get; set; }
        public bool Validate { get; set; }

        public virtual ApplicationUser IdClientNavigation { get; set; }
        public virtual ICollection<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set; }
    }
}
