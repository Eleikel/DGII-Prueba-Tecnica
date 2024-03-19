using DGII.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Configurations
{
    public class ComprobanteFiscalConfiguration : IEntityTypeConfiguration<ComprobanteFiscal>
    {
        public void Configure(EntityTypeBuilder<ComprobanteFiscal> builder)
        {

            builder.ToTable("ComprobanteFiscal");

            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.NCF).HasColumnName("NFC")
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(e => e.NCF)
                .IsUnique();


            builder.Property(e => e.RncCedula).HasColumnName("RncCedula")
                   .HasMaxLength(150);

            builder.Property(e => e.Monto).HasColumnName("Monto");

            builder.Property(e => e.Itbis18).HasColumnName("Itbis18");

            builder.HasOne(e => e.Contribuyente)
                .WithMany(cf => cf.ComprobantesFiscales)
                .HasForeignKey(e => e.ContribuyenteId);


            
        //    builder.HasData(
        //    new ComprobanteFiscal { Id = 1, ContribuyenteId = 1, RncCedula = "98754321012", Monto = 200.00, Itbis18 = 36.00, NCF = "E310000000001" },
        //    new ComprobanteFiscal { Id = 2, ContribuyenteId = 1, RncCedula = "98754321012", Monto = 1000.00, Itbis18 = 180.00, NCF = "E310000000002" },
        //    new ComprobanteFiscal { Id = 3, ContribuyenteId = 2, RncCedula = "123456789", Monto = 1000.00, Itbis18 = 180.00, NCF = "E310000000003" },
        //    new ComprobanteFiscal { Id = 4, ContribuyenteId = 2, RncCedula = "123456789", Monto = 200.00, Itbis18 = 36.00, NCF = "E310000000004" }
        //);
        }
    }
}
