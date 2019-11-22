using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FairyNailsApp.Controllers
{
    public class RendezVousController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}