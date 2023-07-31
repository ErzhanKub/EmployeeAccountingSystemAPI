using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EmployeeAccountingSystemAPI.Date.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAccountingSystemAPI.DbCon
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
