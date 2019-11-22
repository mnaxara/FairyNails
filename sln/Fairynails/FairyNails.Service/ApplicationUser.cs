using FairyNails.Service.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FairyNails.Service
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }

        public ICollection<TRendezVous> TRendezVous{ get; set; }
    }
}
