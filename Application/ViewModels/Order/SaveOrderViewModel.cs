using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Order
{
    public class SaveOrderViewModel
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Debe colocar su nombre")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string OwnerName { get; set; }


        [Required(ErrorMessage = "Debe colocar su numero telefonico")]
        [StringLength(12)]
        [DataType(DataType.Text)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Debe colocar su direccion")]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string Address { get; set; }


        [Required(ErrorMessage = "Debe colocar el nombre titular de la tarjeta")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string CreditCardOwnerName { get; set; }


        [Required(ErrorMessage = "Debe colocar el numero de la tarjeta")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Debe colocar la vigencia de la tarjeta")]
        public string CreditCardValidity { get; set; }

        [Required(ErrorMessage = "Debe colocar el cvv de la tarjeta")]
        [StringLength(3)]
        [DataType(DataType.Currency)]
        public string CreditCardCvv { get; set; }



        public double Subtotal { get; set; }

        public double Taxes { get; set; }

        public double Total { get; set; }

        public List<CartViewModel>? CartItems { get; set; }
    }
}
