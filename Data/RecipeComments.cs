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
        public int RecipeID {get; set; }

       // [Required]
        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser Author { get; set; }
        public int UserID { get; set; }

        [Required]
        public string CommentText { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public bool IsReply { get; set; }
        //[Required]
        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser ReplyTo { get; set; }
  
        public Guid OwnerID { get; set; }

    }

}
