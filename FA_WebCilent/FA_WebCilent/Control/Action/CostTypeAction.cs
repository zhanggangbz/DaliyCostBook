using CYQ.Data;
using CYQ.Data.Table;
using FA_WebCilent.Control.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_WebCilent.Control.Action
{
    public class CostTypeAction
    {
        public static List<CostTypeInfo> GetAllParentTypes()
        {
            List<CostTypeInfo> rs = new List<CostTypeInfo>();
            using (MAction action = new MAction(TableNames.DB_FA_COST_TYPE))
            {
                string whereStr = "P_Y_ID=''";
                MDataTable dt = action.Select(whereStr);
                foreach (MDataRow row in dt.Rows)
                {
                    CostTypeInfo itemType = new CostTypeInfo();
                    itemType.Y_Id = row[DB_FA_COST_TYPE.Y_Id].StringValue;
                    itemType.Y_Name = row[DB_FA_COST_TYPE.Y_Name].StringValue;
                    itemType.Y_IsIncome = (int)row[DB_FA_COST_TYPE.Y_IsIncome].Value;
                    itemType.P_Y_Id = row[DB_FA_COST_TYPE.P_Y_Id].StringValue;
                    itemType.F_U_Id = row[DB_FA_COST_TYPE.F_U_Id].StringValue;
                    rs.Add(itemType);
                }
            }
            return rs;
        }

        public static List<CostTypeInfo> GetAllChildTypesByPID(string pid)
        {
            List<CostTypeInfo> rs = new List<CostTypeInfo>();
            using (MAction action = new MAction(TableNames.DB_FA_COST_TYPE))
            {
                string whereStr = "P_Y_ID='{0}'";
                whereStr = string.Format(whereStr, pid);
                MDataTable dt = action.Select(whereStr);
                foreach (MDataRow row in dt.Rows)
                {
                    CostTypeInfo itemType = new CostTypeInfo();
                    itemType.Y_Id = row[DB_FA_COST_TYPE.Y_Id].StringValue;
                    itemType.Y_Name = row[DB_FA_COST_TYPE.Y_Name].StringValue;
                    itemType.Y_IsIncome = (int)row[DB_FA_COST_TYPE.Y_IsIncome].Value;
                    itemType.P_Y_Id = row[DB_FA_COST_TYPE.P_Y_Id].StringValue;
                    itemType.F_U_Id = row[DB_FA_COST_TYPE.F_U_Id].StringValue;
                    rs.Add(itemType);
                }
            }
            return rs;
        }

        public static bool InsertCostType(CostTypeInfo _info)
        {
            bool rs = false;
            using (MAction action = new MAction(TableNames.DB_FA_COST_TYPE))
            {
                action.Set(DB_FA_COST_TYPE.Y_Id, _info.Y_Id);
                action.Set(DB_FA_COST_TYPE.Y_Name, _info.Y_Name);
                action.Set(DB_FA_COST_TYPE.Y_IsIncome, _info.Y_IsIncome);
                action.Set(DB_FA_COST_TYPE.F_U_Id, _info.F_U_Id);
                action.Set(DB_FA_COST_TYPE.P_Y_Id, _info.P_Y_Id);

                rs = action.Insert();
            }
            return rs;
        }
    }
}