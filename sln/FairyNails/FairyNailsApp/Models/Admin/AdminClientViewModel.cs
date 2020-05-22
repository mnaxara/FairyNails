using FairyNails.Service;
using FairyNails.Service.ClientService;
using FairyNails.Service.RendezVousServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models.Admin
{
    public class AdminClientViewModel : IClient
    {
        public ApplicationUser User { get ; set ; }
        public List<DateTime> DatesRendezVous { get; set; }
        public IRendezVous LastRendezVous { get; set; }
        public IRendezVous NextRendezVous { get; set; }
        public int CA { get; set; }
    }
}
