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
	public partial class sqlViewController : BaseController
	{
		public ActionResult list()
		{
			try
			{
				dynamic mode = null, options = XVar.Array(), pageObject = null;
				XTempl xt;
				GlobalVars.requestTable = new XVar("sqlView");
				GlobalVars.strTableName = new XVar("sqlView");
				GlobalVars.requestPage = new XVar("list");
				CommonFunctions.add_nocache_headers();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(ListPage.processListPageSecurity((XVar)(GlobalVars.strTableName)))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				if(XVar.Pack(ListPage.processSaveParams((XVar)(GlobalVars.strTableName))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				options = XVar.Clone(XVar.Array());
				mode = XVar.Clone(ListPage.readListModeFromRequest());
				if(mode == Constants.LIST_SIMPLE)
				{
				}
				else
				{
					if(mode == Constants.LIST_AJAX)
					{
					}
					else
					{
						if(mode == Constants.LIST_LOOKUP)
						{
							options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "mainTable");
							options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("field")), "mainField");
							options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("pageType")), "mainPageType");
							options.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("data")))), "mainRecordData");
							options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mainRecordMasterTable")), "mainRecordMasterTable");
							if(XVar.Pack(MVCFunctions.postvalue(new XVar("parentsExist"))))
							{
								options.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("parentCtrlsData")))), "parentCtrlsData");
							}
						}
						else
						{
							if(mode == Constants.LIST_POPUPDETAILS)
							{
							}
							else
							{
								if(mode == Constants.LIST_DETAILS)
								{
								}
								else
								{
									if(mode == Constants.LIST_DASHDETAILS)
									{
									}
									else
									{
										if(mode == Constants.LIST_DASHBOARD)
										{
										}
										else
										{
											if(mode == Constants.MAP_DASHBOARD)
											{
											}
										}
									}
								}
							}
						}
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				options.InitAndSetArrayItem(Constants.PAGE_LIST, "pageType");
				options.InitAndSetArrayItem((XVar.Pack(CommonFunctions.postvalue_number(new XVar("id"))) ? XVar.Pack(CommonFunctions.postvalue_number(new XVar("id"))) : XVar.Pack(1)), "id");
				options.InitAndSetArrayItem((int)MVCFunctions.postvalue(new XVar("recordId")), "flyId");
				options.InitAndSetArrayItem(mode, "mode");
				options.InitAndSetArrayItem(xt, "xt");
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("firstTime")), "firstTime");
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("sortby")), "sortBy");
				options.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("goto")), "requestGoto");
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("masterpagetype")), "masterPageType");
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("masterpage")), "masterPage");
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("masterid")), "masterId");
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(options["masterTable"]))
				{
					options.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				if((XVar)((XVar)(mode == Constants.LIST_DASHBOARD)  && (XVar)(MVCFunctions.postvalue(new XVar("nodata"))))  && (XVar)(MVCFunctions.strlen((XVar)(options["masterTable"]))))
				{
					options.InitAndSetArrayItem(true, "showNoData");
				}
				if(mode != Constants.LIST_LOOKUP)
				{
					options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
					options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "dashTName");
					options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				}
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("mapRefresh"))))
				{
					options.InitAndSetArrayItem(true, "mapRefresh");
					options.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("vpCoordinates")))), "vpCoordinates");
				}
				if(XVar.Pack(MVCFunctions.postvalue(new XVar("firstTime"))))
				{
					options.InitAndSetArrayItem(true, "firstTime");
				}
				GlobalVars.pageObject = XVar.Clone(ListPage.createListPage((XVar)(GlobalVars.strTableName), (XVar)(options)));
				if(XVar.Pack(GlobalVars.pageObject.processSaveSearch()))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(GlobalVars.pageObject.updateRowOrder()))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(GlobalVars.pageObject.processFieldFilter()))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if(XVar.Pack(GlobalVars.pageObject.processTotals()))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				if((XVar)((XVar)(mode != Constants.LIST_DETAILS)  && (XVar)(mode != Constants.MAP_DASHBOARD))  && (XVar)(mode != Constants.LIST_DASHBOARD))
				{
				}
				XSession.Session.Remove("message_add");
				XSession.Session.Remove("message_edit");
				GlobalVars.pageObject.prepareForBuildPage();
				GlobalVars.pageObject.showPage();
				if((XVar)(ProjectSettings.ext() == "aspx")  && (XVar)(mode != Constants.LIST_SIMPLE))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
