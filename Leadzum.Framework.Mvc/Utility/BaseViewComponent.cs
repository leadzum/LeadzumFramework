using AutoMapper;
using Leadzum.Framework.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leadzum.Framework.Mvc.Utility
{
    public class BaseViewComponent : ViewComponent
    {
        protected readonly IMapper mapper;
        public BaseViewComponent(IMapper mapper)
        {
            this.mapper = mapper;
        }

    }
}
