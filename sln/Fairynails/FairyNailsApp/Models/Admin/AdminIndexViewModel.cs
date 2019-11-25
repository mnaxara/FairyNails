using FairyNails.Service;
using FairyNails.Service.Entity;
using FairyNails.Service.RendezVousServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models.Admin
{
    public class AdminIndexViewModel
    {
        public List<ListRendezVousViewModel> RendezVous { get; set; }
        public DateTime FirstDayOfMonth { get; set; }
    }

    public class ListRendezVousViewModel : IRendezVous
    {
        public int IdRdv { get; set; }
        public DateTime DateRdv { get; set; }
        public decimal PrixTotal { get; set; }
        public TimeSpan DureeTotal { get; set; }
        public string IdClient { get; set; }
        public ApplicationUser IdClientNavigation { get; set; }
        public List<string> Prestations { get; set ; }
    }
}
