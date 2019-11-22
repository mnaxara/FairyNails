using System;
using System.Collections.Generic;

namespace FairyNails.Service.Entity
{
    public partial class TPrestation
    {
        public TPrestation()
        {
            TRendezVousHasPrestation = new HashSet<TRendezVousHasPrestation>();
        }

        public int IdPrestation { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public DateTime Duree { get; set; }

        public virtual ICollection<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set; }
    }
}
