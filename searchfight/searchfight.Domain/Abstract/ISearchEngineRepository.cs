using searchfight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchfight.Domain.Abstract
{
    public interface ISearchEngineRepository
    {
        IQueryable<SearchEngine> SearchEngines { get; }
    }
}
