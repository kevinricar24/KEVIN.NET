using KEVIN.Domain.Dtos;

namespace KEVIN.Contract.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IResponsePackage<List<EmployeeResponseDto>>> GetAllAsync();
        Task<IResponsePackage<EmployeeResponseDto>> GetByIdAsync(int id);
        Task<IResponsePackage<EmployeeResponseDto>> GetByParamsAsync(string name);
        Task<IResponsePackage<string>> CreateAsync(EmployeeDto employee);
        Task<IResponsePackage<string>> UpdateAsync(EmployeeDto employee, int id);
        Task<IResponsePackage<string>> DeleteAsync(int id);
    }
}
