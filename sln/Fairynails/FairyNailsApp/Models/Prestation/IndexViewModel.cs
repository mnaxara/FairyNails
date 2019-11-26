using FairyNails.Service.PrestationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models.Prestation
{
    public class IndexViewModel
    {
        public List<PrestationViewModel> Prestations { get; set; }
    }

    public class PrestationViewModel : IPrestation
    {
        public int IdPrestation { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public TimeSpan Duree { get; set; }
        public bool IsChosen { get; set; }
    }
}
