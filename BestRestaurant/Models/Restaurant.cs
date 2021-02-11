using System;
using System.ComponentModel.DataAnnotations;

namespace BestRestaurant.Models
{
    public class Restaurant
    {
        //constructor -- This sets the rank and then it can only be read and not set!
        public Restaurant(int rank)
        {
            RestaurantRanking = rank;
        }

        [Required] //Don't put a set; so that people can't change your value. Set through the constructor
        public int? RestaurantRanking { get;}

        [Required]
        public string RestaurantName { get; set; }

        public string? FavDish { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string WebsiteLink { get; set; } = "Coming soon";

        //So that this class can be accessed by other classes

        public static Restaurant[] GetRestaurants()
        {
            Restaurant r1 = new Restaurant(1)
            {
                RestaurantName = "Rancheritos",
                FavDish = "Carne Asada Fries Burrito",
                Address = "46 E 1230 N St, Provo, UT 84604",
                PhoneNumber = "(801) 374-0822",
                WebsiteLink = "https://www.rancheritosprovoonline.com/order-online"
            };

            Restaurant r2 = new Restaurant(2)
            {
                RestaurantName = "Betos",
                FavDish = "Carne Asada Fries Burrito",
                Address = "1314 N State St, Provo, UT 84604",
                PhoneNumber = "(385) 223-8056",
                WebsiteLink = "http://www.betosmexicanfood.com/"
            };

            Restaurant r3 = new Restaurant(3)
            {
                RestaurantName = "BYU Creamery",
                FavDish = "Kids Meal",
                Address = "1209 900 E, Provo, UT 84604",
                PhoneNumber = "(801) 422-2663",
                WebsiteLink = "https://dining.byu.edu/creamery/"
            };

            Restaurant r4 = new Restaurant(4)
            {
                RestaurantName = "Hruska's Kolaches",
                //FavDish = "Egg, Sausage, and Jalepeno",
                Address = "434 W Center St, Provo, UT 84601",
                PhoneNumber = "(801) 623-3578",
                //WebsiteLink = "http://hruskaskolaches.com/"
            };

            Restaurant r5 = new Restaurant(5)
            {
                RestaurantName = "J. dwags",
                FavDish = "Polish Dog",
                Address = "858 700 E, Provo, UT 84606",
                PhoneNumber = "(801) 373-3294",
                WebsiteLink = "https://jdawgs.com/"
            };

            return new Restaurant[] { r1 , r2, r3, r4, r5 };
        }
    }
}
