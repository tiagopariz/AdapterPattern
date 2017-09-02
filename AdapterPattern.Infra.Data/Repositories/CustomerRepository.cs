using System.Collections.Generic;
using AdapterPattern.Domain.Entities;
using AdapterPattern.Domain.Interfaces.Repositories;

namespace AdapterPattern.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IList<Customer> GetCustomers()
        {
            return new List<Customer>();
        }
    }
}