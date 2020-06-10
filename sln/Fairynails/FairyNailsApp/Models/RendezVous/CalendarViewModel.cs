using FairyNails.Ressources;
using FairyNails.Service.PrestationServices;
using FairyNails.Service.RendezVousServices;
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
        public List<String> UnavaibleTimeCode { get; set; }
        public DateTime FirstDayOfMonth { get; set; }
        public string Comments { get; set; }
        public ViewMessage Message { get; set; }

    }
}
