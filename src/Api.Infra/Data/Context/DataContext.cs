using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Infra.Data.Mapping;

namespace Api.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Forma 1 - Mapear entidade para tabela
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Category>(new CategoryMap().Configure);


            // Forma 2 - Exemplo BALTA
            // modelBuilder.ApplyConfiguration(new UserMap());
            // modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}