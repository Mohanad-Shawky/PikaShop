
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PikaShop.Admin.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Required]
        [HiddenInput]
        public int ID { get; set; }
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public double Price { get; set; }

        public int UnitsInStock { get; set; }

        public string? Img { get; set; }
        public int? CategoryID { get; set; }
    }
}
