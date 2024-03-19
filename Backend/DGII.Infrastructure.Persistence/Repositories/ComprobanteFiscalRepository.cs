using DGII.Core.Application.Interfaces.Repository;
using DGII.Core.Domain.Entities;
using DGII.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class ComprobanteFiscalRepository : GenericRepository<ComprobanteFiscal>, IComprobanteFiscalRepository
    {
        public ApplicationDbContext _applicationContext;

        public ComprobanteFiscalRepository(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
