using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApi.DataAccess.Dto.Base;
using WebApi.DataAccess.Models.Derived.Misc;
using WebApi.DataAccess.UnitOfWork.Derived.Misc;
using WebApi.DataAccess.UnitOfWork.Derived.Misc.Interface;

namespace WebApi.DataAccess
{
    public static class DataAccess
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddMapster();
        }


        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
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

            services.AddScoped<IMiscUnitOfWork, MiscUnitOfWork>();
        }

        public static void AddMapster(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.EnableJsonMapping();
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;

            // Apply mappings
            Assembly applicationAssembly = typeof(BaseDto<,>).Assembly;
            typeAdapterConfig.Scan(applicationAssembly);

            // Add dependency injection
            services.AddSingleton(typeAdapterConfig);
            services.AddScoped<IMapper, ServiceMapper>();
        }


        internal class ConnectionStrings
        {
            public string Misc { get; set; }
            public string User { get; set; }
        }
    }
}