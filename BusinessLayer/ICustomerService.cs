using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface ICustomerService
    {
        Customer GetCustomer(string customerId);

        List<Customer> GetAllCustomers();

        bool UpdateCustomer(Customer customer);

        bool UpdateListOfCustomers(List<Customer> customers);

        bool DeleteCustomer(string customerId, string name);

        bool DeleteListOfCustomer(List<Customer> customers);

        bool CreateCustomer(Customer customer);

        bool CreateListOfCustomers(List<Customer> customers);
    }
}
