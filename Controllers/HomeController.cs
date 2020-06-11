using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LizardPirates.Models;

namespace LizardPirates.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context {get; set;}

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("process")]
        public IActionResult Process(Lizard newbie)
        {
            if(ModelState.IsValid)
            {
                _context.Lizards.Add(newbie);
                _context.SaveChanges();
                return Redirect("/pirates");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("pirates")]
        public IActionResult Pirates()
        {
            List<Lizard> AllPirates = _context.Lizards.ToList();
            return View(AllPirates);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
