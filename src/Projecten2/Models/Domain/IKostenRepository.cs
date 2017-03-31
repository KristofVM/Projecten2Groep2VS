using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain
{
    public interface IKostenRepository
    {
        void Add(Kosten kosten);
        void Delete(Kosten kosten);
        IEnumerable<Kosten> GetAll();
        Kosten GetByAnalyse(int Id);
        Kosten GetById(int batenId);
        void SaveChanges();
    }
}
