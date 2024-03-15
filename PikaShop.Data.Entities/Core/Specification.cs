using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Entities.Core
{
    public class Specification
    {
        public string Key;
        public string Value;

        public Specification() 
        {
            Key=string.Empty;
            Value=string.Empty;
        }
    }
}
