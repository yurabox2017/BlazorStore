using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public class DbUserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbUserRepository(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public async Task<bool> EditRoleAsync(IdentityUser identityUser, IList<string> roles)
        {
            if (roles is null && identityUser is null)
                return false;
            await _userManager.RemoveFromRolesAsync(identityUser, roles);
            await _userManager.AddToRolesAsync(identityUser, roles);
            //await _userManager.UpdateAsync(identityUser);
            return true;
        }

        public async Task<List<IdentityRole>> GetAllRolesAsync() => await _roleManager.Roles.ToListAsync();
        public async Task<List<IdentityUser>> GetAllUsersAsync() => await _userManager.Users.ToListAsync();

        public async Task<IList<string>> GetUserRolesAsync(IdentityUser identityUser) => await _userManager.GetRolesAsync(identityUser);

        public async Task<bool> SetLockUserAsync(IdentityUser identityUser, bool isLock, int days)
        {
            if (identityUser is null)
                return false;

            await _userManager.SetLockoutEnabledAsync(identityUser, true);
            await _userManager.SetLockoutEndDateAsync(identityUser, DateTime.Now.AddYears(days));
            return true;
        }

    }
}
