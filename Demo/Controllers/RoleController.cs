using Demo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManger;
        public RoleController(RoleManager<IdentityRole> roleManager) {
        
            _roleManger = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> New(RoleVM roleVM)

        {
            if(ModelState.IsValid)
            {
                //save db
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = roleVM.RolrName;
               IdentityResult result= await _roleManger.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {foreach(var item in result.Errors)


                    ModelState.AddModelError("",item.Description);
                }
            }
            return View(roleVM);
        }
    }
}
