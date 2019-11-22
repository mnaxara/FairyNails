using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.RendezVousServices;
using Microsoft.AspNetCore.Mvc;

namespace FairyNailsApp.Controllers
{
    public class RendezVousController : Controller
    {
        private readonly IRendezVousService _rendezVousService;

        public RendezVousController (IRendezVousService rendezVousService)
        {
            this._rendezVousService = rendezVousService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Calendar");
        }

        public IActionResult Calendar()
        {
            return View();
        }
    }
}