
namespace Shop.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddItemViewModel
    {
        [Display(Name = "Productos")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un Producto.")]
        public int ProductId { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "La cantidad debe ser un numero positivo")]

        [Display(Name = "Cantidad")]
        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> Productos { get; set; }
    }

}
