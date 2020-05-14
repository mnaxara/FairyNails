using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.PrestationServices;
using FairyNails.Service.RendezVousServices;
using FairyNailsApp.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FairyNailsApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IPrestationService _prestationService;

        public AdminController(RoleManager<IdentityRole> rolemanager, IPrestationService prestationService)
        {
            this._rolemanager = rolemanager;
            this._prestationService = prestationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePrestation(AdminPrestationViewModel prestation)
        {
            _prestationService.UpdatePrestation<AdminPrestationViewModel>(prestation);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePrestation(Int32 idPrestation)
        {
            _prestationService.DeletePrestation(idPrestation);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPrestation(AdminPrestationViewModel prestation)
        {
            _prestationService.AddPrestation(prestation);
            return RedirectToAction("Index");
        }
    }

    //TODO: Gallerie / Admin Gallerie / Admin Générale
}