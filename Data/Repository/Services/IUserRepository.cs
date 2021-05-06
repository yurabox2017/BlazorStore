using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public interface IUserRepository
    {
        public Task<List<IdentityUser>> GetAllUsersAsync();
        public Task<List<IdentityRole>> GetAllRolesAsync();
        public Task<bool> SetLockUserAsync(IdentityUser identityUser, bool isLock, int days);
        public Task<IList<string>> GetUserRolesAsync(IdentityUser identityUser);
        public Task<bool> EditRoleAsync(IdentityUser identityUser, IList<string> roles);

    }
}
