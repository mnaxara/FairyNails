using System;
using System.Collections.Generic;

namespace FairyNails.Service.Entity
{
    public partial class TRendezVousHasPrestation
    {
        public int IdRdv { get; set; }
        public int IdPrestation { get; set; }

        public virtual TPrestation IdPrestationNavigation { get; set; }
        public virtual TRendezVous IdRdvNavigation { get; set; }
    }
}
