using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Common.Constants;
using RepairShopStudio.Core.Models.User;
using RepairShopStudio.Infrastructure.Data.Common.User;
using RepairShopStudio.Infrastructure.Data.Models.User;
using static RepairShopStudio.Common.Constants.ToastrMessagesConstatns;

namespace Library.Controllers
{
    [Authorize]
    public class UserController : Controller
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

        public IActionResult Index()
        {
            var users = unitOfWork.User.GetUsers();
            return View(users);
        }


        //[HttpGet]
        //[Authorize(Roles = RoleConstants.Administrator)]
        //public IActionResult Register()
        //{
        //    if (!User?.Identity?.IsAuthenticated ?? false)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var model = new RegisterViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //[Authorize(Roles = RoleConstants.Administrator)]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = new ApplicationUser()
        //    {
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        UserName = model.UserName,
        //        Email = model.Email,
        //    };

        //    var result = await userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Edit", new { id = user.Id });
        //        //return RedirectToAction("Index", "User");
        //    }

        //    foreach (var item in result.Errors)
        //    {
        //        ModelState.AddModelError("", item.Description);
        //    }


        //    return View(model);

        //}

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = UnsuccessfulOperation;
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    TempData[MessageConstant.SuccessMessage] = SuccessfullLogIn;
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData[MessageConstant.ErrorMessage] = UnsuccessfullLogin;

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData[MessageConstant.WarningMessage] = LogOut;
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Manually create default roles
        /// </summary>
        /// <returns>Create Administrator, Mechanic and Service-Adviser roles</returns>
        public async Task<IActionResult> CreateRoles()
        {
            await roleManager.CreateAsync(new ApplicationRole(RoleConstants.Administrator));
            await roleManager.CreateAsync(new ApplicationRole(RoleConstants.Mechanic));
            await roleManager.CreateAsync(new ApplicationRole(RoleConstants.ServiceAdviser));

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Manually add default users to their roles
        /// </summary>
        /// <returns>Add administraor, mechanic and service-adviser to their roles</returns>
        public async Task<IActionResult> AddUsersToRoles()
        {
            string email1 = "manager_repair_shop@mail.com";
            string email2 = "adviser_repair_shop@mail.com";
            string email3 = "mechanic_repair_shop@mail.com";

            var user = await userManager.FindByEmailAsync(email1);
            var user2 = await userManager.FindByEmailAsync(email2);
            var user3 = await userManager.FindByEmailAsync(email3);

            await userManager.AddToRolesAsync(user, new string[] { RoleConstants.Administrator, RoleConstants.ServiceAdviser, RoleConstants.Mechanic });
            await userManager.AddToRolesAsync(user2, new string[] { RoleConstants.ServiceAdviser, RoleConstants.Mechanic });
            await userManager.AddToRolesAsync(user3, new string[] { RoleConstants.Mechanic });

            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(string id)
        //{
        //    var user = unitOfWork.User.GetUser(Guid.Parse(id));
        //    var roles = unitOfWork.Role.GetRoles();

        //    var userRoles = await userManager.GetRolesAsync(user);

        //    var roleItems = new List<SelectListItem>();

        //    foreach (var role in roles)
        //    {
        //        var hasRole = userRoles.Any(ur => ur.Contains(role.Name));

        //        roleItems.Add(new SelectListItem(role.Name, role.Id.ToString(), hasRole));
        //    }

        //    var roleItemsSelect = roles.Select(r => 
        //    new SelectListItem(
        //        r.Name,
        //        r.Id.ToString(),
        //        userRoles.Any(ur => ur.Contains(r.Name)))).ToList();

        //    var viewModel = new EditUserViewModel()
        //    {
        //        User = user,
        //        Roles = roleItems
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> OnPostAsync(EditUserViewModel data)
        //{
        //    var user = unitOfWork.User.GetUser(data.User.Id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var userRolesInDb = await signInManager.UserManager.GetRolesAsync(user);

        //    var rolesToAdd = new List<string>();
        //    var rolesToDelete = new List<string>();

        //    foreach (var role in data.Roles)
        //    {
        //        var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
        //        if (role.Selected)
        //        {
        //            if (assignedInDb == null)
        //            {
        //                rolesToAdd.Add(role.Text);
        //               //await signInManager.UserManager.AddToRoleAsync(user, role.Text);
        //            }
        //        }
        //        else
        //        {
        //            if (assignedInDb != null)
        //            {
        //                rolesToDelete.Add(role.Text);
        //                //await signInManager.UserManager.RemoveFromRoleAsync(user, role.Text);
        //            }
        //        }
        //    }

        //    if (rolesToAdd.Any())
        //    {
        //        await signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
        //    }

        //    if (rolesToDelete.Any())
        //    {
        //        await signInManager.UserManager.RemoveFromRolesAsync(user, rolesToDelete);
        //    }

        //    user.FirstName = data.User.FirstName;
        //    user.LastName = data.User.LastName;
        //    user.UserName = data.User.UserName;
        //    user.Email = data.User.Email;

        //    unitOfWork.User.UpdateUser(user);

        //    return RedirectToAction("Index", "User");
        //    //return RedirectToAction("Edit", new { id = user.Id });
        //}

    }
}
