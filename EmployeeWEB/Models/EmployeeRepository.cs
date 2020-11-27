using EmployeeWEB.Exceptions;
using EmployeeWEB.Models.Entities;
using EmployeeWEB.ServiceReferenceEmployee;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWEB.Models
{
    public class EmployeeRepository : IEmployeeRepository,IDisposable
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        private EmployeeClient _employeeClient = new EmployeeClient("BasicHttpBinding_IEmployee");

        public ICollection< Employee> FindEmployeesByNames(string beginningLastName, string beginningFirstName, string beginningPatronymic)
        {
            try
            {
                var result = _employeeClient.GetData(beginningLastName, beginningFirstName, beginningPatronymic).ToList().ConvertAll<Employee>(e => new Employee()
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    patronymic = e.Patronymic,
                    birthDay = e.BirthDay,
                    age = e.Age
                });
                return result;
            }
            catch ( Exception ex)
            {
                _logger.Error(ex);
                throw new MyServerException("Problems with server", ex);
            }
        }

        public void AddEmployee(Employee employee)
        {
            _employeeClient.SetData(employee.lastName, employee.firstName, employee.patronymic, employee.birthDay);
        }

        public void Dispose()
        {
            _employeeClient?.Close();
        }
    }
}