using System.Collections.Generic;
using AdapterPattern.Domain.Entities;

namespace AdapterPattern.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomers();
    }
}
