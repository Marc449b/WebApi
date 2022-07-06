using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi.DataAccess.Models.Base.Entity;

namespace WebApi.DataAccess.Models.Derived.Misc.JsonObject
{
    public class JsonEntityEntityTypeConfiguration : BaseEntityTypeConfiguration<JsonEntity>
    {
        public override void Configure(EntityTypeBuilder<JsonEntity> builder)
        {
            base.Configure(builder);

            // Additional properties
            builder.Property(x => x.Entities)
                .HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), 
                v => JsonConvert.DeserializeObject<JObject>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}