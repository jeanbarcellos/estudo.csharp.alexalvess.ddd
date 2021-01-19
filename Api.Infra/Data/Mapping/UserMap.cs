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

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("mame");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("birth_date");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnName("cpf");
        }
    }
}