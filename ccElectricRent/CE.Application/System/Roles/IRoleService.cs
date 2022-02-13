using CE.ViewModel.System.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.System.Roles
{
   public interface IRoleService
    {
        Task<List<RoleViewModels>> GetAll();
    }
}
