using AccioVegialis.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccioVegialis.Models
{
    public class VegetableEdit
    {
        public int VegetableID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Recipes> RelatedRecipes { get; set; }

    }
}
