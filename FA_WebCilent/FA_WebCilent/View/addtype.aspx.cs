using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FA_WebCilent.Control.Action;
using FA_WebCilent.Control.DB;
using System.Threading.Tasks;

namespace FA_WebCilent.View
{
    public partial class addtype : System.Web.UI.Page
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
            List<CostTypeInfo> allTypes = CostTypeAction.GetAllParentTypes();
            foreach (var it in allTypes)
            {
                ListItem item = new ListItem();
                item.Text = it.Y_Name;
                item.Value = it.Y_Id;
                DropDownList1.Items.Add(item); 
            }

            if (DropDownList1.Items.Count > 0)
            {
                DropDownList1.Items[0].Selected = true;
            }
        }
    }
}