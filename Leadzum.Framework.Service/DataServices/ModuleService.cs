using AutoMapper;
using Leadzum.Framework.Data;
using Leadzum.Framework.Data.Entities;
using Leadzum.Framework.DomainModel;
using Leadzum.Framework.DomainModel.Enumerations;
using Leadzum.Framework.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadzum.Framework.Service.DataServices
{
    public class ModuleService : BaseService, IModuleService
    {

        public ModuleService(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {

        }
        private async Task<List<ModuleModel>> GetModulesAsync(string area, int? parentId, List<int> moduleIds)
        {
            return await QueryAsync(async (dbContext) =>
            {
                var entities = await dbContext.Modules.Where(x => x.ParentId == parentId && x.Area == area && moduleIds.Contains(x.ModuleId)).OrderBy(x => x.ViewOrder).ToListAsync();
                List<ModuleModel> modules = Mapper.Map<IEnumerable<Module>, IEnumerable<ModuleModel>>(entities).ToList();
                foreach (var module in modules)
                {
                    module.Children = await GetModulesAsync(area, module.ModuleId, moduleIds);
                }
                return modules;
            });
        }

        private async Task<ModuleModel> GetModuleAsync(int moduleId, bool includeParent = true)
        {
            return await QueryAsync(async (dbContext) =>
            {
                ModuleModel module = null;
                var entity = await dbContext.Modules.FirstOrDefaultAsync(x => x.ModuleId == moduleId);
                if (entity != null)
                {
                    module = Mapper.Map<Module, ModuleModel>(entity);
                    if (includeParent && entity.ParentId.HasValue)
                    {
                        module.Parent = await GetModuleAsync(entity.ParentId.Value);
                    }
                }
                return module;
            });
        }

        private List<ModuleModel> GetModules(string area, int? parentId, List<int> moduleIds)
        {
            return Query((dbContext) =>
            {
                var entities = dbContext.Modules.Include(x => x.Parent).Where(x => x.ParentId == parentId && x.Area == area && moduleIds.Contains(x.ModuleId)).OrderBy(x => x.ViewOrder);
                List<ModuleModel> modules = Mapper.Map<IEnumerable<Module>, IEnumerable<ModuleModel>>(entities).ToList();
                foreach (var module in modules)
                {
                    module.Children = GetModules(area, module.ModuleId, moduleIds);
                }
                return modules;
            });
        }

        private ModuleModel GetModules(int moduleId, bool includeParent = true)
        {
            return Query((dbContext) =>
            {
                ModuleModel module = null;
                var entity = dbContext.Modules.FirstOrDefault(x => x.ModuleId == moduleId);
                if (entity != null)
                {
                    module = Mapper.Map<Module, ModuleModel>(entity);
                    if (includeParent && entity.ParentId.HasValue)
                    {
                        module.Parent = GetModules(entity.ParentId.Value);
                    }
                }
                return module;
            });
        }

        public async Task<List<ModuleModel>> GetModulesAsync(int userId, string area)
        {
            return await QueryAsync(async (dbContext) =>
            {
                List<ModuleModel> modules = new List<ModuleModel>();
                var user = await dbContext.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == userId);
                if (user != null && user.Roles.Count() > 0)
                {
                    List<int> moduleIds = new List<int>();
                    var role = user.Roles.First();
                    if(role.RoleId == (int)UserRole.SuperAdmin)
                    {
                        moduleIds = await dbContext.Modules.Select(x => x.ModuleId).ToListAsync();
                    }
                    else
                    {
                        var permissonIds = await dbContext.RolePermissions.Where(x => x.RoleId == role.RoleId || x.UserId == userId).Select(x => x.PermissionId).Distinct().ToListAsync();
                        moduleIds = await dbContext.Permissions.Where(x => permissonIds.Contains(x.PermissionId)).Select(x => x.ModuleId).Distinct().ToListAsync();
                    }
                    modules = await GetModulesAsync(area, null, moduleIds);
                }
                return modules;
            });
        }

        public List<ModuleModel> GetModules(int userId, string area)
        {
            return Query((dbContext) =>
            {
                List<ModuleModel> modules = new List<ModuleModel>();
                var user = dbContext.Users.Include(x => x.Roles).FirstOrDefault(x => x.Id == userId);
                if (user != null && user.Roles.Count() > 0)
                {
                    var role = user.Roles.First();
                    var permissonIds = dbContext.RolePermissions.Where(x => (x.RoleId == role.RoleId || x.UserId == userId) && x.AllowAccess).Select(x => x.PermissionId).Distinct();
                    var moduleIds = dbContext.Permissions.Where(x =>role.RoleId ==(int) UserRole.SuperAdmin || permissonIds.Contains(x.PermissionId)).Select(x => x.ModuleId).Distinct().ToList();
                    modules = GetModules(area, null, moduleIds);
                }
                return modules;
            });
        }

    }

}
