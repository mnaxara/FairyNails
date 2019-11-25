using FairyNails.Service.PrestationServices;
using FairyNailsApp.Models.Prestation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FairyNailsApp.Models.RendezVous
{
    public class CalendarViewModel
    {
        [Required]
        public String DateCode { get; set; }
        [Required]
        public string IdClient { get; set; }
        [Required]
        public List<PrestationViewModel> Prestations { get; set; }
        public List<String> DateCodeRendezVousTaken { get; set; }
        public DateTime FirstDayOfMonth { get; set; }
    }
}
