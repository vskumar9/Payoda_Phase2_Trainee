using API_Application.Interface;
using API_Application.Models;

namespace API_Application.Service
{
    public class EmployeeService
    {
        private readonly IEmployee _employee;

        public EmployeeService(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employee.GetAllEmployees();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _employee.GetEmployee(employeeId);
        }

        public async Task AddEmployee(Employee employee)
        {
            await _employee.AddEmployee(employee);
        }

        public async Task UpdateEmployee(int id, Employee employee)
        {
            await _employee.UpdateEmployee(id, employee);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _employee.DeleteEmployee(employeeId);
        }

    }
}
