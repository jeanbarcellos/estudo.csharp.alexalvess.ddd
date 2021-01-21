using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Domain.Entities;

namespace Api.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("birth_date")
                .HasColumnType("timestamp");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnName("cpf")
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");
        }
    }
}