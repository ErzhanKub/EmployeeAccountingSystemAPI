using EmployeeAccountingSystemAPI.Date.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAccountingSystemAPI.DbCon
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
