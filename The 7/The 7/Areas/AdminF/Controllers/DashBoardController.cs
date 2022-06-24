using Microsoft.AspNetCore.Mvc;

namespace The_7.Areas.AdminF.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("AdminF")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
