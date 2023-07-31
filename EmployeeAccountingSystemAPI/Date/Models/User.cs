using System.ComponentModel.DataAnnotations;

namespace EmployeeAccountingSystemAPI.Date.Models
{
    public class User
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
