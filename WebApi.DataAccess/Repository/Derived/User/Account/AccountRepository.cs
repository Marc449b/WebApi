using WebApi.DataAccess.Models.Derived.User;
using WebApi.DataAccess.Repository.Base;
using WebApi.DataAccess.Repository.Derived.User.Account.Interface;
using Model = WebApi.DataAccess.Models.Derived.User.Account.Account;
using ModelDto = WebApi.DataAccess.Dto.Derived.User.Account.AccountDto;

namespace WebApi.DataAccess.Repository.Derived.User.Account
{
    public class AccountRepository : RepositoryBase<Model, ModelDto, UserContext>, IAccountRepository
    {
        public AccountRepository(UserContext context) : base(context) { }
    }
}