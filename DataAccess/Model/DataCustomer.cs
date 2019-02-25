using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class DataCustomer
    {
        [Column(TypeName = "varchar(5)")]
        public string CustomerId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }

        public virtual ICollection<DataAddress> Addresses { get; set; }
    }
}
