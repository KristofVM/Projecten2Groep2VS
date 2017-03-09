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
            return _users;
        }

        public ApplicationUser GetByEmail(string eMail)
        {
            return _users.FirstOrDefault(u => u.Email == eMail);
        }

        public ApplicationUser GetById(string Id)
        {
            return _users.FirstOrDefault(u => u.Id == Id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
