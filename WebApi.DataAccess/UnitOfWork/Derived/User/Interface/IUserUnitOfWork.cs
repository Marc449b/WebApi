using WebApi.DataAccess.Repository.Derived.User.Account.Interface;
using WebApi.DataAccess.UnitOfWork.Base.Interface;

namespace WebApi.DataAccess.UnitOfWork.Derived.User.Interface
{
    public interface IUserUnitOfWork : IUnitOfWorkBase 
    { 
        IAccountRepository AccountRepository { get; }
    }
}