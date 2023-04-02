using ECommerce.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
