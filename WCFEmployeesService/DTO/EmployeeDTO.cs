using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFEmployeesService.DTO
{
    [DataContract]
    public class EmployeeDTO
    {
        [DataMember]
        public string LastName { get;set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Patronymic { get; set; }
        [DataMember]
        public DateTime BirthDay { get; set; }
        [DataMember]
        public int Age { 
            get 
            {
                return CalculateAge(BirthDay);
            }
            private set { }
        }

        private int CalculateAge(DateTime birthDay)
        {
            var now = DateTime.Now;
            int age = now.Year - birthDay.Year;

            if (now.Month < birthDay.Month || (now.Month == birthDay.Month && now.Day < birthDay.Day))
                age--;

            return age;
        }
    }
}