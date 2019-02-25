using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryCommon
{
    public interface ICustomerRepository
    {
        DataCustomer GetCustomer(string customerId);

        List<DataCustomer> GetAllCustomers();

        bool UpdateCustomer(DataCustomer customer);

        bool UpdateListOfCustomers(List<DataCustomer> customers);

        bool DeleteCustomer(string customerId, string name);

        bool DeleteListOfCustomer(List<DataCustomer> customers);

        bool CreateCustomer(DataCustomer customer);

        bool CreateListOfCustomers(List<DataCustomer> customers);
    }
}
