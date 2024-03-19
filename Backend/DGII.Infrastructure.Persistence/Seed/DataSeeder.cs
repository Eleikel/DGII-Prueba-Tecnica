using DGII.Core.Domain.Entities;
using DGII.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Seed
{
    public static class DataSeeder
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contribuyente>().HasData(
                  new Contribuyente()
                  {
                      Id = 1,
                      RncCedula = "98754321012",
                      Nombre = "Juan Perez",
                      Tipo = "Persona Fisica",
                      Estatus = true
                  },
                        new Contribuyente()
                        {
                            Id = 2,
                            RncCedula = "123456789",
                            Nombre = "Farmacia tu Salud",
                            Tipo = "Persona Juridica",
                            Estatus = true
                        }
                );


            modelBuilder.Entity<ComprobanteFiscal>().HasData(
                    new ComprobanteFiscal { Id = 1, ContribuyenteId = 1, RncCedula = "98754321012", Monto = 200.00m, Itbis18 = 36.00m, NCF = "E310000000001" },
                    new ComprobanteFiscal { Id = 2, ContribuyenteId = 1, RncCedula = "98754321012", Monto = 1000.00m, Itbis18 = 180.00m, NCF = "E310000000002" },
                    new ComprobanteFiscal { Id = 3, ContribuyenteId = 2, RncCedula = "123456789", Monto = 1000.00m, Itbis18 = 180.00m, NCF = "E310000000003" },
                    new ComprobanteFiscal { Id = 4, ContribuyenteId = 2, RncCedula = "123456789", Monto = 200.00m, Itbis18 = 36.00m, NCF = "E310000000004" }
                );
        }
    }
}
