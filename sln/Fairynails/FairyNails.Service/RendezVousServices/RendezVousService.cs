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
    /// All the services which aimed the "rendez vous"
    /// In order not to expose entity, generic methode are used.
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
            if (prestationsId.Count == 0)
            {
                return false;
            }

            DateTime dateRdv = ConvertTimeCodeInDateTime(dateCode);

            TRendezVous rdv = CreateRendezVous(dateRdv, idUser, prestationsId);

            List<TRendezVousHasPrestation> link = CreateRendezVousPrestationsLink(prestationsId, rdv);
            _context.AddRange(link);
            _context.SaveChanges();

            return true;
        }

        public bool RendezVousValidReject(Int32 idRdv, String command)
        {
            TRendezVous rdv = _context.TRendezVous.Find(idRdv);

            if (command.Equals("accept"))
            {
                //Verifie qu'aucun rdv ne finisse ou commence pendant la plage horaire du rdv
                DateTime startTime = rdv.DateRdv;
                DateTime endTime = startTime.Add(rdv.DureeTotal);
                TRendezVous conflict = _context.TRendezVous
                    .Select(r => new
                    {
                        rdv = r,
                        start = r.DateRdv,
                        end = r.DateRdv.Add(r.DureeTotal)
                    }
                    )
                    .Where(r => r.rdv.Validate == true)
                    .ToList()
                    .Where(r =>
                    (r.start > startTime && r.start < endTime) ||
                    (r.end > startTime && r.end < endTime) ||
                    (r.start < startTime && r.end > endTime))
                    .Select(r => r.rdv)
                    .FirstOrDefault();                
                //
                if (conflict != null)
                {
                    return false;
                }
                else
                {
                    rdv.Validate = true;
                    _context.SaveChanges();
                    return true;
                }
            }
            else if (command.Equals("reject"))
            {
                DeleteRendezVous(rdv);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CancelRendezVous(Int32 idRdv)
        {
            TRendezVous rdv = _context.TRendezVous.Find(idRdv);
            if (rdv != null)
            {
                DeleteRendezVous(rdv);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<T> GetDayRendezVousWithPrestationName<T>(String shortDateFormat) where T : IRendezVous, new()
        {
            String[] dateExplode = shortDateFormat.Split('/');
            DateTime beginDay = new DateTime(Int32.Parse(dateExplode[2]), Int32.Parse(dateExplode[1]), Int32.Parse(dateExplode[0]), 0, 0, 0);
            DateTime endDay = new DateTime(Int32.Parse(dateExplode[2]), Int32.Parse(dateExplode[1]), Int32.Parse(dateExplode[0]), 23, 59, 59);
            List<T> list = _context.TRendezVous
                .Include(rdv => rdv.IdClientNavigation)
                .Include(rdv => rdv.TRendezVousHasPrestation)
                    .ThenInclude(p => p.IdPrestationNavigation)
                .ToList()
                .Where(rdv => rdv.DateRdv < endDay)
                .Where(rdv => rdv.DateRdv > beginDay)
                .Select(rdv => new T()
                {
                    IdRdv = rdv.IdRdv,
                    DateRdv = rdv.DateRdv,
                    DureeTotal = rdv.DureeTotal,
                    PrixTotal = rdv.PrixTotal,
                    Prestations = rdv.TRendezVousHasPrestation.Select(rdv => rdv.IdPrestationNavigation).Select(prest => prest.Nom).ToList(),
                    IdClientNavigation = rdv.IdClientNavigation,
                    Validate = rdv.Validate
                })
                .OrderBy(rdv => rdv.DateRdv)
                .ToList();

            return list;
        }

        public List<T> GetWaitingRendezVous<T>() where T : IRendezVous, new()
        {
            List<T> list = _context.TRendezVous
                .Where(rdv => rdv.Validate == false)
                .Select(rdv => new T()
                {
                    DateRdv = rdv.DateRdv,
                    IdClientNavigation = rdv.IdClientNavigation,
                    Prestations = rdv.TRendezVousHasPrestation.Select(rdvhp => rdvhp.IdPrestationNavigation.Nom).ToList(),
                    IdRdv = rdv.IdRdv,
                    DureeTotal = rdv.DureeTotal,
                })
                .ToList();

            return list;
        }

        public List<String> GetUnavailableDateCode(Int32 month)
        {
            // TODO: Renvoyer les dateCode disponible par mois

            List<String> UnavaibleDateCode = new List<String>();

            List<UnavailableTime> rdvTime = _context.TRendezVous
                .Where(rdv => rdv.Validate == true)
                .Where(rdv => rdv.DateRdv.Month == month)
                .Select(rdv => new UnavailableTime()
                {
                    DateRdv = rdv.DateRdv,
                    Duration = rdv.DureeTotal
                })
                .ToList();

            foreach (var time in rdvTime)
            {               
                TimeSpan ModifiedDuration = time.Duration.Add(new TimeSpan(0, 15, 0));
                Double DurationHour = Math.Ceiling(ModifiedDuration.TotalHours);
                for (int i = time.DateRdv.Hour; i < time.DateRdv.Hour+DurationHour; i++)
                {
                    String DateCode = $"{time.DateRdv.Year}-{ time.DateRdv.Month}-{ time.DateRdv.Day}-{i}";
                    UnavaibleDateCode.Add(DateCode);
                }
            }

            return UnavaibleDateCode;
        }

        private bool DeleteRendezVous(TRendezVous rdv)
        {
            _context.Remove(rdv);
            return true;
        }

        private TRendezVous CreateRendezVous(DateTime dateRdv, String idUser, List<Int32> prestationsId)
        {
            TRendezVous created = new TRendezVous()
            {
                DateRdv = dateRdv,
                IdClientNavigation = _context.Users.Find(idUser),
                Validate = false,
            };

            foreach (var prestationId in prestationsId)
            {
                TPrestation prestation = _context.TPrestation.Find(prestationId);
                created.DureeTotal = created.DureeTotal.Add(prestation.Duree);
                created.PrixTotal += prestation.Prix;
            }

            return created;
        }

        private List<TRendezVousHasPrestation> CreateRendezVousPrestationsLink(List<Int32> prestationsId, TRendezVous rdv)
        {
            List<TRendezVousHasPrestation> link = new List<TRendezVousHasPrestation>();
            foreach (var prestationId in prestationsId)
            {
                TPrestation prestation = _context.TPrestation.Find(prestationId);
                link.Add(new TRendezVousHasPrestation() { IdRdvNavigation = rdv, IdPrestationNavigation = prestation });
            }

            return link;
        }

        private DateTime ConvertTimeCodeInDateTime(String dateCode)
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

        #region projection class
        public class UnavailableTime
        {
            public DateTime DateRdv { get; set; }
            public TimeSpan Duration { get; set;}
        }
        #endregion
    }
}
