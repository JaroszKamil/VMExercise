using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Data;
using DataAccess.Model;

namespace RepositoryCommon
{
    public class AddressRepository : IAddressRepository
    {
        private VMDBContext _context;

        public AddressRepository(VMDBContext db)
        {
            _context = db;
        }

        public bool CreateAddress(DataAddress Address)
        {
            try
            {
                _context.Address.Add(Address);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool CreateListOfAddresses(List<DataAddress> Addresss)
        {
            try
            {
                Addresss.ForEach(x => _context.Address.Add(x));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteAddress(string addressType, string customerId)
        {
            try
            {
                var address =_context.Address.Where(x => x.AddressType == addressType && x.CustomerId == customerId).First();
                _context.Address.Remove(address);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteListOfAddresses(List<DataAddress> Addresss)
        {
            try
            {
                Addresss.ForEach(x => _context.Address.Remove(x));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DataAddress> GetAllAddresses()
        {
            List<DataAddress> Address = new List<DataAddress>();
            try
            {
                Address = _context.Address.ToList();

                return Address;
            }
            catch (Exception e)
            {
           
                return null;
            }
        }

        public DataAddress GetAddress(string customerId, string addressType)
        {
            DataAddress Address = new DataAddress();
            try
            {
                Address= _context.Address.Where(x => x.CustomerId == customerId && x.AddressType == addressType)
                    .First()
                    as DataAddress;

                return Address;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateAddress(DataAddress Address)
        {
            try
            {
                _context.Address.Update(Address);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateListOfAddresses(List<DataAddress> Addresss)
        {
            try
            {
                Addresss.ForEach(x => _context.Address.Update(x));
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
