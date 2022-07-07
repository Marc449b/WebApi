using Newtonsoft.Json.Linq;
using WebApi.DataAccess.Dto.Base;
using Model = WebApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;

namespace WebApi.DataAccess.Dto.Derived.Misc.JsonEntity
{
    public class JsonEntityDto : BaseDto<JsonEntityDto, Model>
    {
        public JObject Entities { get; set; }


        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.Data,
                     src => src.Entities);


            SetCustomMappingsInverse()
                .Map(dest => dest.Entities, src => src.Data);
        }
    }
}