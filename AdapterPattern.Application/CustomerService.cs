using AdapterPattern.Application.Interfaces;
using AdapterPattern.Domain.Entities;
using AdapterPattern.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace AdapterPattern.Application
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICacheStorage _cacheStorage;

        public CustomerService(ICustomerRepository customerRepository,
                               ICacheStorage cacheStorage)
        {
            _customerRepository = customerRepository;
            _cacheStorage = cacheStorage;
        }

        public IList<Customer> GetAllCustomers()
        {
            IList<Customer> customers;
            string storageKey = "GetAllCustomers";
            customers = _cacheStorage.Retrieve<List<Customer>>(storageKey);
            if (customers == null)
            {
                customers = _customerRepository.GetCustomers();
                _cacheStorage.Store(storageKey, customers);
            }

            return customers;
        }
    }
}