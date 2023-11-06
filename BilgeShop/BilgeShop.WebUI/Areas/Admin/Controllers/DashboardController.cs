using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]//program.cs'teki area:exists kısmı ile eşleşir.
    [Authorize(Roles="Admin")]//Claimlerdeki claims.Add(new Claim(ClaimTypes.Role,userInfo.UserType.ToString()));
    //kısmı ile eşleşiyor.
    //Yukarıda yazdığım authorize sayesinde,yetkisi admin olmayan kişiler buraya
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
