using WebApi.DataAccess.Repository.Base.Interface;
using Model = WebApi.DataAccess.Models.Derived.User.Account.Account;
using ModelDto = WebApi.DataAccess.Dto.Derived.User.Account.AccountDto;

namespace WebApi.DataAccess.Repository.Derived.User.Account.Interface
{
    public interface IAccountRepository : IRepositoryBase<Model, ModelDto> { }
}