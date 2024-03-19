using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Entities.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string Specifications { get; set; }
        public double Price { get; set; }
        public int UnitsInStock { get; set; }
        public string? Img {  get; set; }
        public Product()
        {
            Name = string.Empty;
            Description = string.Empty;
           Img= string.Empty;
        }
    }
}
