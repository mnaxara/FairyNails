using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models
{
    public class CalendarViewModel
    {
        public RendezVousViewModel rendezVous { get; set; }
        public List<PrestationViewModel> prestations { get; set; }
    }
}
