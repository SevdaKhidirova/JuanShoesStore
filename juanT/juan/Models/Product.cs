using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace juan.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile Img { get; set; }

    }
}
