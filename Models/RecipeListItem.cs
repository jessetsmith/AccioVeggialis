using AccioVegialis.Data;
using AccioVegialis.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RecipeListItem
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string RecipeText { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual ICollection<ApplicationUser> FavoritedBy {get; set;}
        public virtual ICollection<Vegetables> Ingredients { get; set; }
        public virtual ICollection<RecipeComments> Comments { get; set; }
    }
}
