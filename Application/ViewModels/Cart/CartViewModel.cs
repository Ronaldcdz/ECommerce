using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Cart
{
    public class CartViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        private double _Subtotal { get; set; }

        public double Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = Price * Quantity; }
        }

    }
}
