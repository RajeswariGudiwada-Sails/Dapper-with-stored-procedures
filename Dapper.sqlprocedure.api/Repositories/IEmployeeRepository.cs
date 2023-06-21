using Dapper.sqlprocedure.api.Models;

namespace Dapper.sqlprocedure.api.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<bool> Add(Employee employee);
        Task<bool> Edit(Employee employee);

        Task<bool> Delete(int id);
    }
}
