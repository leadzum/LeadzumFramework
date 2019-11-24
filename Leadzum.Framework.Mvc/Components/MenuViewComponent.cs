using Leadzum.Framework.IService;
using Leadzum.Framework.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leadzum.Framework.Mvc.Utility;
using AutoMapper;

namespace Leadzum.Framework.Mvc.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IModuleService moduleService;
        protected readonly IMapper mapper;
        public MenuViewComponent(IMapper mapper, IModuleService moduleService)
        {
            this.mapper = mapper;
            this.moduleService = moduleService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string area, MenuViewModel node, bool topMenu)
        {
            if (node == null)
            {
                var modules = await moduleService.GetModulesAsync(1, area);
                var menuItems = mapper.Map<List<MenuViewModel>>(modules);
                return await Task.FromResult((IViewComponentResult)View("Menu", menuItems));
            }
            else if(topMenu)
            {
                return await Task.FromResult((IViewComponentResult)View("TopMenu", node));
            }
            else
            {
                return await Task.FromResult((IViewComponentResult)View("SubMenu", node));
            }

        }
    }
}
