using AccioVegialis.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccioVegialis.Data
{
    public class RecipeComments
    {
        [Key]
        public int CommentID { get; set; }
        //[Required]
        [ForeignKey(nameof(RecipeID))]
        public virtual Recipes Recipe { get; set; }
        public virtual int? RecipeID {get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser Author { get; set; }
        public virtual string UserID { get; set; }

        [Required]
        public string CommentText { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }

        //public bool IsReply { get; set; }

        //[ForeignKey(nameof(UserID))]
        //public virtual ApplicationUser ReplyTo { get; set; }
    }

}
