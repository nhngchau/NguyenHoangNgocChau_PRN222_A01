using Microsoft.AspNetCore.Mvc;
using NguyenHoangNgocChauBusinessObjects.Services;

namespace NguyenHoangNgocChauMVC.Controllers;
public class AuthController(IAuthService auth) : Controller
{
    [HttpGet] public IActionResult Login() => View();
    [HttpPost] public async Task<IActionResult> Login(string email, string password) { var result=await auth.LoginAsync(email,password); if(result is null){ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");return View();} HttpContext.Session.SetString("Role",result.Role.ToString()); HttpContext.Session.SetString("Name",result.Name); if(result.AccountId.HasValue)HttpContext.Session.SetInt32("AccountId",result.AccountId.Value); return RedirectToAction("Index","News"); }
    public IActionResult Logout(){HttpContext.Session.Clear();return RedirectToAction(nameof(Login));}
}
