using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models.Base;

namespace WebApi.DataAccess.Models.Derived.User
{
    public class UserContext : BaseContext<UserContext>
    {
        public UserContext() { }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}