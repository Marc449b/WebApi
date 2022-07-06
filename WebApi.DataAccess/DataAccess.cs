using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DataAccess.Models.Derived.Misc;
using WebApi.DataAccess.Models.Derived.User;
using WebApi.DataAccess.Repository.Derived.Misc.JsonEntity;
using WebApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface;
using WebApi.DataAccess.Repository.Derived.User.Account;
using WebApi.DataAccess.Repository.Derived.User.Account.Interface;
using WebApi.DataAccess.UnitOfWork.Derived.Misc;
using WebApi.DataAccess.UnitOfWork.Derived.Misc.Interface;
using WebApi.DataAccess.UnitOfWork.Derived.User;
using WebApi.DataAccess.UnitOfWork.Derived.User.Interface;

namespace WebApi.DataAccess
{
    public static class DataAccess
    {
        public static void AddDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<MiscContext>();
            services.AddDbContext<UserContext>();

            services.AddScoped<IMiscUnitOfWork, MiscUnitOfWork>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
        }
    }
}