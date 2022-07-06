using Microsoft.EntityFrameworkCore;

namespace WebApi.DataAccess.Models.Base
{
    public partial class BaseContext : DbContext
    {
        public BaseContext() { }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string should be injected
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations should be applied in derived context
            throw new NotImplementedException();
        }
    }
}