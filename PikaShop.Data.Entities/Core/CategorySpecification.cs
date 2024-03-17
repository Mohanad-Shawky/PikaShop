using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Entities.Core
{
    public class CategorySpecification
    {
        public string Key {  get; set; }
        public string Value {  get; set; }
        public bool Searchable {  get; set; }
    }
}
