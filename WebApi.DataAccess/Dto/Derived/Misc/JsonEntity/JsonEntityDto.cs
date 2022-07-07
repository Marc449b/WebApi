using Newtonsoft.Json.Linq;
using WebApi.DataAccess.Dto.Base;
using Model = WebApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;

namespace WebApi.DataAccess.Dto.Derived.Misc.JsonEntity
{
    public class JsonEntityDto : BaseDto<JsonEntityDto, Model>
    {
        public JObject Data { get; set; }
    }
}