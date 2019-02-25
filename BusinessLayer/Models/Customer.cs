using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class Customer
    { 
        public string CustomerId { get; set; }

        public string Name { get; set; }

        public virtual List<Address> Addresses { get; set; }
    }
}
