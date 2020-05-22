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
        public decimal PrixTotal { get; set; }
        public TimeSpan DureeTotal { get; set; }
        public string IdClient { get; set; }
        public string Comments { get; set; }
        public bool Validate { get; set; }

        public virtual ApplicationUser IdClientNavigation { get; set; }
        public virtual ICollection<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set; }
    }
}
