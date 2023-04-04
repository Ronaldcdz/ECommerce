using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Order
{
    public class ConfirmationOrderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Gracias por su compra";
        public string Description { get; set; } = "Pedido Realizado con Exito";
    }
}
