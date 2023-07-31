using EmployeeAccountingSystemAPI.DbCon;
using EmployeeAccountingSystemAPI.Date.Models;
using EmployeeAccountingSystemAPI.Date.Interfaces;

namespace EmployeeAccountingSystemAPI.Services
{
    public class EmployeeManagement : IEmployeeManagement
    {
        private readonly EmployeeContext _context;

        public EmployeeManagement(EmployeeContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void RemoveEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}
