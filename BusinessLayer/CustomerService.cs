using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Models;
using DataAccess.Model;
using RepositoryCommon;

namespace BusinessLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            repo = repository;
            _mapper = mapper;
        }

        public bool CreateCustomer(Customer customer)
        {
            DataCustomer dataCustomer = _mapper.Map<Customer, DataCustomer>(customer);
            return repo.CreateCustomer(dataCustomer);
        }

        public bool CreateListOfCustomers(List<Customer> customers)
        {
            return repo.CreateListOfCustomers(_mapper.Map<List<Customer>, List<DataCustomer>>(customers));  
        }

        public bool DeleteCustomer(string customerId, string name)
        {
           return repo.DeleteCustomer(customerId, name);
        }

        public bool DeleteListOfCustomer(List<Customer> customers)
        {
            return repo.DeleteListOfCustomer(_mapper.Map<List<Customer>, List<DataCustomer>>(customers));
        }

        public List<Customer> GetAllCustomers()
        {
            return _mapper.Map<List<DataCustomer>, List<Customer>>(repo.GetAllCustomers());
        }

        public Customer GetCustomer(string customerId)
        {
            return _mapper.Map<DataCustomer, Customer>(repo.GetCustomer(customerId));
        }

        public bool UpdateCustomer(Customer customer)
        {
            return repo.UpdateCustomer(_mapper.Map<Customer, DataCustomer>(customer));
        }

        public bool UpdateListOfCustomers(List<Customer> customers)
        {
            return repo.UpdateListOfCustomers(_mapper.Map<List<Customer>, List<DataCustomer>>(customers));
        }
    }
}
