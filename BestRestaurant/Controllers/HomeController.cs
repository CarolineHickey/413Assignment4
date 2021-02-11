using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BestRestaurant.Models;

namespace BestRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> restaurantListHome = new List<string>();

            foreach (Restaurant r in Restaurant.GetRestaurants())
            {
                string myDish = (r.FavDish == "" ^ r.FavDish is null) ? "It's all tasty" : r.FavDish;
                //string? myDish = r.FavDish ?? "It's all tasty";

                restaurantListHome.Add(string.Format("#{0}: {1}, {2}, {3}, {4}, {5}", r.RestaurantRanking, r.RestaurantName, myDish, r.PhoneNumber, r.Address, r.WebsiteLink));
            }

            return View(restaurantListHome);
            //return View();
        }

        [HttpGet("List")]//This gives it kind of a URL... type in /List and this page will be rendered
        public IActionResult RestaurantList()
        {
            List<string> restaurantList = new List<string>();

            foreach (Restaurant r in Restaurant.GetRestaurants())
            {
                string myDish = (r.FavDish == "" ^ r.FavDish is null) ? "It's all tasty" : r.FavDish;
                //string? myDish = r.FavDish ?? "It's all tasty";

                restaurantList.Add(string.Format("#{0}: {1}, {2}, {3}, {4}, {5}", r.RestaurantRanking, r.RestaurantName, myDish, r.PhoneNumber, r.Address, r.WebsiteLink));
            }

            return View(restaurantList);
        }

        [HttpGet]
        public IActionResult AddRestaurant()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRestaurant(ApplicationResponse appResponse)
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddApplication(appResponse);
                return View("Confirmation", appResponse);
            }
            else
            {
                return View();
            }

        }

        public IActionResult ReccomendationList()
        {
            return View(TempStorage.Applications);
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
