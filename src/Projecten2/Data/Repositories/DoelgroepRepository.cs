using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecten2.Models.Domain;

namespace Projecten2.Data.Repositories
{
    public class DoelgroepRepository : IDoelgroepRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Doelgroep> _doelgroepen;

        public DoelgroepRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _doelgroepen = dbContext.Doelgroepen;
        }

        public Doelgroep GetById(int doelgroepId)
        {
            return _doelgroepen.FirstOrDefault(a => a.DoelgroepId == doelgroepId);
        }

        public IEnumerable<Doelgroep> GetAll()
        {
            return _doelgroepen;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
