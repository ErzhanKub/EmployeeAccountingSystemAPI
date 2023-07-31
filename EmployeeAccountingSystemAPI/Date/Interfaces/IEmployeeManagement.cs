using EmployeeAccountingSystemAPI.Date.Models;
namespace EmployeeAccountingSystemAPI.Date.Interfaces
{
    public interface IEmployeeManagement
    {
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void RemoveEmployee(int id);
    }
}
