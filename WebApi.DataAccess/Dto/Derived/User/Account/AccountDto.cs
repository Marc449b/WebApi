using WebApi.DataAccess.Dto.Base;
using WebApi.DataAccess.Dto.Derived.Misc.JsonEntity;
using Model = WebApi.DataAccess.Models.Derived.User.Account.Account;

namespace WebApi.DataAccess.Dto.Derived.User.Account
{
    public class AccountDto : BaseDto<JsonEntityDto, Model>
    {
        public string Username { get; set; }
    }
}