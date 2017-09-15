using CYQ.Data;
using CYQ.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_WebCilent.Control.DB
{
    public class loginClass
    {
        public static UserInfo CheckUserInfo(string username,string password)
        {
            UserInfo rs = null;

            using (MAction action = new MAction(TableNames.DB_FA_USER))
            {
                string whereStr = "U_NAME='{0}' AND U_PassWord='{1}'";
                whereStr = string.Format(whereStr, username,password);
                MDataTable dt = action.Select(whereStr);
                if (dt.Rows.Count!=0)
                {
                    rs = new UserInfo();
                    rs.U_Id = dt.Rows[0][DB_FA_USER.U_Id].StringValue;
                    rs.U_Name = dt.Rows[0][DB_FA_USER.U_Name].StringValue;
                    rs.U_NickName = dt.Rows[0][DB_FA_USER.U_NickName].StringValue;
                }
            }

            return rs;
        }
    }
}