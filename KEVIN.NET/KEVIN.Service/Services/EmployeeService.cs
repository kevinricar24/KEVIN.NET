using KEVIN.Contract;
using KEVIN.Contract.Interfaces;
using KEVIN.Contract.Interfaces.Services;
using KEVIN.Data.Model;
using KEVIN.Domain.Dtos;
using KEVIN.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KEVIN.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMyDBContext _context;

        public EmployeeService(IMyDBContext context)
        {
            _context = context; 
        }

        public async Task<IResponsePackage<string>> CreateAsync(EmployeeDto employee)
        {
            var responsePackage = new ResponsePackage<string>();

            try
            {
                if (employee is not null)
                {
                    var newEmployee = new Employee()
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        PhoneNumber = employee.PhoneNumber,
                        HireDate = employee.HireDate,
                        JobId = employee.JobId,
                        Salary = employee.Salary,
                        ManagerId = employee.ManagerId,
                        DepartmentId = employee.DepartmentId
                    };
                    await _context.Employees.AddAsync(newEmployee);
                    _context.SaveChanges();

                    responsePackage.Payload = $"employee created with ID {newEmployee.EmployeeId}";
                    responsePackage.Id = newEmployee.EmployeeId;
                }
            }
            catch (Exception ex)
            {
                responsePackage.StatusCode = StatusCodes.Status500InternalServerError;
                responsePackage.Errors = ex.Message;
            }

            return responsePackage;
        }

        public async Task<IResponsePackage<string>> DeleteAsync(int id)
        {
            var responsePackage = new ResponsePackage<string>();

            try
            {
                var employee = await _context.Employees.FindAsync(id);

                if (employee is not null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();

                    var employeeCheck = await _context.Employees.FindAsync(id);

                    if(employeeCheck is null)
                    {
                        responsePackage.Payload = $"employee deleted with ID {id}";
                        responsePackage.Id = id;
                    }
                }
            }
            catch (Exception ex)
            {
                responsePackage.StatusCode = StatusCodes.Status500InternalServerError;
                responsePackage.Errors = ex.Message;
            }

            return responsePackage;
        }

        public async Task<IResponsePackage<List<EmployeeResponseDto>>> GetAllAsync()
        {
            var responsePackage = new ResponsePackage<List<EmployeeResponseDto>>();

            if(_context.Employees.Any())
            {
                var employees = await(from s in _context.Employees 
                                      select new EmployeeResponseDto
                                      {
                                          Email = s.Email,
                                          FirstName = s.FirstName,
                                          LastName = s.LastName,
                                          EmployeeId = s.EmployeeId,
                                          HireDate = s.HireDate,
                                          PhoneNumber = s.PhoneNumber,
                                          Salary = s.Salary,
                                          Department = new DepartmentResponseDto()
                                          {
                                              DepartmentId = s.Department.DepartmentId,
                                              DepartmentName = s.Department.DepartmentName,
                                              LocationId = s.Department.LocationId
                                          },
                                          Job = new JobResponseDto()
                                          {
                                              JobId = s.Job.JobId,
                                              JobTitle = s.Job.JobTitle,
                                              MinSalary = s.Job.MinSalary,
                                              MaxSalary = s.Job.MaxSalary
                                          }
                                      }).ToListAsync();
                responsePackage.Payload = employees;
            }

            return responsePackage;
        }

        public async Task<IResponsePackage<EmployeeResponseDto>> GetByIdAsync(int id)
        {
            var responsePackage = new ResponsePackage<EmployeeResponseDto>();

            try
              {
                var employee = await _context.Employees
                            .Include(x => x.Department)
                            .Include(x => x.Job)
                            .Include(x => x.Manager)
                            .Include(x => x.Dependents)
                            .Include(x => x.InverseManager)
                            .Where(x => x.EmployeeId == id).FirstOrDefaultAsync();

                if (employee is not null)
                {
                    var productDetailDto = new EmployeeResponseDto()
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        PhoneNumber = employee.PhoneNumber,
                        HireDate = employee.HireDate,
                        Salary = employee.Salary,
                        Department = new DepartmentResponseDto()
                        {
                            DepartmentId = employee.Department.DepartmentId,
                            DepartmentName = employee.Department.DepartmentName,
                            LocationId = employee.Department.LocationId
                        },
                        Job = new JobResponseDto()
                        {
                            JobId = employee.Job.JobId,
                            JobTitle = employee.Job.JobTitle,
                            MinSalary = employee.Job.MinSalary,
                            MaxSalary = employee.Job.MaxSalary
                        }
                    };
                    responsePackage.Payload = productDetailDto;
                }
                else
                {
                    responsePackage.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception ex)
            {
                responsePackage.StatusCode = StatusCodes.Status500InternalServerError;
                responsePackage.Errors = ex.Message;
            }

            return responsePackage;
        }

        public Task<IResponsePackage<EmployeeResponseDto>> GetByParamsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponsePackage<string>> UpdateAsync(EmployeeDto employee, int id)
        {
            var responsePackage = new ResponsePackage<string>();

            try
            {
                var currentEmployee = await _context.Employees.FindAsync(id);

                if(currentEmployee is not null)
                {
                    currentEmployee.FirstName = employee.FirstName;
                    currentEmployee.LastName = employee.LastName;
                    currentEmployee.Email = employee.Email;
                    currentEmployee.PhoneNumber = employee.PhoneNumber;
                    currentEmployee.HireDate = employee.HireDate;
                    currentEmployee.JobId = employee.JobId;
                    currentEmployee.Salary = employee.Salary;
                    currentEmployee.ManagerId = employee.ManagerId;
                    currentEmployee.DepartmentId = employee.DepartmentId;

                    _context.Employees.Update(currentEmployee);
                    _context.SaveChanges();

                    responsePackage.Payload = $"employee updated with ID {id}";
                    responsePackage.Id = id;
                }
            }
            catch (Exception ex)
            {
                responsePackage.StatusCode = StatusCodes.Status500InternalServerError;
                responsePackage.Errors = ex.Message;
            }

            return responsePackage;
        }
    }
}
