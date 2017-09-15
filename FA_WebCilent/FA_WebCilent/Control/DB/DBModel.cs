using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_WebCilent.Control.DB
{
    public enum TableNames { DB_FA_COST_ITEM, DB_FA_COST_TYPE, DB_FA_USER }

    #region 枚举
    public enum DB_FA_COST_ITEM { I_Id, I_CDate, I_Money, I_BankCord, I_Remark, F_U_Id, F_Y_Id,I_Location }
    public enum DB_FA_COST_TYPE { Y_Id, Y_Name, Y_IsIncome, F_U_Id, P_Y_Id }
    public enum DB_FA_USER { U_Id, U_Name, U_PassWord, U_NickName }
    #endregion
}