// <summary> EmployeeMapping, Class responsible for mapping the entity's properties to generate migrations and consequently the database </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Infrastructure.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Departament)
                .HasColumnType("varchar(120)");

            builder.Property(p => p.Role)
                .HasColumnType("varchar(120)");

            builder.ToTable("Employees");
        }
    }
}
