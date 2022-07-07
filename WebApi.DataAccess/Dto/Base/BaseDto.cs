﻿using Mapster;
using WebApi.DataAccess.Models.Base.Entity;

namespace WebApi.DataAccess.Dto.Base
{
    public abstract class BaseDto<TDto, TModel> : BaseEntity, IRegister
        where TDto : class, new()
        where TModel : BaseEntity, new()
    {
        public TModel ToEntity()
        {
            return this.Adapt<TModel>();
        }

        public TModel ToEntity(TModel entity)
        {
            return (this as TDto).Adapt(entity);
        }

        public static TDto FromEntity(TModel entity)
        {
            return entity.Adapt<TDto>();
        }


        private TypeAdapterConfig Config { get; set; }

        public virtual void AddCustomMappings() { }


        protected TypeAdapterSetter<TDto, TModel> SetCustomMappings()
            => Config.ForType<TDto, TModel>();

        protected TypeAdapterSetter<TModel, TDto> SetCustomMappingsInverse()
            => Config.ForType<TModel, TDto>();

        public void Register(TypeAdapterConfig config)
        {
            Config = config;
            AddCustomMappings();
        }
    }
}