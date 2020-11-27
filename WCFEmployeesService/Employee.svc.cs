using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFEmployeesService.DTO;

namespace WCFEmployeesService
{
    public class Employee : IEmployee
    {
        private static  List<EmployeeDTO> _employeeDTOs;
        private static object _syncRoot = new Object();
        public Employee()
        {
            if (_employeeDTOs== null)
            {
                lock (_syncRoot)
                {
                    if (_employeeDTOs == null)
                        _employeeDTOs = new List<EmployeeDTO>();
                }
            }
        }

        public ICollection< EmployeeDTO> GetData(string lastNameBeginning, string firstNameBeginning, string patronymicBeginning)
        {
            var result =  _employeeDTOs.Where(e => StrinrStartFtomSubsting(lastNameBeginning, e.LastName) &&
            StrinrStartFtomSubsting(firstNameBeginning, e.FirstName) &&
            StrinrStartFtomSubsting(patronymicBeginning, e.Patronymic)).ToList<EmployeeDTO>();
            return result;
        }
        /// <summary>
        /// возвращает верно, если строка начинается с подстраки или подстрака пуста
        /// </summary>
        /// <param name="subString"></param>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static bool StrinrStartFtomSubsting(string subString, string inputString)
        {
            if (subString.Length == 0)
            {
                return true;
            }
            return inputString.IndexOf(subString) == 0;
        }

        public void SetData(string lastName, string firstName, string patronymic, DateTime birthDay)
        {
            lock (_syncRoot)
            {
                _employeeDTOs.Add(new EmployeeDTO()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Patronymic = patronymic,
                    BirthDay = birthDay
                });
            }
        }
    }
}
