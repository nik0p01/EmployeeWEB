using EmployeeWEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWEB.Models
{
 public   interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        ICollection<Employee> FindEmployeesByNames(string beginningLastName, string beginningFirstName, string beginningPatronymic);
    }
}