using AccioVegialis.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RecipeCommentsDetail
    {
        public int CommentID { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public string CommentText { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC{ get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
        //public bool IsReply { get; set; }
}
