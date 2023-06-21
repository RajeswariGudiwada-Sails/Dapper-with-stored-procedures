using System.Data;
using System;
using Dapper.sqlprocedure.api.Models;
using dapper.sqlprocedure.api.Context;

namespace Dapper.sqlprocedure.api.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<bool> Add(Employee employee)
        {
            int rowAffected = await _dbContext.ExecuteAsync("AddEmployee", new { id = employee.Id, name = employee.Name, address = employee.Address }, commandType: CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            int rowAffected = await _dbContext.ExecuteAsync("DeleteEmployee", new { id = id }, commandType: CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Edit(Employee employee)
        {
            int rowAffected = await _dbContext.ExecuteAsync("UpdateEmployee", employee, commandType: CommandType.StoredProcedure);
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Employee>> GetAll()
        {
            var employee = await _dbContext.QueryAsync<Employee>("GetAllEmployee", commandType: CommandType.StoredProcedure);
            return employee.ToList();
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _dbContext.QuerySingleOrDefaultAsync<Employee>("GetEmployeeByid", new { id = id }, commandType: CommandType.StoredProcedure);
            return employee;
        }
    }
}

  

