using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_7.DAL;
using The_7.Extensions;
using The_7.Helpers;
using The_7.Models;

namespace The_7.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Team> team = _context.Teams.ToList();

            return View(team);
        }
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Team db=_context.Teams.Find(id);
            if (db==null)
            {
                return NotFound();
            }
            Helper.DeleteImage(db.ImageUrl,"images/team",_env);
            _context.Remove(db);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Team team)
        {
            if (ModelState["Photo"].ValidationState==Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!team.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Ancaq sekil sece bilersiniz");
            }
            if (team.Photo.CheckSize(8000))
            {
                ModelState.AddModelError("Photo", "Sekilin olcusu 8,b ola biler");
            }
            string filename = await team.Photo.SaveImage(_env,"images/team");
            Team db=new Team();
            db.ImageUrl=filename;
            db.Name=team.Name;
            db.Position=team.Position;
            db.Insta=team.Insta;
            db.Linkedin=team.Linkedin;
            db.Googleplus=team.Googleplus;
            db.Twitter=team.Twitter;
            await _context.Teams.AddAsync(db);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Team Team = await _context.Teams.FindAsync(id);
            if (Team == null) return NotFound();
            return View(Team);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Team team, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!team.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Ancaq sekil sece bilersiniz");
            }
            if (team.Photo.CheckSize(8000))
            {
                ModelState.AddModelError("Photo", "Sekilin olcusu 8,b ola biler");
            }
            Team existtitle = _context.Teams.FirstOrDefault(c => c.Name.ToLower() == team.Name.ToLower());
            Team db = await _context.Teams.FindAsync(id);
            if (existtitle != null)
            {
                if (db != existtitle)
                {
                    ModelState.AddModelError("Name", "Title Already Exist");
                    return View();
                }
            }
            if (db == null)
            {
                return NotFound();
            }

            string filename = await team.Photo.SaveImage(_env, "images/team");
            db.ImageUrl = filename;
            db.Name = team.Name;
            db.Position = team.Position;
            db.Insta = team.Insta;
            db.Linkedin = team.Linkedin;
            db.Googleplus = team.Googleplus;
            db.Twitter = team.Twitter;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Team Team = await _context.Teams.FindAsync(id);
            if (Team == null)
            {
                return NotFound();
            }
            return View(Team);
        }
    }
}
