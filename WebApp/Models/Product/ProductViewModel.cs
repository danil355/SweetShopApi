using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}