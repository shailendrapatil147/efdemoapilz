using AutoMapper;
using LZ.Models.efdemo.Domain;
using LZ.Models.efdemo.Dto;
using LZ.Models.efdemo.Entity;

namespace LZ.Mappers.efdemo
{
    public static class efdemoMapperExtension
    {

        public static BaseDto ToDto(this IMapper mapper, BaseDomain baseDomain)
        {
            return mapper.Map<BaseDto>(baseDomain);
        }

        public static BaseDomain ToDomain(this IMapper mapper, BaseEntity baseEntity)
        {
            return mapper.Map<BaseDomain>(baseEntity);
        }
    }
}
