
using System.ComponentModel.DataAnnotations;

namespace recipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }

    }
}