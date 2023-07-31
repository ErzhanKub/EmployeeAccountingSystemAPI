using EmployeeConsoleApp;
using System.Text;
using TestEmployeeManagement.Helpers;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding= Encoding.UTF8;

        var connection = new JsonConnection();
        var consoleApp = new ConsoleApp(connection.GetConnection());
        consoleApp.Start();
    }
}