using FairyNails.Service;
using FairyNails.Service.Entity;
using FairyNails.Service.RendezVousServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyNailsApp.Models.Admin
{
    public class AdminRendezVousManagementViewModel
    {
        public List<AdminRendezVousModel> RendezVousOfDay { get; set; }
        public List<AdminRendezVousModel> WaitingRendezVous { get; set; }
        public String TodayShortDate { get; set; }
    }
}
