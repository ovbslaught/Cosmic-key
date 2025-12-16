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
	public static partial class RunnerSettings
	{
		public static void table_COSMIC_KEY_OS()
		{
			GlobalVars.runnerTableSettings.InitAndSetArrayItem(new XVar( "name", "COSMIC KEY OS",
"type", 4,
"shortName", "COSMIC_KEY_OS",
"pagesByType", new XVar( "dashboard", new XVar( 0, "dashboard" ) ),
"pageTypes", new XVar( "dashboard", "dashboard" ),
"defaultPages", new XVar( "dashboard", "dashboard" ),
"afterEditDetails", "COSMIC KEY OS",
"afterAddDetail", "COSMIC KEY OS",
"detailsBadgeColor", "cd5c5c",
"deviceHideFields", new XVar( "1", XVar.Array(),
"5", XVar.Array() ),
"originalTable", "",
"originalPagesByType", new XVar( "dashboard", new XVar( 0, "dashboard" ) ),
"originalPageTypes", new XVar( "dashboard", "dashboard" ),
"originalDefaultPages", new XVar( "dashboard", "dashboard" ),
"searchSettings", new XVar( "caseSensitiveSearch", false,
"searchableFields", XVar.Array(),
"searchSuggest", true,
"highlightSearchResults", true,
"hideDataUntilSearch", false,
"hideFilterUntilSearch", false,
"googleLikeSearchFields", XVar.Array() ),
"connId", "",
"clickActions", new XVar( "row", new XVar( "action", "noaction" ),
"fields", new XVar(  ) ),
"geoCoding", new XVar( "enabled", false,
"latField", "",
"lonField", "",
"addressFields", XVar.Array() ),
"whereTabs", XVar.Array(),
"labels", new XVar(  ),
"chartSettings", new XVar(  ),
"dataSourceOperations", new XVar(  ),
"calendarSettings", new XVar( "categoryColors", XVar.Array() ),
"ganttSettings", new XVar( "categoryColors", XVar.Array() ) ), "COSMIC KEY OS");
			if(XVar.Equals(XVar.Pack(CommonFunctions.mlang_getcurrentlang()), XVar.Pack("English")))
			{
				GlobalVars.runnerTableLabels.InitAndSetArrayItem(new XVar( "tableCaption", "COSMIC KEY OS",
"fieldLabels", new XVar(  ),
"fieldTooltips", new XVar(  ),
"fieldPlaceholders", new XVar(  ),
"pageTitles", new XVar(  ) ), "COSMIC KEY OS");
			}
		}
	}

}
