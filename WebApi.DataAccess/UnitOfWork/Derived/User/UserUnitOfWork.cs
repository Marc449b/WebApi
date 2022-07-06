using WebApi.DataAccess.Models.Derived.User;
using WebApi.DataAccess.Repository.Derived.User.Account;
using WebApi.DataAccess.Repository.Derived.User.Account.Interface;
using WebApi.DataAccess.UnitOfWork.Base;
using WebApi.DataAccess.UnitOfWork.Derived.User.Interface;

namespace WebApi.DataAccess.UnitOfWork.Derived.User
{
    public class UserUnitOfWork : UnitOfWorkBase<UserContext>, IUserUnitOfWork
    {
        private AccountRepository accountRepository;

        public UserUnitOfWork(UserContext context) : base(context) { }


        public IAccountRepository AccountRepository { get => accountRepository ??= new(context); }
    }
}