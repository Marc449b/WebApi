using WebApi.DataAccess.Models.Derived.User;
using WebApi.DataAccess.Repository.Base;
using WebApi.DataAccess.Repository.Derived.User.Account.Interface;
using Model = WebApi.DataAccess.Models.Derived.User.Account.Account;

namespace WebApi.DataAccess.Repository.Derived.User.Account
{
    public class AccountRepository : RepositoryBase<Model, UserContext>, IAccountRepository
    {
        public AccountRepository(UserContext context) : base(context) { }
    }
}