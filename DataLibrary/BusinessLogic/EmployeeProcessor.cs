using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {

        public static int CreateEmployee(int employeeId, string firstName,
            string lastName, string emailAddress, string password)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Password = password
            };

            string sql = @"insert into dbo.Employee (EmployeeId, FirstName, LastName, EmailAddress, Password)
                    values (@EmployeeId, @FirstName, @LastName, @EmailAddress, @Password);";

            return SqlDataAccess.SaveData(sql, data);

        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress from dbo.Employee;";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static List<EmployeeModel> SelectEmployees(string EmailAddress, string password)
        {
            string sql = @"select * from dbo.Employee where EmailAddress='" + EmailAddress + @"';";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }

}

