using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Data;
using DataAccess.Model;

namespace RepositoryCommon
{
    public class CustomerRepository : ICustomerRepository
    {
        private VMDBContext _context;

        public CustomerRepository(VMDBContext db)
        {
            _context = db;
        }

        public bool CreateCustomer(DataCustomer customer)
        {
            try
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateListOfCustomers(List<DataCustomer> customers)
        {
            try
            {
                customers.ForEach(x => _context.Customer.Add(x));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCustomer(string customerId, string name)
        {
            try
            {
                var customer =_context.Customer.Where(x => x.CustomerId == customerId
                && x.Name == name).First();
                _context.Customer.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteListOfCustomer(List<DataCustomer> customers)
        {
            try
            {
                customers.ForEach(x => _context.Customer.Remove(x));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DataCustomer> GetAllCustomers()
        {
            List<DataCustomer> customers = new List<DataCustomer>();
            try
            {
                customers = _context.Customer.ToList();

                return customers;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public DataCustomer GetCustomer(string customerId)
        {
            DataCustomer customer = new DataCustomer();
            try
            {
                return _context.Customer.Where(x => x.CustomerId == customerId).Select(x =>
                new DataCustomer()
                {
                    CustomerId = x.CustomerId,
                    Name = x.Name,
                    Addresses = _context.Address.Where(y => y.CustomerId == x.CustomerId).ToList()
                }).First();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateCustomer(DataCustomer customer)
        {
            try
            {
                _context.Customer.Update(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateListOfCustomers(List<DataCustomer> customers)
        {
            try
            {
                customers.ForEach(x => _context.Customer.Update(x));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
