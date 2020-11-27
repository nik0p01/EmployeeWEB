using EmployeeWEB.Models;
using EmployeeWEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWEB.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository _repository;
        public EmployeeController()
        {
            _repository = new EmployeeRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public string AddEmployee(string lastName, string firstName, string patronymic, DateTime? birthDay)
        {
            if (birthDay is null || lastName?.Length == 0 || firstName?.Length == 0)
                return "Запись не добавлена";

            _repository.AddEmployee(new Employee() {  firstName= firstName, lastName= lastName, patronymic= patronymic, birthDay= birthDay.Value });
            return "Запись добавлена";
        }

          [HttpGet]
        public ActionResult FindEmployees()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FindEmployees(string lastName, string firstName, string patronymic)
        {
            var employees = _repository.FindEmployeesByNames(lastName, firstName, patronymic);
            return View("~/Views/Employee/FindEmployeesResult.cshtml", employees);
        }

    }
}
