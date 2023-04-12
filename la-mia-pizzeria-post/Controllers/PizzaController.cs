using la_mia_pizzeria_post.Models;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly PizzeriaContext _context;

        public PizzaController(ILogger<PizzaController> logger, PizzeriaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("Menu")]
        public IActionResult Menu()
        {
            var pizze = _context.Pizzas.ToArray();
            return View(pizze);
        }

        [HttpGet("Contacts")]
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Details(long id)
        {
            var pizza = _context.Pizzas!.SingleOrDefault(p => p.Id == id);

            if (pizza is null)
            {
                return NotFound($"Pizza with id {id} not found.");
            }

            return View(pizza);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            _context.Pizzas!.Add(pizza);
            _context.SaveChanges();

            return RedirectToAction("Menu");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}