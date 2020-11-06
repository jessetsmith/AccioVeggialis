using AccioVegialis.Data;
using AccioVegialis.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RecipeCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string RecipeText { get; set; }
        [Required]
        public virtual ICollection<Vegetables> Ingredients { get; set; }
    }
}
