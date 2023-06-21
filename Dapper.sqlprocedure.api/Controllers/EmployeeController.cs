using Dapper.sqlprocedure.api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CoreApiResponse;
using Dapper.sqlprocedure.api.Models;

namespace Dapper.sqlprocedure.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResult("Data load successfully.", await employeeRepository.GetAll());
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return CustomResult("Data load successfully.", await employeeRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            try
            {
                bool isSaved = await employeeRepository.Add(employee);
                if (isSaved)
                {
                    return CustomResult("Student has been saved.", employee);
                }
                return CustomResult("Student saved failed.", HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Employee employee)
        {
            try
            {
                bool isUpdated = await employeeRepository.Edit(employee);
                if (isUpdated)
                {
                    return CustomResult("Student has been modified.", employee);
                }
                return CustomResult("Student modified failed.", HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isDeleted = await employeeRepository.Delete(id);
                if (isDeleted)
                {
                    return CustomResult("Student has been deleted.");
                }
                return CustomResult("Student deleted failed.", HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
