using WebApi.DataAccess.Models.Base.Entity;

namespace WebApi.DataAccess.Models.Derived.User.Account
{
    public class Account : BaseEntity
    {
        /// <summary>
        /// Account username
        /// </summary>
        public virtual string Username { get; set; }
    }
}