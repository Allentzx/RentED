using CE.Data.Entity;
using CE.ViewModel.System.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleViewModels>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleViewModels()
                {
                    Id = x.Id,
                    RoleName = x.Name,
                    Description = x.Description
                }).ToListAsync();

            return roles;
        }

        Task<List<RoleViewModels>> IRoleService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
