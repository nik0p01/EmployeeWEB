using Xunit;
using WCFEmployeesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFEmployeesService.Tests
{
    public class EmployeeTests
    {
        [Fact()]
        public void GetDataTest()
        {
            Employee employeeServer = new Employee();
            employeeServer.SetData("Иванов", "Иван", "Иванович", new DateTime(2001, 01, 01));
            var employees = employeeServer.GetData("И", "И", "И");

            var countExpected = 1;
            var countActual = employees.Count;

            Assert.Equal(countExpected, countActual);
        }
    }
}