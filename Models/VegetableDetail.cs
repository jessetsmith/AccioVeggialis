using AccioVegialis.Data;
using AccioVegialis.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VegetableDetail
    {
        public int VegetableID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Recipes> RelatedRecipes { get; set; }
        public virtual ICollection<ApplicationUser> FavoritedBy { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }//?Do we need this for sure?
    }
}
