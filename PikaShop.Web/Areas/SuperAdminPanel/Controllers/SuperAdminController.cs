using Castle.Core.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Entities.Core;
using PikaShop.Data.Persistence.UnitsOfWork;
using PikaShop.Web.Areas.AdminPanel.ViewModel;

namespace PikaShop.Web.Areas.AdminPanel.Controllers
{
    [Area("SuperAdminPanel")]
    [Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        readonly UserManager<ApplicationUserEntity> _userManager;
        readonly RoleManager<ApplicationUserRoleEntity> _roleManager;
        //readonly UnitOfWork _unitOfWork;


        public SuperAdminController(UserManager<ApplicationUserEntity> userManager, RoleManager<ApplicationUserRoleEntity> roleManager)//UnitOfWork unitOfWork,)
        {
            //_unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> ManageUserRoles()
        {
            var users = await _userManager.Users.ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UsersAndRoles
            {
                Users = users,
                Roles = roles
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SetUserRole(string SelectedUserID, string SelectedUserRole)
        {
            var user = await _userManager.FindByIdAsync(SelectedUserID);
            var role = await _roleManager.FindByIdAsync(SelectedUserRole);

            if (user != null && role != null)
            {
                // Remove user from any existing roles
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                // Assign user to selected role
                var result = await _userManager.AddToRoleAsync(user, role.Name);

                if (result.Succeeded)
                {
                    // Role assignment was successful
                    TempData["SuccessMessage"] = $"Role assigned successfully to user {user.UserName}.";
                }
                else
                {
                    // Handle errors
                    TempData["ErrorMessage"] = $"An error occurred while assigning role to user {user.UserName}.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid user or role selected.";
            }

            return RedirectToAction("ManageUserRoles");
        }
    }
}