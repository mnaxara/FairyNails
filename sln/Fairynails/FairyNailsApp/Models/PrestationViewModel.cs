using FairyNails.Service.Entity;
using FairyNails.Service.PrestationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models
{
    public class PrestationViewModel : IPrestation
    {
        public int IdPrestation { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public TimeSpan Duree { get; set; }
        public ICollection<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set ; }
    }
}
