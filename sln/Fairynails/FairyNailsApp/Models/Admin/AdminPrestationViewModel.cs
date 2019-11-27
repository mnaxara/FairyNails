using FairyNails.Service.PrestationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models.Admin
{
    public class AdminPrestationViewModel : IPrestation
    {
        public int IdPrestation { get ; set ; }
        [Required]
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public TimeSpan Duree { get; set; }
    }
}
