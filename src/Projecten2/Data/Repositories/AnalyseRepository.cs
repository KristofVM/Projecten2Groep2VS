using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecten2.Models.Domain;

namespace Projecten2.Data.Repositories
{
    public class AnalyseRepository : IAnalyseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Analyse> _analyses;

        public AnalyseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _analyses = dbContext.Analyses;
        }
        public void Add(Analyse analyse)
        {
            _analyses.Add(analyse);
        }

        public void Delete(Analyse analyse)
        {
            _analyses.Remove(analyse);
        }

        public IEnumerable<Analyse> GetAll()
        {
            return _analyses;
        }

        public Analyse GetById(int analyseId)
        {
            return _analyses
                .Include(a => a.Baten)
                .ThenInclude(a => a.Bvragen3)
                .Include(a => a.Baten)
                .ThenInclude(a => a.Bvragen4)
                .Include(a => a.Baten)
                .ThenInclude(a => a.Bvragen5)
                .Include(a => a.Baten)
                .ThenInclude(a => a.Bvragen9)
                .Include(a => a.Baten)
                .ThenInclude(a => a.Bvragen11)
                .Include(a => a.Kosten)
                .FirstOrDefault(a => a.AnalyseId == analyseId);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void ArchiveerAnalyse(Analyse analyse)
        {
            analyse.Archief = true;
        }

        public void DeArchiveerAnalyse(Analyse analyse)
        {
            analyse.Archief = false;
        }
    }
}
