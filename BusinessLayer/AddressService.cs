using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer;
using BusinessLayer.Models;
using DataAccess.Model;
using RepositoryCommon;

namespace BusinessLayer
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository repo;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            repo = repository;
            _mapper = mapper;
        }

        public bool CreateAddress(Address Address)
        {
            DataAddress dataAddress = _mapper.Map<Address, DataAddress>(Address);
            return repo.CreateAddress(dataAddress);
        }

        public bool CreateListOfAddresses(List<Address> Addresss)
        {
            return repo.CreateListOfAddresses(_mapper.Map<List<Address>, List<DataAddress>>(Addresss));  
        }

        public bool DeleteAddress(string addressType, string customerId)
        {
           return repo.DeleteAddress(addressType, customerId);
        }

        public bool DeleteListOfAddress(List<Address> Addresss)
        {
            return repo.DeleteListOfAddresses(_mapper.Map<List<Address>, List<DataAddress>>(Addresss));
        }

        public List<Address> GetAllAddresss()
        {
            return _mapper.Map<List<DataAddress>, List<Address>>(repo.GetAllAddresses());
        }

        public Address GetAddress(string customerId, string addressType)
        {
            return _mapper.Map<DataAddress, Address>(repo.GetAddress(customerId, addressType));
        }

        public bool UpdateAddress(Address Address)
        {
            return repo.UpdateAddress(_mapper.Map<Address, DataAddress>(Address));
        }

        public bool UpdateListOfAddresss(List<Address> Addresss)
        {
            return repo.UpdateListOfAddresses(_mapper.Map<List<Address>, List<DataAddress>>(Addresss));
        }
    }
}
