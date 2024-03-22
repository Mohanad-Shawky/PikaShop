#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PikaShop.Admin.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        [Required]
        [HiddenInput]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Department")]
        public int? DepartmentID { get; set; }
    }
}
