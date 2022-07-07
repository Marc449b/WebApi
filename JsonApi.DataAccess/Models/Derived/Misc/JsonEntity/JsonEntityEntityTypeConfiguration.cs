using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonApi.DataAccess.Models.Base.Entity;

namespace JsonApi.DataAccess.Models.Derived.Misc.JsonEntity
{
    public class JsonEntityEntityTypeConfiguration : BaseEntityTypeConfiguration<JsonEntity>
    {
        public override void Configure(EntityTypeBuilder<JsonEntity> builder)
        {
            base.Configure(builder);

            // Additional properties
            builder.Property(x => x.Data)
                .HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), 
                v => JsonConvert.DeserializeObject<JObject>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}