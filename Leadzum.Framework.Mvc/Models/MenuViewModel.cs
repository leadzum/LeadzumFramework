using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leadzum.Framework.Mvc.Models
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            Children = new List<MenuViewModel>();
        }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IconFile { get; set; }
        public int ViewOrder { get; set; }
        public bool IsClickable { get; set; }
        public bool IsVisable { get; set; }
        public string Url { get; set; }
        public List<MenuViewModel> Children { get; set; }
        public MenuViewModel Parent { get; set; }

        public bool IsActive { get; set; }
    }
}
