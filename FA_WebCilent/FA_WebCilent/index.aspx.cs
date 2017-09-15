using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FA_WebCilent.Control.DB;
using System.Threading.Tasks;

namespace FA_WebCilent
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonSub.Attributes.Add("onclick", "aaa()");
        }

        protected void ButtonSub_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(AsyncWork));  
        }

        private async Task AsyncWork()
        {
            UserInfo userinfo = loginClass.CheckUserInfo(this.TextName.Text, this.TextPass.Text);
            if (userinfo != null)
            {
                Session["userInfo"] = userinfo;

                Response.Redirect("./View/index.aspx",false);
            }
        }
    }
}