using System.ComponentModel.DataAnnotations;

namespace EmployeeAccountingSystemAPI.Date.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        private string _name;
        private string _position;

        [Required]
        [MaxLength(50)]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value), "Имя не можеть быть пустым.");
                _name = value;
            }
        }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string Position
        {
            get => _position;
            set
            {
                _position = value ?? throw new ArgumentNullException(nameof(value), "Должность не может быть пустым");
            }
        }

        [Required]
        [Url]
        public string PhotoUrl { get; set; }
    }
}