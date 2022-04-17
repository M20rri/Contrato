using System.ComponentModel.DataAnnotations;

namespace Contrato.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        public string Cost { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public string Quantity { get; set; }


        public string Description { get; set; }
    }
}
