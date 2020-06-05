using System;
using System.Collections.Generic;
using System.Text;

namespace Coeno.BLL.Model.Account
{
    public class TUserAdvance
    {
        #region Class Member Declarations
        string userID;
        string empID;
        string empCardID;
        string domain;
        string domainAccount;
        string empName;
        string firstName;
        string lastName;
        string empCName;
        string empEName;
        #endregion

        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }

        public string EmpID
        {
            get
            {
                return empID;
            }
            set
            {
                empID = value;
            }
        }

        public string EmpCardID
        {
            get
            {
                return empCardID;
            }
            set
            {
                empCardID = value;
            }
        }
        public string Domain
        {
            get
            {
                return domain;
            }
            set
            {
                domain = value;
            }
        }
        public string DomainAccount
        {
            get
            {
                return domainAccount;
            }
            set
            {
                domainAccount = value;
            }
        }
        public string EmpName
        {
            get
            {
                return empName;
            }
            set
            {
                empName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string EmpCName
        {
            get
            {
                return empCName;
            }
            set
            {
                empCName = value;
            }
        }
        public string EmpEName
        {
            get
            {
                return empEName;
            }
            set
            {
                empEName = value;
            }
        }
    }
}
