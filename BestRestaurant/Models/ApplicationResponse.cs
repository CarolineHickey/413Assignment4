using System;
using System.ComponentModel.DataAnnotations;

namespace BestRestaurant.Models
{
    public class ApplicationResponse
    {
        [Required]
        public string myName { get; set; }

        [Required]
        public string myRestaurantName { get; set; }

        [Required]
        public string myFavDish { get; set; }

        //[RegularExpression("^[0 - 9]{3}")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?\d{3}?\)??-??\(?\d{3}?\)??-??\(?\d{4}?\)??-?$", ErrorMessage = "Not a valid phone number")]
        public string myPhoneNumber { get; set; }
    }
}
