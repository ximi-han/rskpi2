using System;
using System.Collections.Generic;
using System.Text;

namespace Coeno.BLL.Model.Account
{
    public class TUser
    {
        #region Class Member Declarations

        string userID;
        string empID;
        string empCardID;
        string domain;
        string domainAccount;
        string empName;
        string titleID;
        string titleName;
        string deptID;
        string deptName;
        string ext1;
        string mManager1;
        string mManager2;
        string email;
        string buID;
        string buildID;
        string sex;
        DateTime dateIn;
        DateTime dateOut;
        string dutyRank;
        string proxyEmpID;
        string orgId;
        string isDuty;
        string isLeave;

        #endregion

        public string TUserID
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
        public string TitleID
        {
            get
            {
                return titleID;
            }
            set
            {
                titleID = value;
            }
        }
        public string TitleName
        {
            get
            {
                return titleName;
            }
            set
            {
                titleName = value;
            }
        }
        public string DeptID
        {
            get
            {
                return deptID;
            }
            set
            {
                deptID = value;
            }
        }
        public string DeptName
        {
            get
            {
                return deptName;
            }
            set
            {
                deptName = value;
            }
        }
        public string Ext1
        {
            get
            {
                return ext1;
            }
            set
            {
                ext1 = value;
            }
        }

        public string MManager1
        {
            get
            {
                return mManager1;
            }
            set
            {
                mManager1 = value;
            }
        }

        public string MManager2
        {
            get
            {
                return mManager2;
            }
            set
            {
                mManager2 = value;
            }
        }

        public string eMail
        {
            get
            {
                return email;
            }
            set
            {
                email= value;
            }
        }

       public string BUID
        {
            get
            {
                return buID;
            }
            set
            {
                buID =value;
            }
        }

       public string BuildID
        {
            get
            {
                return buildID;
            }
            set
            {
                buildID =value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
       public DateTime DateIn
        {
            get
            {
                return dateIn;
            }
            set
            {
                dateIn = value;
            }
        }

        public DateTime DateOut
        {
            get
            {
                return dateOut;
            }
            set
            {
                dateOut = value;
            }
        }
        public string DutyRank
        {
            get
            {
                return dutyRank;
            }
            set
            {
                dutyRank = value;
            }
        }

        public string ProxyEmpID
        {
            get
            {
                return proxyEmpID;
            }
            set
            {
                proxyEmpID = value;
            }
        }
        public string OrgId
        {
            get
            {
                return orgId;
            }
            set
            {
                orgId=value;
            }
        }
        public string IsDuty
        {
            get
            {
                return isDuty;
            }
            set
            {
                isDuty = value;
            }
        }
        public string IsLeave
        {
            get
            {
                return isLeave;
            }
            set
            {
                isLeave = value;
            }
        }

    }
}
