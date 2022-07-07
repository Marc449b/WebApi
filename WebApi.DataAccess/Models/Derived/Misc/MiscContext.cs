using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models.Base;

namespace WebApi.DataAccess.Models.Derived.Misc
{
    public class MiscContext : BaseContext<MiscContext>
    {
        public MiscContext() { }

        public MiscContext(DbContextOptions<MiscContext> options) : base(options) { }
    }
}