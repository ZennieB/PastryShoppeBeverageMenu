using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class BeverageModel
    {
        public int Id { get; set; }
        public int DrinkId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public bool SpecialDrink { get; set; }
    }
}
