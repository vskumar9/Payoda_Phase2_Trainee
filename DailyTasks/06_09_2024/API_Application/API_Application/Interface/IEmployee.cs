using API_Application.Models;

namespace API_Application.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(int id, Employee employee);
        Task DeleteEmployee(int employeeId);
    }
}
