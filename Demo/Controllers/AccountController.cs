using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUsers> _userManager;
        SignInManager<ApplicationUsers> _signManger;
        public AccountController(UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signManger)
        {
            _userManager = userManager;
            _signManger = signManger;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginUserVm loginUserVm)
        {
            if (ModelState.IsValid)
            {
                //check db
                ApplicationUsers UserModel = await _userManager.FindByNameAsync(loginUserVm.UserName);
                if (UserModel.UserName != null)
                {
                    bool foundPass = await _userManager.CheckPasswordAsync(UserModel, loginUserVm.Password);
                    if (foundPass == true)
                    {
                        //cookie
                        await _signManger.SignInAsync(UserModel, loginUserVm.RemmberMe);
                        return RedirectToAction("Index", "Employee");

                    }
                }
                ModelState.AddModelError("", "User Name or Password Not valid");
                // cookie
            }
            return View(loginUserVm);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistarUserVM newUserVm)
        {
            if (ModelState.IsValid)
            {
                // mapping from vm to model
                ApplicationUsers model = new ApplicationUsers();
                model.UserName = newUserVm.UserName;
                model.PasswordHash = newUserVm.Password;
                model.Address = newUserVm.Address;
                //save in db
                IdentityResult result = await _userManager.CreateAsync(model, newUserVm.Password);

                if (result.Succeeded)

                {
                    //Add to role
                    await _userManager.AddToRoleAsync(model, "Student");
                    // add cookie
                    await _signManger.SignInAsync(model, false); // ID,Name,Role
                                                                 //  List<Claim> claims = new List<Claim>();
                                                                 //  claims.Add(new Claim("Color", "Red"));
                                                                 //await  _signManger.SignInWithClaimsAsync(model, false,claims);
                    return RedirectToAction("index", "Employee");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }
            }
            return View(newUserVm);
        }
        [HttpGet]
        [Authorize(Roles="Admin")]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddAdmin(RegistarUserVM newUserVm)
        {
            if (ModelState.IsValid)
            {
                // mapping from vm to model
                ApplicationUsers model = new ApplicationUsers();
                model.UserName = newUserVm.UserName;
                model.PasswordHash = newUserVm.Password;
                model.Address = newUserVm.Address;
                //save in db
                IdentityResult result = await _userManager.CreateAsync(model, newUserVm.Password);

                if (result.Succeeded)

                {
                    //Add to role
                    //  await _userManager.AddToRoleAsync(model, "Student");
                   await _userManager.AddToRoleAsync(model, "Admin");
                    // add cookie
                    await _signManger.SignInAsync(model, false); // ID,Name,Role
                                                                 //  List<Claim> claims = new List<Claim>();
                                                                 //  claims.Add(new Claim("Color", "Red"));
                                                                 //await  _signManger.SignInWithClaimsAsync(model, false,claims);
                    return RedirectToAction("index", "Employee");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }
            }
            return View(newUserVm);
        }

        public IActionResult LogOut()
        {
            _signManger.SignOutAsync();
            return RedirectToAction("LogIn");
        }


    }
}
