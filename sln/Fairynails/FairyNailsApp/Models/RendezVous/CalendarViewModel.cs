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
        public String DateCode { get; set; }
        public string IdClient { get; set; }
        public List<PrestationViewModel> Prestations { get; set; }
        public List<String> UnavaibleTimeCode { get; set; }
        public DateTime FirstDayOfMonth { get; set; }

    }
}
