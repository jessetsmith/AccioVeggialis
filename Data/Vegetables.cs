using AccioVegialis.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccioVegialis.Data
{
    public class Vegetables    {
        public Vegetables()
        {
            this.RelatedRecipes = new HashSet<Recipes>();
            this.FavoritedBy = new HashSet<ApplicationUser>();
        }
        [Key]
        public int VegetableID { get; set; }
        [Required]        
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Recipes> RelatedRecipes { get; set; }
        public virtual ICollection<ApplicationUser> FavoritedBy { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }//?Do we need this for sure?
    }
}
