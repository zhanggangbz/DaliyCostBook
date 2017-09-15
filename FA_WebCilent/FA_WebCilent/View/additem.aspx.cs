using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FA_WebCilent.Control.Action;
using FA_WebCilent.Control.DB;

namespace FA_WebCilent.View
{
    public partial class additem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userInfo"] == null)
            {
                var response = base.Response;
                response.Redirect("../index.aspx");
            }else
            {
                Button1.Attributes.Add("onclick", "aaa()");
                RegisterAsyncTask(new PageAsyncTask(GetAllTaskJS)); 
            }
        }

        private async Task GetAllTaskJS()
        {
            string jsStr = "weui.picker([";
            List<CostTypeInfo> allTypes = CostTypeAction.GetAllParentTypes();
            foreach (var it in allTypes)
            {
                jsStr += "{";
                jsStr += "label:'" + it.Y_Name + "',";
                jsStr += "value:'" + it.Y_Id + "',";
                jsStr += "children: [";
                List<CostTypeInfo> allChildTypes = CostTypeAction.GetAllChildTypesByPID(it.Y_Id);
                for (int i = 0; i < allChildTypes.Count;++i )
                {
                    jsStr += "{ label:'" + allChildTypes[i].Y_Name+"',";
                    jsStr += "value:'" + allChildTypes[i].Y_Id + "',";
                    if (i!=allChildTypes.Count - 1)
                    {
                        jsStr += "},";
                    }
                    else
                    {
                        jsStr += "}";
                    }
                }
                jsStr += "]},";
            }

            jsStr = jsStr.Trim().TrimEnd(',');

            jsStr += "], {defaultValue: ['3501685d89d84e75a16c951c3eb280d9', '444deb215cd94e599b65e87524784735'],onConfirm: function onConfirm(result) { \n console.log(result);\n$(\"#typevalue\").val(result[1].label); \n$(\"#typevalueid\").val(result[1].value);\n},id: 'TypeList'});";

            lit_RegiterJS.Text = jsStr;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String dateStr = Request.Form["costtime"]; 
            string jeStr = this.TextBox1.Text;
            string bzStr = this.Text_Remark.Text;
            string lxId = Request.Form["typevalueid"];

            CostItemInfo itemObj = new CostItemInfo();
            itemObj.I_Id = Guid.NewGuid().ToString("N");
            itemObj.I_CDate = Request.Form["costtime"];
            try
            {
                itemObj.I_Money = float.Parse(this.TextBox1.Text);
            }
            catch { }
            itemObj.I_BankCord = 0;
            itemObj.I_Remark = this.Text_Remark.Text;
            itemObj.F_Y_Id = Request.Form["typevalueid"];
            UserInfo userinfo = Session["userInfo"] as UserInfo;
            itemObj.F_U_Id = userinfo.U_Id;
            if(CostItemAction.InsertCostItem(itemObj))
            {
                this.TextBox1.Text = "0";
                this.Text_Remark.Text = "";
                lit_RegiterJS1.Text = "$.hideLoading();$.toast('操作成功');changeView(1);";
            }
            else
            {
                lit_RegiterJS1.Text ="$.hideLoading();$.toast(\"操作失败\",\"forbidden\");";
            }
        }
    }
}