using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecten2.Models.Domain;

namespace Projecten2.Data.Repositories
{
    public class KostenRepository : IKostenRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Kosten> _kosten;

        public KostenRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _kosten = dbContext.Kosten;
        }
        public void Add(Kosten kosten)
        {
            _kosten.Add(kosten);
        }

        public void Delete(Kosten kosten)
        {
            _kosten.Remove(kosten);
        }

        public IEnumerable<Kosten> GetAll()
        {
            return _kosten;
        }

        public Kosten GetByAnalyse(int Id)
        {
            return _kosten.FirstOrDefault(a => a.Analyse.AnalyseId == Id);
        }

        public Kosten GetById(int kostenId)
        {
            return _kosten.FirstOrDefault(a => a.KostenId == kostenId);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
