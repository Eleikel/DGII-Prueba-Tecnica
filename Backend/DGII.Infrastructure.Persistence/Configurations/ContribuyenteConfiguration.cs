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
    public class ContribuyenteConfiguration : IEntityTypeConfiguration<Contribuyente>
    {
        public void Configure(EntityTypeBuilder<Contribuyente> builder)
        {
            builder.ToTable("Contribuyente");

            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();

            builder.Property(e => e.RncCedula).HasColumnName("RncCedula").IsRequired();

            builder.Property(e => e.RncCedula).HasColumnName("RncCedula")
                             .HasMaxLength(150);

            builder.Property(e => e.Nombre).HasColumnName("Nombre");

            builder.Property(e => e.Tipo).HasColumnName("Tipo");

            builder.Property(e => e.Estatus).HasColumnName("Estatus");


       //     builder.HasData(
       //    new Contribuyente { RncCedula = "98754321012", Nombre = "Juan Perez", Tipo = "Persona Fisica", Estatus = true },
       //    new Contribuyente {  RncCedula = "123456789", Nombre = "Farmacia tu Salud", Tipo = "Persona Juridica", Estatus = true }

       //);
        }
    }
}
