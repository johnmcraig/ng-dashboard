using DataDashboard.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDashboard.Core.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> Create(Customer entity);
        Task<IList<Customer>> FindBySearch(string search);
        Task<IList<Customer>> ListAllWithPaging(int page, int pageSize);
        Task<IList<Customer>> ListAllWithSearchingAndPaging(string search, int page, int pageSize);
        Task Update(Customer customer);
        Task Delete(int id);
    }
}