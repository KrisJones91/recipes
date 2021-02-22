
using System.ComponentModel.DataAnnotations;

namespace recipes.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string desc { get; set; }
        public float amount { get; set; }
    }
}
