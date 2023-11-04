using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Controllers
{
    public class StateMangementController : Controller
    {
        public IActionResult TestClaim()
        {
            string name = User.Identity.Name;
            Claim IdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return Content("Id :"+ IdClaim.Value);
        }
        public IActionResult SetTempData()
        {
            TempData["msg"] = "Hello temp data";
            return Content("Saved");
        }

        public IActionResult get1 ()
        {
            string message = TempData["msg"].ToString();
            return Content("get1"+message);
        }
        public IActionResult get2()
        {
            string message = "Empty";
            if (TempData.ContainsKey("msg"))
            {
                message = TempData["msg"].ToString();
            }
               
            return Content("get2" + message);
        }

        // session
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Leva");
            HttpContext.Session.SetInt32("Age", 21);

            return Content("Session saved");
        }

        public IActionResult getSession() {
        
            string name= HttpContext.Session.GetString("Name");
            int? age =  HttpContext.Session.GetInt32("Age").Value;
            return Content($"Name:{name} Age:{age}");
        }

        // cookies
        public IActionResult SetCookie()
        {
             CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires=DateTimeOffset.Now.AddDays(1);
            Response.Cookies.Append("Name", "Adhom", cookieOptions);
            Response.Cookies.Append("Age", "18");
            return Content("Cookies Saved");
        }

        public IActionResult GetCookie()
        {
            string name = Request.Cookies["Name"];
            int age= int.Parse(Request.Cookies["age"]);
            return Content($"Name:{name} Age:{age}");
        }
    }
}
