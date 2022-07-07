using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DataAccess.Models.Derived.Misc;
using WebApi.DataAccess.Models.Derived.User;
using WebApi.DataAccess.UnitOfWork.Derived.Misc;
using WebApi.DataAccess.UnitOfWork.Derived.Misc.Interface;
using WebApi.DataAccess.UnitOfWork.Derived.User;
using WebApi.DataAccess.UnitOfWork.Derived.User.Interface;

namespace WebApi.DataAccess
{
    public static class DataAccess
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            services.AddDbContext<MiscContext>(options =>
            {
                options.UseMySql(
                connectionStrings.Misc,
                ServerVersion.Parse("10.4.13-mariadb"),
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                });
            });
            services.AddDbContext<UserContext>(options =>
            {
                options.UseMySql(
                connectionStrings.User,
                ServerVersion.Parse("10.4.13-mariadb"),
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                });
            });

            services.AddScoped<IMiscUnitOfWork, MiscUnitOfWork>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
        }

        internal class ConnectionStrings
        {
            public string Misc { get; set; }
            public string User { get; set; }
        }
    }
}