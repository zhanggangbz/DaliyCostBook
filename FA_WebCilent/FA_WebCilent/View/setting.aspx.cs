using FA_WebCilent.Control.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FA_WebCilent.Control.Action;

namespace FA_WebCilent.View
{
    public partial class setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userInfo"] == null)
            {
                var response = base.Response;
                response.Redirect("../index.aspx");
            }
            else
            {
                RegisterAsyncTask(new PageAsyncTask(GetAllTaskJS));
            }
        }

        private async Task GetAllTaskJS()
        {
            UserInfo userinfo = Session["userInfo"] as UserInfo;
            if (userinfo != null)
            {
                showname.Text = userinfo.U_NickName;

                int nWeek = (int)DateTime.Now.DayOfWeek;
                nWeek = (nWeek == 0) ? 7 : nWeek;

                //本周一 = 
                DateTime.Now.AddDays(1 - nWeek);
                //本周日 = 
                DateTime.Now.AddDays(1 - nWeek + 6);

                CostInfo curinfo = CostAnalysisAction.GetAllCostSum(DateTime.Now.AddDays(1 - nWeek), DateTime.Now.AddDays(1 - nWeek + 6), userinfo.U_Id);

                //上周一 = 
                DateTime.Now.AddDays(1 - nWeek - 7);
                //上周日 = 
                DateTime.Now.AddDays(nWeek);

                CostInfo lastinfo = CostAnalysisAction.GetAllCostSum(DateTime.Now.AddDays(1 - nWeek - 7), DateTime.Now.AddDays(-nWeek), userinfo.U_Id);

                lastweekhf.Text = lastinfo.zhichu.ToString();
                lastweeksr.Text = lastinfo.shouru.ToString();
                curweekhf.Text = curinfo.zhichu.ToString();
                curweeksr.Text = curinfo.shouru.ToString();
            }
        }
    }
}