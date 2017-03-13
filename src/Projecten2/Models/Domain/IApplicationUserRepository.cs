using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetById(string Id);
        ApplicationUser GetByEmail(string eMail);
        IEnumerable<ApplicationUser> GetAll();
        void SaveChanges();
    }
}
