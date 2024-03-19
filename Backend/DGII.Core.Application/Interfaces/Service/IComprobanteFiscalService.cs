using DGII.Core.Application.Dtos;
using DGII.Core.Application.Interfaces.Common;
using DGII.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Core.Application.Interfaces.Service
{
    public interface IComprobanteFiscalService : IRead<ComprobanteFiscalDto, int>, IEditable<ComprobanteFiscalDto, int>
    {
    }
}
