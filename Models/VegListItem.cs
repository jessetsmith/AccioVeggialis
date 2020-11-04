using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccioVegialis.Models
{
    public class VegListItem
    {
        public int VegetableID { get; set; }
        public string Title { get; set; }
        [Display(Name ="Added on")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
