using Management.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Infrastructure.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.HasOne(p => p.Address)
                .WithOne(a => a.Company);

            builder.HasMany(p => p.Employees)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);
          
            builder.ToTable("Companies");
        }
    }
}
