using WebApi.DataAccess.Repository.Base.Interface;
using Model = WebApi.DataAccess.Models.Derived.User.Account.Account;

namespace WebApi.DataAccess.Repository.Derived.User.Account.Interface
{
    public interface IAccountRepository : IRepositoryBase<Model> { }
}