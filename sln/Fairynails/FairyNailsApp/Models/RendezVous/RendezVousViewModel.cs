using System;
using System.Collections.Generic;

namespace FairyNailsApp.Models.RendezVous
{
    public class RendezVousViewModel
    {
        public String DateCode { get; set; }
        public string IdClient { get; set; }
        public List<PrestationViewModel> Prestations { get; set; }
    }
}
