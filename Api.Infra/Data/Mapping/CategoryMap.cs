using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Domain.Entities;

namespace Api.Infra.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");
        }
    }
}