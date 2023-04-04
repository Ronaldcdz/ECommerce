using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? OwnerName { get; set; }
        public string? ContactNumber { get; set; }
        public string Address{ get; set; }
        public double Subtotal { get; set; }
        public double Taxes { get; set; }
        public double Total { get; set; }

        public ICollection<ProductOrder>? Products { get; set; }
    }
}
