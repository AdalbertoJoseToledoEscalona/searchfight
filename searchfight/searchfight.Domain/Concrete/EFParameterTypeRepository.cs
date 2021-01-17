using searchfight.Domain.Abstract;
using searchfight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchfight.Domain.Concrete
{
    public class EFParameterTypeRepository : IParameterTypeRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<ParameterType> ParameterTypes { get { return context.ParameterTypes; } }
    }
}
