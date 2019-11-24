using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FairyNails.Service.Entity;
using FairyNails.Service.PrestationServices;
using Microsoft.EntityFrameworkCore;

namespace FairyNails.Service.RendezVousServices
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RendezVousService : IRendezVousService
    {
        #region fields
        private FairynailsContext _context;
        #endregion

        #region properties

        #endregion

        #region constructors

        public RendezVousService(FairynailsContext context)
        {
            this._context = context;
        }
        #endregion

        #region methods

        public bool AddRendezVous(String idUser, List<Int32> prestationsId, String dateCode)
        {
            DateTime dateRdv = ConvertTimeCodeInDateTime(dateCode);

            TRendezVous rdv = CreateRendezVous(dateRdv, idUser);

            List<TRendezVousHasPrestation> link = CreateRendezVousPrestationsLink(prestationsId, rdv);

            rdv.TRendezVousHasPrestation = link;
            _context.AddRange(rdv);
            _context.SaveChanges();

            var test = _context.TRendezVous.ToList();

            return true;
        }

        public bool DeleteRendezVous(int idRdv)
        {
            TRendezVous toDelete = _context.TRendezVous.Find(idRdv);
            _context.Remove(toDelete);
            return true;
        }

        public List<T> GetAllRendezVous<T>() where T : IRendezVous, new()
        {
            return _context.TRendezVous
                .Select(item => new T()
                {
                    IdRdv = item.IdRdv,
                    DateRdv = item.DateRdv,
                    DureeTotal = item.DureeTotal,
                    PrixTotal = item.PrixTotal,
                    TRendezVousHasPrestation = item.TRendezVousHasPrestation,
                    IdClientNavigation = item.IdClientNavigation
                })
                .ToList();
        }

        private TRendezVous CreateRendezVous (DateTime dateRdv, String idUser)
        {
            return new TRendezVous()
            {
                DateRdv = dateRdv,
                IdClient = idUser,
                PrixTotal = 200,
                Validate = false,
            };
        }

        private List<TRendezVousHasPrestation> CreateRendezVousPrestationsLink (List<Int32> prestationsId, TRendezVous rdv)
        {
            List<TRendezVousHasPrestation> link = new List<TRendezVousHasPrestation>();
            foreach (var prestationId in prestationsId)
            {
                TPrestation prestation = _context.TPrestation.Find(prestationId);
                link.Add(new TRendezVousHasPrestation() { IdRdvNavigation = rdv, IdPrestationNavigation = prestation });
            }

            return link;
        }

        private DateTime ConvertTimeCodeInDateTime (String dateCode)
        {
            String[] dateCodeSplit = dateCode.Split('-');
            return new DateTime(
                Int32.Parse(dateCodeSplit[0]),
                Int32.Parse(dateCodeSplit[1]),
                Int32.Parse(dateCodeSplit[2]),
                Int32.Parse(dateCodeSplit[3]),
                0, 0);
        }

        #endregion
    }
}
