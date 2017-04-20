using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecten2.Models.Domain;

namespace Projecten2.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<ApplicationUser> _users;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _users = dbContext.Users;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _users.Include(a => a.Analyses).ToList();
        }

        public ApplicationUser GetByEmail(string eMail)
        {
            return _users.Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen3)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen4)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen5)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen9)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen11)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen01)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen1)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen2)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen3)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen4)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen5)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen6)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen7)
                .FirstOrDefault(u => u.Email == eMail);
        }

        public ApplicationUser GetById(string Id)
        {
            return _users.Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen3)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen4)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen5)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen9)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Baten)
                .ThenInclude(a => a.Bvragen11)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen01)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen1)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen2)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen3)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen4)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen5)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen6)
                .Include(a => a.Analyses)
                .ThenInclude(a => a.Kosten)
                .ThenInclude(a => a.Kvragen7)
                .FirstOrDefault(u => u.Id == Id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
