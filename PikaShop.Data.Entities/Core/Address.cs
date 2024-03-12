using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Entities.Core
{
    public class Address
    {
        public string State { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FloorNumber { get; set; }
        public string AppartmentNumber { get; set; }

        public Address()
        {
            State = string.Empty;
            Region = string.Empty;
            Street = string.Empty;
            BuildingNumber = string.Empty;
            FloorNumber = string.Empty;
            AppartmentNumber = string.Empty;
        }
    }
}
