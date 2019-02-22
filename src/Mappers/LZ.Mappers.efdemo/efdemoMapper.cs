using AutoMapper;
using LZ.Mappers.efdemo.DtoToDomain;
using LZ.Mappers.efdemo.EntityToDomain;

namespace LZ.Mappers.efdemo
{
    public class efdemoMapper
    {
        /// <summary>
        /// Get the mapper object.
        /// </summary>
        public IMapper Mapper { get; }

        /// <summary>
        /// Get the mapper object.
        /// </summary>
        public efdemoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new efdemoDtoDomainMapper());
                //cfg.AddProfile(new efdemoEntityDomainMapper());
            });


            this.Mapper = config.CreateMapper();
        }
    }
}
