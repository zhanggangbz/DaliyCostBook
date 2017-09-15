using FA_WebCilent.Control.Action;
using FA_WebCilent.Control.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace FA_WebCilent.ViewAction
{
    /// <summary>
    /// ActionProcess 的摘要说明
    /// </summary>
    public class ActionProcess : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder _strContent = new StringBuilder();
            string _strAction = context.Request.Params["action"];
            if (string.IsNullOrEmpty(_strAction))
            {
                _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"禁止访问！\",\"rows\": []}");
            }
            else
            {
                switch (_strAction.Trim().ToLower())
                {
                    case "userlogin":
                        UserLogin(context, _strContent);
                        break;
                    case "getalltypejson":
                        GetAllTypeJson( _strContent);
                        break;
                    case "additemaction":
                        AddItemAction(context, _strContent);
                        break;
                    case "getsettinginfo":
                        GetSettingInfo(context, _strContent);
                        break;
                    case "logout":
                        Logout(context);
                        break;
                    case "getallparenttypejson":
                        GetParentTypeInfo(context, _strContent);
                        break;
                    case "addtypeaction":
                        AddTypeAction(context, _strContent);
                        break;
                    case "searthiteminfo":
                        SearthAllItemsPage(context, _strContent);
                        break;
                    default: 
                        break;
                }
            }
            context.Response.ContentType = "application/json";
            context.Response.Write(_strContent.ToString());
        }

        private void SearthAllItemsPage(HttpContext context, StringBuilder _strContent)
        {

            int pageindex = 0;
            int pagecount = 0;

            try
            {
                pageindex = int.Parse(context.Request.Form["pageindex"]);
                pagecount = int.Parse(context.Request.Form["pagecoumt"]);
            }
            catch (System.Exception ex)
            {
            	
            }

            string strindex = context.Request.Form["typename"];
            string strcount = context.Request.Form["parentid"];


            if (pagecount != 0&&pageindex!=0)
            {
                List<CostItemInfo> listitems = CostItemAction.SearthItemsByPage(pageindex,pagecount);
                string jsonlist = FA_WebCilent.Control.Common.getJsonByObject(listitems);
                _strContent.Append("{\"msg\": \"1\", \"msgbox\": " + jsonlist + "}");
            }
            else
            {
                _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"\"}");
            }

        }

        private void AddTypeAction(HttpContext context, StringBuilder _strContent)
        {
            String typename = context.Request.Form["typename"];
            string parentid = context.Request.Form["parentid"];
            int isincome = string.IsNullOrWhiteSpace(context.Request.Form["isincome"])==false&&context.Request.Form["isincome"].ToLower() == "true" ? 1 : 0;

            CostTypeInfo itemObj = new CostTypeInfo();
            itemObj.Y_Id = Guid.NewGuid().ToString("N");
            itemObj.Y_Name = typename;
            itemObj.Y_IsIncome = isincome;
            itemObj.P_Y_Id = parentid;
            UserInfo userinfo = context.Session["userInfo"] as UserInfo;
            if (userinfo != null)
            {
                itemObj.F_U_Id = userinfo.U_Id;

                if (CostTypeAction.InsertCostType(itemObj))
                {
                    _strContent.Append("{\"msg\": \"1\", \"msgbox\": \"添加成功！\"}");
                }
                else
                {
                    _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"添加失败！\"}");
                }
            }
            else
            {
                _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"尚未登录！\"}");
            }
        }

        private void GetParentTypeInfo(HttpContext context, StringBuilder _strContent)
        {
            List<CostTypeInfo> allTypes = CostTypeAction.GetAllParentTypes();
            if(allTypes.Count > 0)
            {
                string info = "[";
                foreach (var it in allTypes)
                {
                    info += "{\"label\":\"" + it.Y_Name + "\",";
                    info += "\"value\":\"" + it.Y_Id + "\"},";
                }
                info = info.TrimEnd(',');
                info += "]";

                _strContent.Append("{\"msg\": \"1\", \"msgbox\": " + info + "}");
            }
            else
            {
                _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"\"}");
            }
        }

        private void Logout(HttpContext context)
        {
            context.Session.Clear();
            context.Response.Redirect("../index.aspx");
        }

        private void GetSettingInfo(HttpContext context, StringBuilder _strContent)
        {
            UserInfo userinfo = context.Session["userInfo"] as UserInfo;
            if (userinfo != null)
            {
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

                string info = "{";
                info += "\"name\":\"" + userinfo.U_NickName + "\",";
                info += "\"lastweek\":{\"hf\":" + lastinfo.zhichu.ToString() + ",\"sr\":" + lastinfo.shouru.ToString()+"},";
                info += "\"curweek\":{\"hf\":" + curinfo.zhichu.ToString() + ",\"sr\":" + curinfo.shouru.ToString() + "}";
                info += "}";

                _strContent.Append("{\"msg\": \"1\", \"msgbox\": "+ info + "}");
            }
            else
            {
                _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"尚未登录！\"}");
            }
        }

        private void AddItemAction(HttpContext context, StringBuilder _strContent)
        {
            String dateStr = context.Request.Form["costtime"];
            string jeStr = context.Request.Form["costnum"];
            string bzStr = context.Request.Form["costtypeid"];
            string lxId = context.Request.Form["costrecord"];
            string location = context.Request.Form["location"];

            CostItemInfo itemObj = new CostItemInfo();
            itemObj.I_Id = Guid.NewGuid().ToString("N");
            itemObj.I_CDate = dateStr;
            try
            {
                itemObj.I_Money = float.Parse(jeStr);
            }
            catch { }
            itemObj.I_BankCord = 0;
            itemObj.I_Remark = lxId;
            itemObj.F_Y_Id = bzStr;
            itemObj.I_Location = location;
            UserInfo userinfo = context.Session["userInfo"] as UserInfo;
            if(userinfo != null)
            {
                itemObj.F_U_Id = userinfo.U_Id;

                if (CostItemAction.InsertCostItem(itemObj))
                {
                    _strContent.Append("{\"msg\": \"1\", \"msgbox\": \"添加成功！\"}");
                }
                else
                {
                    _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"添加失败！\"}");
                }
            }
            else
            {
                _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"尚未登录！\"}");
            }
        }

        private void GetAllTypeJson(StringBuilder _strContent)
        {
            string jsStr = "[";
            List<CostTypeInfo> allTypes = CostTypeAction.GetAllParentTypes();
            foreach (var it in allTypes)
            {
                jsStr += "{";
                jsStr += "\"label\":\"" + it.Y_Name + "\",";
                jsStr += "\"value\":\"" + it.Y_Id + "\",";
                jsStr += "\"children\": [";
                List<CostTypeInfo> allChildTypes = CostTypeAction.GetAllChildTypesByPID(it.Y_Id);
                for (int i = 0; i < allChildTypes.Count;++i )
                {
                    jsStr += "{\"label\":\"" + allChildTypes[i].Y_Name+ "\",";
                    jsStr += "\"value\":\"" + allChildTypes[i].Y_Id + "\"";
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

            jsStr += "]";

            try
            {

                jsStr = "{\"msg\": \"1\", \"msgbox\":" +jsStr+"}";
            }
            catch (System.Exception ex)
            {
            	
            }

            _strContent.Append(jsStr);
        }

        private void UserLogin(HttpContext context, StringBuilder _strContent)
        {
            string _userName = context.Request.Params["username"];
            string _userPass = context.Request.Params["password"];
            UserInfo userinfo = loginClass.CheckUserInfo(_userName, _userPass);
            if (userinfo != null)
            {
                context.Session["userInfo"] = userinfo;

                _strContent.Append("{\"msg\": \"1\", \"msgbox\": \"登录成功！\"}");
            }
            else
            {
                _strContent.Append("{\"msg\": \"0\", \"msgbox\": \"用户名或密码错误！\"}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}