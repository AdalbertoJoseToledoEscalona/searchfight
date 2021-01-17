using searchfight.Domain.Abstract;
using searchfight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchfight.Domain.Concrete
{
    public class EFParameterRepository : IParameterRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Parameter> Parameters { get { return context.Parameters; } }
    }
}
