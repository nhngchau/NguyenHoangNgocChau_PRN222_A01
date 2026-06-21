using Microsoft.AspNetCore.Mvc;
namespace NguyenHoangNgocChauMVC.Controllers;
public abstract class BaseController : Controller { protected int Role => int.TryParse(HttpContext.Session.GetString("Role"),out var role)?role:-1; protected short? AccountId => (short?)HttpContext.Session.GetInt32("AccountId"); protected bool IsAdmin=>Role==0; protected bool IsStaff=>Role==1; protected IActionResult? Require(params int[] roles)=>roles.Contains(Role)?null:RedirectToAction("Login","Auth"); }
