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
    public class ComprobanteFiscalDto : IMapFrom<ComprobanteFiscal>
    {
        public int Id { get; set; }
        public string NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
        public int ContribuyenteId { get; set; }
        //Act as a FK
        public string RncCedula { get; set; }

        public ContribuyenteDto? Contribuyente { get; set; }       


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ComprobanteFiscal, ComprobanteFiscalDto>().ReverseMap();

        }
    }

}
