using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RecipeCommentsCreate
    {
        //[Required]
        //public int RecipeID { get; set; }
        [Required]        
        [MaxLength(800, ErrorMessage = "There are too many characters in this field.")]
        
        public string CommentText { get; set; }
        
    }
}
