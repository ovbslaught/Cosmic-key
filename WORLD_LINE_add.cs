using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using runnerDotNet;
namespace runnerDotNet
{
	public partial class WORLD_LINEController : BaseController
	{
		public ActionResult add()
		{
			try
			{
				dynamic id = null, pageMode = null, pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.requestTable = new XVar("WORLD LINE");
				GlobalVars.strTableName = new XVar("WORLD LINE");
				GlobalVars.requestPage = new XVar("add");
				CommonFunctions.add_nocache_headers();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(AddPage.processAddPageSecurity((XVar)(GlobalVars.strTableName)))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				AddPage.handleBrokenRequest();
				pageMode = XVar.Clone(AddPage.readAddModeFromRequest());
				xt = XVar.UnPackXTempl(new XTempl());
				id = XVar.Clone(CommonFunctions.postvalue_number(new XVar("id")));
				id = XVar.Clone((XVar.Pack(id) ? XVar.Pack(id) : XVar.Pack(1)));
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(id, "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(pageMode, "mode");
				var_params.InitAndSetArrayItem(Constants.PAGE_ADD, "pageType");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("a")), "action");
				var_params.InitAndSetArrayItem(false, "needSearchClauseObj");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("afteradd")), "afterAdd_id");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("hostPageName")), "hostPageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("listPage")), "listPage");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("newRowId")), "newRowId");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				var_params.InitAndSetArrayItem(Constants.CaptchaId, "captchaName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value_", Constants.CaptchaId, "_", id))), "captchaValue");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("fromDashboard")), "fromDashboard");
				var_params.InitAndSetArrayItem((XVar.Pack(var_params["fromDashboard"]) ? XVar.Pack(var_params["fromDashboard"]) : XVar.Pack(MVCFunctions.postvalue(new XVar("dashTName")))), "dashTName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("spreadsheetGrid")), "forSpreadsheetGrid");
				if(pageMode == Constants.ADD_POPUP)
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("forLookup")), "forListPageLookup");
				}
				if(pageMode == Constants.ADD_DASHBOARD)
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "dashTName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				}
				if(pageMode == Constants.ADD_INLINE)
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("forLookup")), "forListPageLookup");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("screenWidth")), "screenWidth");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("screenHeight")), "screenHeight");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("orientation")), "orientation");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("masterpagetype")), "masterPageType");
				}
				if((XVar)(pageMode == Constants.ADD_ONTHEFLY)  || (XVar)((XVar)((XVar)(pageMode == Constants.ADD_INLINE)  || (XVar)(pageMode == Constants.ADD_POPUP))  && (XVar)(MVCFunctions.postvalue(new XVar("forLookup")))))
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "lookupTable");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("field")), "lookupField");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("pageType")), "lookupPageType");
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("parentsExist"))))
					{
						var_params.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("parentCtrlsData")))), "parentCtrlsData");
					}
				}
				if(var_params["pageName"] == Constants.CALENDAR_ADD_PAGE)
				{
					GlobalVars.pageObject = XVar.Clone(new AddCalendarPage((XVar)(var_params)));
				}
				else
				{
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("gantt"))))
					{
						var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("parent")), "parentValue");
						GlobalVars.pageObject = XVar.Clone(new AddGanttPage((XVar)(var_params)));
					}
					else
					{
						GlobalVars.pageObject = XVar.Clone(new AddPage((XVar)(var_params)));
					}
				}
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
