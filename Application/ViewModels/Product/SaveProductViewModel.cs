using ECommerce.Application.Models;
using ECommerce.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Product
{
    public class SaveProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del producto")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la descripcion del producto")]
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe colocar el url de la imagen")]
        [DataType(DataType.Text)]
        public string ImagePath { get; set; }


        [Required(ErrorMessage = "Debe colocar el precio del producto")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la cantidad existente de este producto")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la cantidad existente de este producto")]
        public int CategoryId { get; set; }


        public List<CategoryViewModel>? Category { get; set; }
    }
}
