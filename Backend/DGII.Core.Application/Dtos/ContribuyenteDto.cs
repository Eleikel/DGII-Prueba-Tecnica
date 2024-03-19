using DGII.Core.Application.Mappings.Base;
using DGII.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;


namespace DGII.Core.Application.Dtos
{
    public class ContribuyenteDto : IMapFrom<Contribuyente>
    {
        public int Id { get; set; }
        public string RncCedula { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool Estatus { get; set; }

        public IEnumerable<ComprobanteFiscalDto>? ComprobantesFiscales { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contribuyente, ContribuyenteDto>().ReverseMap();
        }
    }

}
