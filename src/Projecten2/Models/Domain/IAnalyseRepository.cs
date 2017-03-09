﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain
{
    public interface IAnalyseRepository
    {
        Analyse GetById(int analyseId);
        IEnumerable<Analyse> GetByGebruiker(string Id);
        IEnumerable<Analyse> GetAll();
        void ArchiveerAnalyse(Analyse analyse);
        void Add(Analyse analyse);
        void Delete(Analyse analyse);
        void SaveChanges();
    }
}
