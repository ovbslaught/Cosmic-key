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
		public ActionResult print()
		{
			try
			{
				dynamic pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.requestTable = new XVar("WORLD LINE");
				GlobalVars.strTableName = new XVar("WORLD LINE");
				GlobalVars.requestPage = new XVar("print");
				CommonFunctions.add_nocache_headers();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(Security.processPageSecurity((XVar)(GlobalVars.strTableName), new XVar("P")))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(Constants.PAGE_PRINT, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("selection")), "selection");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("all")), "allPagesMode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("details")), "detailTables");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("records")), "splitByRecords");
				var_params.InitAndSetArrayItem((XVar.Pack(MVCFunctions.postvalue(new XVar("pdfjson"))) ? XVar.Pack(Constants.PRINT_PDFJSON) : XVar.Pack(Constants.PRINT_SIMPLE)), "mode");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("pdfBackgroundImage")), "pdfBackgroundImage");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				GlobalVars.pageObject = XVar.Clone(new PrintPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
