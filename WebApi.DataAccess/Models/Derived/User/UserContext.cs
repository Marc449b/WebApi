using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models.Base;

namespace WebApi.DataAccess.Models.Derived.User
{
    public class UserContext : BaseContext
    {
        public UserContext() { }

        public UserContext(DbContextOptions<BaseContext> options) : base(options) { }
    }
}