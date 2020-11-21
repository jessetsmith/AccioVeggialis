using AccioVegialis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RecipeEdit
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string RecipeText { get; set; }
        public virtual ICollection<Vegetables> Ingredients { get; set; }

    }
}
