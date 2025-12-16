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
	public partial class WORLD_LINE2Controller : BaseController
	{
		public ActionResult chart()
		{
			try
			{
				dynamic pageMode = null, pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.requestTable = new XVar("WORLD LINE chart1");
				GlobalVars.strTableName = new XVar("WORLD LINE chart1");
				GlobalVars.requestPage = new XVar("chart");
				CommonFunctions.add_nocache_headers();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(Security.processPageSecurity((XVar)(GlobalVars.strTableName), new XVar("S")))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				pageMode = XVar.Clone(ChartPage.readChartModeFromRequest());
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(pageMode, "mode");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(Constants.PAGE_CHART, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("masterpagetype")), "masterPageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				if(XVar.Pack(pageMode = new XVar(Constants.CHART_DASHBOARD)))
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "dashTName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				}
				GlobalVars.pageObject = XVar.Clone(new ChartPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				if(XVar.Pack(GlobalVars.pageObject.processSaveSearch()))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.pageObject.process();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
