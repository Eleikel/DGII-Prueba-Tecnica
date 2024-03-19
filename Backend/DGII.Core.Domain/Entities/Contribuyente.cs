using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Core.Domain.Entities
{
    public class Contribuyente
    {
        //Act as a key
        public int Id { get; set; }
        public string RncCedula { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool Estatus { get; set; }

        public IEnumerable<ComprobanteFiscal> ComprobantesFiscales { get; set; }
    }
}
