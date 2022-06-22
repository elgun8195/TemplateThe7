using Microsoft.AspNetCore.Mvc;
using System.Linq;
using The_7.DAL;
using The_7.ViewModels;

namespace The_7.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Blog = _context.Blogs.ToList();
            homeVM.Work = _context.Works.ToList();
            homeVM.Team=_context.Teams.ToList();    
            return View(homeVM);
        }
    }
}
