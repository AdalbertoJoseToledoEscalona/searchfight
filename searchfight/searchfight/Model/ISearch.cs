using searchfight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.Model
{
    public interface ISearch
    {
        public SearchEngine searchEngine { get; set; }
        public long results { get; set; }
        public long Execute(string arg, IQueryable<Parameter> parameters, IQueryable<ParameterType> parameterTypes);
    }
}
