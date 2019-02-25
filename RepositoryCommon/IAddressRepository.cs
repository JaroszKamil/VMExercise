using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryCommon
{
    public interface IAddressRepository
    {
        DataAddress GetAddress(string customerId, string addressType);

        List<DataAddress> GetAllAddresses();

        bool UpdateAddress(DataAddress Address);

        bool UpdateListOfAddresses(List<DataAddress> Addresss);

        bool DeleteAddress(string addressType, string customerId);

        bool DeleteListOfAddresses(List<DataAddress> Addresss);

        bool CreateAddress(DataAddress Address);

        bool CreateListOfAddresses(List<DataAddress> Addresss);
    }
}
