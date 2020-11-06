using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccioVegialis.Models
{
    public class VegetableCreate
    {
        [Required]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters for the Title.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
