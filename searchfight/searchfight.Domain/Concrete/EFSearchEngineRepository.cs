using searchfight.Domain.Abstract;
using searchfight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchfight.Domain.Concrete
{
    public class EFSearchEngineRepository : ISearchEngineRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<SearchEngine> SearchEngines { get { return context.SearchEngines; } }
    }
}
