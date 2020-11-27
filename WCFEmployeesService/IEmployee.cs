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
    [ServiceContract]
    public interface IEmployee
    {

        [OperationContract]
       ICollection< EmployeeDTO> GetData(string lastNameBeginning, string firstNameBeginning, string patronymicBeginning);

        [OperationContract]
        void  SetData(string lastName, string firstName, string patronymic, DateTime dateTime);
    }

}
