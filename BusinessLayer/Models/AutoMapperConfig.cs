using AutoMapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, DataCustomer>();
            CreateMap<Address, DataAddress>();
            CreateMap<DataCustomer, Customer>();
            CreateMap<DataAddress, Address>();
        }
    }
}





