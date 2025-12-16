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
	public partial class COSMIC_KEY_OSController : BaseController
	{
		public ActionResult dashboard()
		{
			try
			{
				dynamic pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.requestTable = new XVar("COSMIC KEY OS");
				GlobalVars.strTableName = new XVar("COSMIC KEY OS");
				GlobalVars.requestPage = new XVar("dashboard");
				CommonFunctions.add_nocache_headers();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(Security.processPageSecurity((XVar)(GlobalVars.strTableName), new XVar("S")))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mode")), "mode");
				var_params.InitAndSetArrayItem(Constants.PAGE_DASHBOARD, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("a")), "action");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("elementName")), "elementName");
				GlobalVars.pageObject = XVar.Clone(new DashboardPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
