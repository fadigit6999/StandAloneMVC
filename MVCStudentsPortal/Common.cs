using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStudentsPortal
{
    public class Common
    {
        public static string DatabaseConnection() 
        {
            string server = "PC-2\\SQLEXPRESS";
            string dbName = "EmployeeMSDB";
            string sqlConnection = $"Data Source={server};Initial Catalog={dbName};Integrated Security= True;TrustServerCertificate=True;";
            return sqlConnection;
        }
    }
}
