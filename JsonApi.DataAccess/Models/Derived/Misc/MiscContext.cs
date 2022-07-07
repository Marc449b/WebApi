using Microsoft.EntityFrameworkCore;
using JsonApi.DataAccess.Models.Base;

namespace JsonApi.DataAccess.Models.Derived.Misc
{
    public class MiscContext : BaseContext<MiscContext>
    {
        public MiscContext() { }

        public MiscContext(DbContextOptions<MiscContext> options) : base(options) { }
    }
}