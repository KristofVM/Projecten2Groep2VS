using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain
{
    public interface IBatenRepository
    {
        void Add(Baten baten);
        void Delete(Baten baten);
        IEnumerable<Baten> GetAll();
        Baten GetByAnalyse(int Id);
        Baten GetById(int batenId);
        void SaveChanges();
    }
}
