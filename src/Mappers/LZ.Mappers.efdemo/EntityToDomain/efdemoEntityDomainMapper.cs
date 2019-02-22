using AutoMapper;
using LZ.Models.efdemo.Dto.Contracts;
using LZ.Models.efdemo.Entity.Contracts;
using System.Collections.Generic;

namespace LZ.Mappers.efdemo.EntityToDomain
{
    public static class efdemoEntityDomainMapper
    {
        private static IMapper mapper = ConfigMapper();

        //public efdemoEntityDomainMapper()
        //{
            // TODO :: Remove these comments after implementation.
            // Use method as below and  use ReverseMap() 
            // only when the reverse config is required.
            //CreateMap<BaseDomain, BaseEntity>().ReverseMap();
        //}

        public static IMapper ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, User>()
                    //.ForMember(dest => dest, m => m.MapFrom(src => src.PkCart))
                    //.ForMember(dest => dest.UserDetailId, m => m.MapFrom(src => src.UserDetailId
                    //    .Select(e => mapper.Map<CartItemDomain>(e))
                    //    .ToList()))
                    //.ForMember(dest => dest.OrderId, m => m.MapFrom(src => src.FkOrder))
                    .ReverseMap();
                // .ForMember(dest => dest.CartItem, m => m.MapFrom(src => src.CartItems.Select(x => x.ToEntity())));

                cfg.CreateMap<UserContactEntity, UserContact>()
                    //.ForMember(dest => dest, m => m.MapFrom(src => src.PkCart))
                    //.ForMember(dest => dest.UserDetailId, m => m.MapFrom(src => src.UserDetailId
                    //    .Select(e => mapper.Map<CartItemDomain>(e))
                    //    .ToList()))
                    //.ForMember(dest => dest.OrderId, m => m.MapFrom(src => src.FkOrder))
                    .ReverseMap();

                cfg.CreateMap<UserDetailsEntity, UserDetails>()
                    //.ForMember(dest => dest, m => m.MapFrom(src => src.PkCart))
                    //.ForMember(dest => dest.UserDetailId, m => m.MapFrom(src => src.UserDetailId
                    //    .Select(e => mapper.Map<CartItemDomain>(e))
                    //    .ToList()))
                    //.ForMember(dest => dest.OrderId, m => m.MapFrom(src => src.FkOrder))
                    .ReverseMap();
            });

            return mapper = config.CreateMapper();
        }

        public static User ToDomain(this UserEntity userEntity)
        {
            return mapper.Map<User>(userEntity);
        }

        public static List<User> ToDomain(this List<UserEntity> userEntity)
        {
            return mapper.Map<List<User>>(userEntity);
        }

        public static UserEntity ToEntity(this User user)
        {
            return mapper.Map<UserEntity>(user);
        }
    }
}
