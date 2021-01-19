using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Infra.Data.Mapping;

namespace Api.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql("Server=[SERVIDOR];Port=[PORTA];Database=Api;Uid=[USUARIO];Pwd=[SENHA]");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Forma 1 - Mapear entidade para tabela
            modelBuilder.Entity<User>(new UserMap().Configure);
            // new UserMap().Configure(modelBuilder.Entity<UserEntity>()); //  Doc Microsoft

            // Forma 2 - Exemplo BALTA
            // modelBuilder.ApplyConfiguration(new UserMap());

            // Forma 3 - Varre um determinado assembly para todos os tipos que o implementam IEntityTypeConfiguratione registra cada um automaticamente.
            // Observação: A ordem na qual as configurações serão aplicadas é indefinida,portanto, esse método só deve ser usado quando a ordem não importa.
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}