using Leadzum.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leadzum.Framework.IService
{
    public interface IModuleService
    {
        Task<List<ModuleModel>> GetModulesAsync(int userId, string area);
        List<ModuleModel> GetModules(int userId, string area);
    }

}
