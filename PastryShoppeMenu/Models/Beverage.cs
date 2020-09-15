using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PastryShoppeMenu.Models
{
    public class Beverage
    {
        public IEnumerable<string> Sizes = new List<string> { "Small", "Medium", "Large", "Jealous" };
        public IEnumerable<string> Seasons = new List<string> { "Spring", "Summer", "Fall", "Winter" };
        public Beverage()
        {
        }

        public Beverage(int beverageId, string name, double cost, string size, string description, string createdby, bool specialDrink = false)
        {
            BeverageId = beverageId;
            Name = name;
            Cost = cost;
            Size = Sizes.FirstOrDefault(x => x.ToLower() == size.Trim(' ').ToLower()) ?? Sizes.First();
            Description = description;
            CreatedBy = createdby;
            SpecialDrink = specialDrink;
            SeasonsAvailable = Seasons.ToList();
        }

        public int BeverageId { get; set; }

        [Required]
        [Display(Name = "Beverage Name")]
        [StringLength(30, ErrorMessage = "Beverage name can't be more than 30 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$", ErrorMessage = "Numbers only please.")]
        [Range(1, 40, ErrorMessage = "Please enter a value between $1 - $40")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double Cost { get; set; }

        public string Size { get; set; }

        [StringLength(140, ErrorMessage = "Beverage description should be short and sweet. Like a tweet. ;)")]
        public string Description { get; set; }

        [StringLength(10, ErrorMessage = "Must be less than 10 characters.")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// A list for a number per season. 
        /// Spring, Summer, Fall, Winter
        /// If the list has less than 4, it is a limited edition drink. Likely sold a season.
        /// </summary>
        public List<string> SeasonsAvailable { get; set; }


        /// <summary>
        /// A drink which only appears for a short amount of time. Likely 1 week to 1 day available.
        /// </summary>
        public bool SpecialDrink { get; set; }


    }
}