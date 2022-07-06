using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DataAccess.Models.Base.Entity;

namespace WebApi.DataAccess.Models.Derived.User.Account
{
    public class AccountEntityTypeConfiguration : BaseEntityTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            // Additional properties
            builder.Property(x => x.Username).HasMaxLength(20);
        }
    }
}