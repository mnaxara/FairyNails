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
            if(prestationsId.Count == 0)
            {
                return false;
            }

            DateTime dateRdv = ConvertTimeCodeInDateTime(dateCode);

            TRendezVous rdv = CreateRendezVous(dateRdv, idUser);

            List<TRendezVousHasPrestation> link = CreateRendezVousPrestationsLink(prestationsId, rdv);
            _context.AddRange(link);
            _context.SaveChanges();

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
                .Select(item=> new T()
                {
                    IdRdv = item.IdRdv,
                    DateRdv = item.DateRdv,
                    DureeTotal = item.DureeTotal,
                    PrixTotal = item.PrixTotal,
                    Prestations = item.TRendezVousHasPrestation.Select(item => item.IdPrestationNavigation).Select(item => item.Nom).ToList(),
                    IdClientNavigation = item.IdClientNavigation
                })
                .ToList();
        }

        public List<String> GetTakenRendezVousTimeCode()
        {
            return _context.TRendezVous
                .Where(item => item.Validate == true)
                .Select(item => $"{item.DateRdv.Year}-{item.DateRdv.Month}-{item.DateRdv.Day}-{item.DateRdv.Hour}")
                .ToList();
        }

        private TRendezVous CreateRendezVous (DateTime dateRdv, String idUser)
        {
            return new TRendezVous()
            {
                DateRdv = dateRdv,
                IdClientNavigation = _context.Users.Find(idUser),
                PrixTotal = 200,
                Validate = true,
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
