using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class DataAddress
    {
        [Column(TypeName = "varchar(5)")]
        public string CustomerId { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string AddressType {get;set;}

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ZIP { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string Country { get; set; }

        [ForeignKey("AddressType")]
        public virtual DataCustomer Customer { get; set; }

    }
}
