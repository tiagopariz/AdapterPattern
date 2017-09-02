using AdapterPattern.Domain.Entities;
using AdapterPattern.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Web;

namespace AdapterPattern.Application
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IList<Customer> GetAllCustomers()
        {
            IList<Customer> customers;
            string storageKey = "GetAllCustomers";
            customers = (List<Customer>) HttpContext.Current.Cache.Get(storageKey);
            if (customers == null)
            {
                customers = _customerRepository.GetCustomers();
                HttpContext.Current.Cache.Insert(storageKey, customers);
            }

            return customers;
        }
    }
}
