using AutoMapper;
using Leadzum.Framework.DomainModel;
using Leadzum.Framework.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leadzum.Framework.Mvc.Utility
{
    public class ViewModelToDomainModelProfile : Profile
    {
        public ViewModelToDomainModelProfile()
        {
            CreateMap<ModuleModel, MenuViewModel>();
        }
    }
}
