using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecten2.Models.Domain;

namespace Projecten2.Data.Repositories
{
    public class BatenRepository : IBatenRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Baten> _baten;

        public BatenRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _baten = dbContext.Baten;
        }
        public void Add(Baten baten)
        {
            _baten.Add(baten);
        }

        public void Delete(Baten baten)
        {
            _baten.Remove(baten);
        }

        public IEnumerable<Baten> GetAll()
        {
            return _baten;
        }

        public Baten GetByAnalyse(int Id)
        {
            return _baten.FirstOrDefault(a => a.Analyse.AnalyseId == Id);
        }

        public Baten GetById(int batenId)
        {
            return _baten.FirstOrDefault(a => a.BatenId == batenId);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
