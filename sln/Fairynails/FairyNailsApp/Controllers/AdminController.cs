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

        public AdminController(RoleManager<IdentityRole> rolemanager)
        {
            this._rolemanager = rolemanager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}