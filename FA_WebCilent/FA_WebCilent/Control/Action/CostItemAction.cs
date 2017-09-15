using CYQ.Data;
using CYQ.Data.Table;
using FA_WebCilent.Control.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_WebCilent.Control.Action
{
    public class CostItemAction
    {
        public static bool InsertCostItem(CostItemInfo _info)
        {
            bool rs = false;
            using (MAction action = new MAction(TableNames.DB_FA_COST_ITEM))
            {
                action.Set(DB_FA_COST_ITEM.I_Id,_info.I_Id);
                action.Set(DB_FA_COST_ITEM.I_CDate, _info.I_CDate);
                action.Set(DB_FA_COST_ITEM.I_Money, _info.I_Money);
                action.Set(DB_FA_COST_ITEM.I_BankCord, _info.I_BankCord);
                action.Set(DB_FA_COST_ITEM.I_Remark, _info.I_Remark);
                action.Set(DB_FA_COST_ITEM.F_U_Id, _info.F_U_Id);
                action.Set(DB_FA_COST_ITEM.F_Y_Id, _info.F_Y_Id);
                action.Set(DB_FA_COST_ITEM.I_Location, _info.I_Location);
                rs = action.Insert();
            }
            return rs;
        }

        public static List<CostItemInfo> SearthItemsByPage(int _pageindex, int _pagecount)
        {
            string sqlstr = "SELECT TOP {0} I_CDATE,I_MONEY,I_REMARK,U_NICKNAME,Y_NAME,I_Location FROM (SELECT ROW_NUMBER() OVER (ORDER BY I_CDate DESC) AS RowNumber,I_CDATE,I_MONEY,I_REMARK,U_NICKNAME,Y_NAME,I_Location FROM DB_FA_COST_ITEM,DB_FA_COST_TYPE,DB_FA_USER WHERE DB_FA_COST_ITEM.F_U_Id = DB_FA_USER.U_Id AND DB_FA_COST_ITEM.F_Y_Id = DB_FA_COST_TYPE.Y_Id) as A WHERE RowNumber > {1}";

            sqlstr = string.Format(sqlstr, _pagecount, (_pageindex - 1) * _pagecount);

            List<CostItemInfo> lists = new List<CostItemInfo>();

            using (MAction action = new MAction(sqlstr))
            {
                MDataTable dt = action.Select();
                foreach (MDataRow row in dt.Rows)
                {
                    try
                    {
                        CostItemInfo item = new CostItemInfo();
                        item.I_CDate = row["I_CDATE"].StringValue;
                        item.I_Money = float.Parse(row["I_MONEY"].StringValue);
                        item.I_Remark = row["I_REMARK"].StringValue;
                        item.F_U_Id = row["U_NICKNAME"].StringValue;
                        item.F_Y_Id = row["Y_NAME"].StringValue;
                        item.I_Location = row["I_Location"].StringValue;
                        lists.Add(item);
                    }
                    catch (System.Exception ex)
                    {
                    	
                    }
                }
            }

            return lists;

        }
    }
}