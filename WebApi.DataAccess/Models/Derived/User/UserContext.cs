using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models.Base;

namespace WebApi.DataAccess.Models.Derived.User
{
    public class UserContext : BaseContext
    {
        public UserContext() { }

        public UserContext(DbContextOptions<BaseContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;Database=user;Uid=root;",
                ServerVersion.Parse("10.4.13-mariadb"),
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                });
        }
    }
}