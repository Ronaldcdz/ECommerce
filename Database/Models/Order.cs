using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Subtotal { get; set; }
        public double Price { get; set; }
        public double Taxes { get; set; }
        public double Total { get; set; }

        public ICollection<ProductOrder>? Products { get; set; }
    }
}
