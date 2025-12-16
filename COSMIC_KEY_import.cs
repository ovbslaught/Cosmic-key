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
	public partial class COSMIC_KEYController : BaseController
	{
		public ActionResult import()
		{
			try
			{
				dynamic pageObject = null, strOriginalTableName = null, var_params = XVar.Array();
				XTempl xt;
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				Server.ScriptTimeout = 600;
				GlobalVars.requestTable = new XVar("COSMIC KEY");
				GlobalVars.strTableName = new XVar("COSMIC KEY");
				GlobalVars.requestPage = new XVar("import");
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(Security.processPageSecurity((XVar)(GlobalVars.strTableName), new XVar("I")))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("a")), "action");
				var_params.InitAndSetArrayItem(Constants.PAGE_IMPORT, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(false, "needSearchClauseObj");
				var_params.InitAndSetArrayItem(strOriginalTableName, "strOriginalTableName");
				if(var_params["action"] == "importPreview")
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("importType")), "importType");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("importText")), "importText");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("useXHR")), "useXHR");
				}
				else
				{
					if(var_params["action"] == "importData")
					{
						var_params.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("importData")))), "importData");
					}
				}
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				GlobalVars.pageObject = XVar.Clone(new ImportPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
