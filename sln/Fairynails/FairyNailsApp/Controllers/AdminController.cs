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
            List<ListRendezVousViewModel> rendezVous = _rendezVousService.GetAllRendezVous<ListRendezVousViewModel>();
            List<Int32> idsPrestation = new List<int>();

            AdminIndexViewModel model = new AdminIndexViewModel()
            {
                FirstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };
            return View(model);
        }
    }
}