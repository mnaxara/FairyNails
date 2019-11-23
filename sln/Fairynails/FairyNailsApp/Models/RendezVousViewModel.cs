using FairyNails.Service;
using FairyNails.Service.Entity;
using FairyNails.Service.RendezVousServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models
{
    public class RendezVousViewModel : IRendezVous
    {
        public int IdRdv { get; set;}
        public DateTime DateRdv { get; set; }
        public decimal PrixTotal { get; set; }
        public TimeSpan DureeTotal { get; set; }
        public string IdClient { get; set; }
        public ApplicationUser IdClientNavigation { get; set; }
        public ICollection<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set; }
    }
}
