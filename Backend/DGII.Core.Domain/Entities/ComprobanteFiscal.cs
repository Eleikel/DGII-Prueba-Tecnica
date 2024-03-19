using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Core.Domain.Entities
{
    public class ComprobanteFiscal
    {
        public int Id { get; set; }
        public string NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
        public int? ContribuyenteId { get; set; }
        //Act as a FK
        public string RncCedula { get; set; }

        public Contribuyente? Contribuyente { get; set;}
    }
}
