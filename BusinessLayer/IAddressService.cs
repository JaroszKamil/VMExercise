using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IAddressService
    {
        Address GetAddress(string customerId, string addressType);

        List<Address> GetAllAddresss();

        bool UpdateAddress(Address Address);

        bool UpdateListOfAddresss(List<Address> Addresss);

        bool DeleteAddress(string addressType, string customerId);

        bool DeleteListOfAddress(List<Address> Addresss);

        bool CreateAddress(Address Address);

        bool CreateListOfAddresses(List<Address> Addresss);
    }
}
