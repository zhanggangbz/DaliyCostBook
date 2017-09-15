using CYQ.Data;
using CYQ.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA_WebCilent.Control.Action
{
    public class CostInfo
    {
        public double shouru;
        public double zhichu;

        public CostInfo()
        {
            shouru = zhichu = 0;
        }
    }
    public class CostAnalysisAction
    {
        /// <summary>
        /// 查找一段时间内的消费总额，前后都包括
        /// </summary>
        /// <param name="dt1">精确到天</param>
        /// <param name="dt2">精确到天</param>
        /// <returns></returns>
        public static CostInfo GetAllCostSum(DateTime dt1, DateTime dt2, string userId = "")
        {
            CostInfo sum = new CostInfo();

            string sql = "SELECT I_Money, Y_IsIncome,I_CDate FROM DB_FA_COST_ITEM INNER JOIN DB_FA_COST_TYPE ON DB_FA_COST_ITEM.F_Y_Id = DB_FA_COST_TYPE.Y_Id WHERE I_CDate BETWEEN '{0}' AND '{1}'";

            if (!string.IsNullOrWhiteSpace(userId))
            {
                sql = "SELECT I_Money, Y_IsIncome,I_CDate FROM DB_FA_COST_ITEM INNER JOIN DB_FA_COST_TYPE ON DB_FA_COST_ITEM.F_Y_Id = DB_FA_COST_TYPE.Y_Id WHERE I_CDate BETWEEN '{0}' AND '{1}' AND DB_FA_COST_ITEM.F_U_ID='" + userId + "'";
            }

            sql = string.Format(sql, dt1.ToString("yyyy-MM-dd"), dt2.AddDays(1).ToString("yyyy-MM-dd"));

            MDataTable dt;
            using (MAction action = new MAction(sql))
            {
                dt = action.Select();
                foreach (var row in dt.Rows)
                {
                    try
                    {
                        double dv = double.Parse(row["I_Money"].Value.ToString());
                        if (row["Y_IsIncome"].Value == (object)1)
                        {
                            sum.shouru += dv;
                        }
                        else
                        {
                            sum.zhichu += dv;
                        }
                    }
                    catch (System.Exception ex)
                    {
                    	
                    }
                }
            }

            return sum;
        }
    }
}