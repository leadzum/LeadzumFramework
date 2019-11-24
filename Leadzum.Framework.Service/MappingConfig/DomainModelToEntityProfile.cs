using AutoMapper;
using Leadzum.Framework.Data.Entities;
using Leadzum.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.Service.MappingConfig
{
    public class DomainModelToEntityProfile : Profile
    {
        public DomainModelToEntityProfile()
        {
            CreateMap<ModuleModel, Module>().ReverseMap().
                ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent));
        }
    }
}