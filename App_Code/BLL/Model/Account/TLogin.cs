using System;
using System.Collections.Generic;
using System.Text;

namespace Coeno.BLL.Model.Account
{
    public class TLogin
    {
        #region Class Member Declarations
        string loginAccount;
        string loginDomain;
        string logPwd;
        string loginRoleID;
        string loginSystemID;

        public string LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
            }
        }

        public string LoginDomain
        {
            get
            {
                return loginDomain;
            }

            set
            {
                loginDomain = value;
            }
        }

        public string LogPwd
        {
            get
            {
                return logPwd;
            }

            set
            {
                logPwd = value;
            }
        }

        public string LoginRoleID
        {
            get
            {
                return loginRoleID;
            }

            set
            {
                loginRoleID = value;
            }
        }

        public string LoginSystemID
        {
            get
            {
                return loginSystemID;
            }

            set
            {
                loginSystemID = value;
            }
        }

        #endregion


    }
}
