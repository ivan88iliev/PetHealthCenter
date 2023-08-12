using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairShopStudio.Common.Constants;
using RepairShopStudio.Core.Models.User;
using RepairShopStudio.Infrastructure.Data.Common.User;
using RepairShopStudio.Infrastructure.Data.Models.User;

namespace RepairShopStudio.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IUnitOfWork unitOfWork;

        public UserController(
            SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationRole> _roleManager,
            IUnitOfWork _unitOfWork
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            unitOfWork = _unitOfWork;
        }

        /// <summary>
        /// Get all users from Data-Base
        /// </summary>
        /// <returns>List of all registered users</returns>
        public IActionResult Index()
        {
            var users = unitOfWork.User.GetUsers();
            return View(users);
        }

        /// <summary>
        /// Check if the current user is authenticated to register new user
        /// </summary>
        /// <returns>View with a registration form</returns>
        [HttpGet]
        [Authorize(Roles = RoleConstants.Administrator)]
        public IActionResult Register()
        {
            if (!User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <returns>Register and add new user to Data-Base</returns>
        [HttpPost]
        [Authorize(Roles = RoleConstants.Administrator)]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Edit", new { id = user.Id });
                //return RedirectToAction("Index", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }


            return View(model);

        }

        /// <summary>
        /// Get all information for a certain user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A view with information for a certain user to be edited</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = unitOfWork.User.GetUser(Guid.Parse(id));
            var roles = unitOfWork.Role.GetRoles();

            var userRoles = await userManager.GetRolesAsync(user);

            var roleItems = new List<SelectListItem>();

            foreach (var role in roles)
            {
                var hasRole = userRoles.Any(ur => ur.Contains(role.Name));

                roleItems.Add(new SelectListItem(role.Name, role.Id.ToString(), hasRole));
            }

            var roleItemsSelect = roles.Select(r =>
            new SelectListItem(
                r.Name,
                r.Id.ToString(),
                userRoles.Any(ur => ur.Contains(r.Name)))).ToList();

            var viewModel = new EditUserViewModel()
            {
                User = user,
                Roles = roleItems
            };

            return View(viewModel);
        }

        /// <summary>
        /// Tool to manage user's information and roles
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Update user information</returns>
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserViewModel data)
        {
            var user = unitOfWork.User.GetUser(data.User.Id);

            if (user == null)
            {
                return NotFound();
            }

            var userRolesInDb = await signInManager.UserManager.GetRolesAsync(user);

            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            foreach (var role in data.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        rolesToAdd.Add(role.Text);
                        //await signInManager.UserManager.AddToRoleAsync(user, role.Text);
                    }
                }
                else
                {
                    if (assignedInDb != null)
                    {
                        rolesToDelete.Add(role.Text);
                        //await signInManager.UserManager.RemoveFromRoleAsync(user, role.Text);
                    }
                }
            }

            if (rolesToAdd.Any())
            {
                await signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            if (rolesToDelete.Any())
            {
                await signInManager.UserManager.RemoveFromRolesAsync(user, rolesToDelete);
            }

            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.UserName = data.User.UserName;
            user.Email = data.User.Email;

            unitOfWork.User.UpdateUser(user);

            return RedirectToAction("Index", "User");
            //return RedirectToAction("Edit", new { id = user.Id });
        }
    }
}
