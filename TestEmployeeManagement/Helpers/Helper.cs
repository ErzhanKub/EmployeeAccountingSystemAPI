using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployeeManagement.Helpers
{
    public static class Helper
    {
        public static string ReadString(string text)
        {
            Console.Write(text);
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) throw new ArgumentNullException("Пустая строка", nameof(input));
            return input;
        }
        public static int ReadInt(string text)
        {
            Console.Write(text);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                throw new Exception("Неверный формат входных данных");
            }
            return result;
        }

    }
}
