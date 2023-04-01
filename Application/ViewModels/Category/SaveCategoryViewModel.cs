using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Category
{
    public class SaveCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de la categoria")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Debe colocar el nombre de la categoria")]
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
    }
}
