using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models.Base;

namespace WebApi.DataAccess.Models.Derived.Misc
{
    public class MiscContext : BaseContext
    {
        public MiscContext() { }

        public MiscContext(DbContextOptions<BaseContext> options) : base(options) { }
    }
}