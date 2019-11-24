using System;
using System.Collections.Generic;
using System.Text;

namespace Leadzum.Framework.DomainModel
{
    public class ModuleModel
    {
        public ModuleModel()
        {
            Children = new List<ModuleModel>();
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
        public List<ModuleModel> Children { get; set; }
        public ModuleModel Parent { get; set; }
    }
}
