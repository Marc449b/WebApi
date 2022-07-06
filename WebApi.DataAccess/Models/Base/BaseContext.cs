using Microsoft.EntityFrameworkCore;

namespace WebApi.DataAccess.Models.Base
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext() { }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string should be injected
            optionsBuilder.UseMySql(
                ServerVersion.AutoDetect("Server=localhost;Database=misc;Uid=root;"),
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply type configurations only from this namespace
            modelBuilder.ApplyConfigurationsFromAssembly(
                GetType().Assembly,
                t => t.Namespace!.Contains(GetType().Namespace!));
        }
    }
}