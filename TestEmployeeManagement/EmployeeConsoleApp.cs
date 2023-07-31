using EmployeeAccountingSystemAPI.Date.Models;
using EmployeeAccountingSystemAPI.DbCon;
using EmployeeAccountingSystemAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestEmployeeManagement.Helpers;

namespace EmployeeConsoleApp
{
    class ConsoleApp
    {

        private readonly string _connectionString;
        private EmployeeManagement _employeeManagement;

        public ConsoleApp(string connectionString)
        {
            _connectionString = connectionString;
            ConfigureServices();
        }

        private ServiceProvider serviceProvider;
        private void ConfigureServices()
        {
            serviceProvider = new ServiceCollection()
                .AddDbContext<EmployeeContext>(options =>
                    options.UseNpgsql(_connectionString))
                .AddScoped<EmployeeManagement>()
                .BuildServiceProvider();
        }

        public void Start()
        {
            _employeeManagement = serviceProvider.GetService<EmployeeManagement>();
            while (true)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1. Добавить нового сотрудника.");
                Console.WriteLine("2. Удалить сотрудника.");
                Console.WriteLine("3. Вывести список всех сотрудников.");
                Console.WriteLine("4. Выйти из программы.");

                var option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "1": AddEmployee(); break;

                    case "2": RemoveEmployee(); break;

                    case "3": GetAllEmployees(); break;

                    case "4": return;

                    default:
                        Console.WriteLine("Неверная опция.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddEmployee()
        {
            Console.WriteLine("Введите эти данные: Имя - Возраст - Должность - URL адрес.");
            var name = Helper.ReadString("Имя: ");
            var age = Helper.ReadInt("Возраст: ");
            var position = Helper.ReadString("Должность: ");
            var urlString = Helper.ReadString("URL адрес: ");

            var employee = new Employee
            {
                Id = _employeeManagement.GetAllEmployees().Count + 1,
                Name = name,
                Age = age,
                Position = position
            };

            _employeeManagement.AddEmployee(employee);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Сотрудник {name} - {employee.Id} успешно добавлен.");
            Console.ResetColor();
        }

        private void RemoveEmployee()
        {
            int id = Helper.ReadInt("Введите ID сотрудника: ");
            if (_employeeManagement.GetAllEmployees().Any(e => e.Id == id))
            {
                _employeeManagement.RemoveEmployee(id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Сотрудник с ID {id} успешно удален.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Сотрудник с ID {id} не найден.");
                Console.ResetColor();
            }
        }
        private void GetAllEmployees()
        {
            var employees = _employeeManagement.GetAllEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }

            foreach (var e in employees)
            {
                Console.WriteLine($"ID: {e.Id} | Имя: {e.Name} | Возраст: {e.Age} | Должность: {e.Position} | URL адрес: {e.PhotoUrl}.");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Данные успешно выведены.");
            Console.ResetColor();
        }
    }
}
