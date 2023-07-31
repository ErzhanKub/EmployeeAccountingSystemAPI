using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployeeManagement.Helpers
{
    public class JsonConnection
    {
        public string GetConnection()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetSection("ConnectionStrings:DefaultConnection").Value;
            return connectionString;
        }
    }
}
