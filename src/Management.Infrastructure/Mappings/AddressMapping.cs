// <summary> AddressMapping, Class responsible for mapping the entity's properties to generate migrations and consequently the database </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Infrastructure.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Street)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.ResidenceNumber)
            .IsRequired()
            .HasColumnType("varchar(10)");

            builder.Property(p => p.Neighborhood)
            .IsRequired()
            .HasColumnType("varchar(60)");

            builder.Property(p => p.City)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(p => p.State)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(p => p.Country)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(p => p.Complement)
            .HasColumnType("varchar(100)");

            builder.ToTable("Adresses");
        }
    }
}
