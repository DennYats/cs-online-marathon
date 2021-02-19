using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProductsValidation.Models
{
    public class Product
    {
        public enum Category { Toy, Technique, Clothes, Transport }

        public int Id { get; set; }

        public Category Type { get; set; }

        [Required(ErrorMessage = "Name doesn't set")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Description should be more than 2 symbols")]
        [Remote(action: "ValidDescription", controller: "Products", AdditionalFields = nameof(Name))]
        public string Description { get; set; }

        [Range(1, 100000, ErrorMessage = "Price cannot be set")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0}")]
        public decimal Price { get; set; }
    }
}
