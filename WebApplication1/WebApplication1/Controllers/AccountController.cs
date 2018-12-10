using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Models;
using PumpedUpKicks.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PumpedUpKicks.Data;
using PumpedUpKicks.Models.Interfaces;

namespace PumpedUpKicks.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDBContext _context;
        private readonly ISendGrid _sendGrid;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDBContext context, ISendGrid sendGrid)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _sendGrid = sendGrid;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                CheckUserRolesExist();
                // start the registration process
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthday = rvm.Birthday
                };
                
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    // Custom type for full name claim
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    // Custom birthday claim
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Month, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    List<Claim> myClaims = new List<Claim>()
                    {
                        fullNameClaim,
                        birthdayClaim,
                        emailClaim,
                    };
                    bool IsAdmin = false;
                    if (rvm.Email == "ercain3@gmail.com" || rvm.Email == "su@cat3.com")
                    {
                        IsAdmin = true;
                        await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
                    }

                    await _userManager.AddToRoleAsync(user, UserRoles.Member.ToString());
                    await _userManager.AddClaimAsync(user, fullNameClaim);
                    await _userManager.AddClaimsAsync(user, myClaims);
                    await _userManager.AddClaimAsync(user, birthdayClaim);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _sendGrid.SendRegisterEmail(user.Email, string.Join(" ", user.FirstName, user.LastName));

                    if (IsAdmin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(rvm);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {

                    IList<ApplicationUser> users = await _userManager.GetUsersInRoleAsync(UserRoles.Admin.ToString());
                    
                    if (users.Where( u => u.UserName == lvm.Email).ToList().Count > 0)
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                }
            }
            return View(lvm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async void CheckUserRolesExist()
        {
            if(!_context.Roles.Any())
            {
                List<IdentityRole> Roles = new List<IdentityRole>
                {
                    new IdentityRole(UserRoles.Admin) { NormalizedName = UserRoles.Admin.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString()},
                    new IdentityRole(UserRoles.Member){ NormalizedName = UserRoles.Member.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString()},
                };

                foreach (var role in Roles)
                {
                    _context.Roles.Add(role);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}