using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Constant
{
    public static class StoredProcedure
    {
        // User
        public const string USER_GETALL = "sp_User_GetAll";
        public const string USER_INSERT = "sp_User_Insert";
        public const string USER_GETBY_USERNAME = "sp_User_GetBy_UserName";
        public const string USER_GETBY_USERNAME_PASSWORD = "sp_User_GetBy_UserName_Password";
    }
}
