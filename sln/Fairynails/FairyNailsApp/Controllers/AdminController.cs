using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.RendezVousServices;
using FairyNailsApp.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FairyNailsApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IRendezVousService _rendezVousService;

        public AdminController(RoleManager<IdentityRole> rolemanager, IRendezVousService rendezVousService)
        {
            this._rolemanager = rolemanager;
            this._rendezVousService = rendezVousService;
        }

        public IActionResult Index()
        {
            AdminIndexViewModel model = new AdminIndexViewModel()
            {
                TodayShortDate = DateTime.Now.AddDays(1).ToShortDateString(),
                RendezVousOfDay = _rendezVousService
                    .GetDayRendezVousWithPrestationName<AdminRendezVousViewModel>(DateTime.Now.AddDays(1).ToShortDateString()),
                WaitingRendezVous = _rendezVousService.GetWaitingRendezVous<AdminRendezVousViewModel>()
            };
            return View(model);
        }
    }
}