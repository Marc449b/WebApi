using Newtonsoft.Json.Linq;
using JsonApi.DataAccess.Dto.Base;
using Model = JsonApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;

namespace JsonApi.DataAccess.Dto.Derived.Misc.JsonEntity
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