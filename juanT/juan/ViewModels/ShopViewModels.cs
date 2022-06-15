using juan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juan.ViewModels
{
    public class ShopViewModels
    {
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
    }
}
