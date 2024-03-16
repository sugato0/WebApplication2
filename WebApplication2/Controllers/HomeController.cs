using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Products> names = new List<Products>() { };

        public static List<Products> buscet_products = new List<Products>() { };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


            names.Add(new Products
            {
                Id = 0,
                Name = "Кофе",
                Price = 300,
                description = "Очень вкусный кофе"
            });
            names.Add(new Products
            {
                Id = 1,
                Name = "Чай",
                Price = 200,
                description = "Чай как чай"
            });



            return View(names);
        }
        // Home/basket

        public RedirectResult bascet_add(int id)
        {
             
            buscet_products.Add(names[id]);
            return Redirect("/");
        }
        public IActionResult bascet()
        {
            ViewData["sale"] = "Все по 50 рублей";
            return View(buscet_products);
        }
        public RedirectResult bascet_delete(int id)
        {
            buscet_products.RemoveAt(id);
            return Redirect("/Home/bascet");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}