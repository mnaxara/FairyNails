using FairyNails.Service.Entity;
using FairyNails.Service.RendezVousServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace FairyNails.Service.ClientService
{
    /// <summary>
    /// A CSClass definition.
    /// </summary>
    public sealed class ClientService : IClientService
    {
        #region fields
        private FairynailsContext _context;
        #endregion

        #region properties

        #endregion

        #region constructors

        public ClientService(FairynailsContext context)
        {
            this._context = context;
        }
        #endregion

        #region methods
        /// <summary>
        /// Get All client list with their CA, Last Rdv and Rdv date list
        /// </summary>
        /// <typeparam name="T">Clients list Class</typeparam>
        /// <typeparam name="U">Rendez-Vous Class</typeparam>
        /// <returns>List of T</returns>
        public List<T> GetAllClientWithAdminData<T, U>() where T : IClient, new() where U : IRendezVous, new()
        {
            List<T> clients = new List<T>();
            // Initialize list with all client who had a rdv
            _context.TRendezVous
                .Where(rdv => rdv.Validate == true)
                .Select(rdv => rdv.IdClientNavigation)
                .Distinct()
                .ToList()
                .ForEach(clt =>
               clients.Add(new T() { User = clt }
               ));
            // Fill each client data
            _context.TRendezVous
                .Include(r => r.TRendezVousHasPrestation)
                    .ThenInclude(a => a.IdPrestationNavigation)
                .ToList()
                .ForEach(rdv =>
                    {
                        var client = clients.Find(clt => clt.User == rdv.IdClientNavigation);
                        if (client.DatesRendezVous == null)
                        {
                            client.DatesRendezVous = new List<DateTime>();
                        }
                        client.DatesRendezVous.Add(rdv.DateRdv);
                        client.CA = Decimal.ToInt32(client.CA + rdv.PrixTotal);
                        if (client.LastRendezVous == null && rdv.DateRdv < DateTime.Now || (client.LastRendezVous != null && rdv.DateRdv > client.LastRendezVous.DateRdv && rdv.DateRdv < DateTime.Now))
                        {
                            client.LastRendezVous = new U()
                            {
                                IdClient = rdv.IdClient,
                                IdClientNavigation = rdv.IdClientNavigation,
                                DateRdv = rdv.DateRdv,
                                DureeTotal = rdv.DureeTotal,
                                IdRdv = rdv.IdRdv,
                                Prestations = rdv.TRendezVousHasPrestation.Select(rdv => rdv.IdPrestationNavigation).Select(prest => prest.Nom).ToList(),
                                PrixTotal = rdv.PrixTotal,
                                Validate = rdv.Validate
                            };
                        }
                        else if (client.NextRendezVous == null && rdv.DateRdv > DateTime.Now || (client.NextRendezVous != null && rdv.DateRdv < client.NextRendezVous.DateRdv && rdv.DateRdv > DateTime.Now))
                        {
                            client.NextRendezVous = new U()
                            {
                                IdClient = rdv.IdClient,
                                IdClientNavigation = rdv.IdClientNavigation,
                                DateRdv = rdv.DateRdv,
                                DureeTotal = rdv.DureeTotal,
                                IdRdv = rdv.IdRdv,
                                Prestations = rdv.TRendezVousHasPrestation.Select(rdv => rdv.IdPrestationNavigation).Select(prest => prest.Nom).ToList(),
                                PrixTotal = rdv.PrixTotal,
                                Validate = rdv.Validate
                            };
                        }
                    }
                );
            return clients;
        }

        public T GetClientById<T>(String userId) where T : IClient, new()
        {
            var rendezVousClients = _context.TRendezVous
                .Where(r => r.IdClient == userId)
                .ToList();

            return new T()
            {
                User = rendezVousClients.Select(r => r.IdClientNavigation).First(),
                DatesRendezVous = rendezVousClients.Select(r => r.DateRdv).ToList(),
                LastRendezVous = rendezVousClients.OrderByDescending(r => r.DateRdv).Cast<IRendezVous>().FirstOrDefault(),
                CA = Decimal.ToInt32(rendezVousClients.Aggregate(0m, (ca, r) => ca + r.PrixTotal))
            };
        }

        #endregion
    }
}
