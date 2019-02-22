using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LZ.Models.efdemo.Domain;
using LZ.Models.efdemo.Dto;

namespace LZ.Mappers.efdemo.DtoToDomain
{
    public class efdemoDtoDomainMapper : Profile
    {
        public efdemoDtoDomainMapper()
        {
            // TODO :: Remove these comments after implementation.
            // Use method as below and  use ReverseMap() 
            // only when the reverse config is required.
            CreateMap<BaseDomain, BaseDto>().ReverseMap();
        }
    }
}
