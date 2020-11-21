using AccioVegialis.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class RecipeCommentsListItem
    {
        public int CommentID { get; set; }
        public virtual ApplicationUser Author { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        
    }
        //public string CommentText { get; set; }
}
