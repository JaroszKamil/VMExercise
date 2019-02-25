using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class Address
    {
        public string CustomerId { get; set; }

        public string Name { get; set; }

        public string AddressType { get; set; }

        public string Street { get; set; }

        public string ZIP { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}
