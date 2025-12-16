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
		public static void table_WORLD_LINE()
		{
			GlobalVars.runnerTableSettings.InitAndSetArrayItem(new XVar( "name", "WORLD LINE",
"type", 6,
"shortName", "WORLD_LINE",
"pagesByType", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ) ),
"pageTypes", new XVar( "add", "add",
"export", "export",
"import", "import",
"list", "list",
"print", "print" ),
"defaultPages", new XVar( "add", "add",
"export", "export",
"import", "import",
"list", "list",
"print", "print" ),
"afterEditDetails", "WORLD LINE",
"afterAddDetail", "WORLD LINE",
"detailsBadgeColor", "e8926f",
"deviceHideFields", new XVar( "1", XVar.Array(),
"5", XVar.Array() ),
"originalTable", "",
"originalPagesByType", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ) ),
"originalPageTypes", new XVar( "add", "add",
"export", "export",
"import", "import",
"list", "list",
"print", "print" ),
"originalDefaultPages", new XVar( "add", "add",
"export", "export",
"import", "import",
"list", "list",
"print", "print" ),
"searchSettings", new XVar( "caseSensitiveSearch", false,
"searchableFields", XVar.Array(),
"searchSuggest", true,
"highlightSearchResults", true,
"hideDataUntilSearch", false,
"hideFilterUntilSearch", false,
"googleLikeSearchFields", XVar.Array() ),
"connId", "conn",
"clickActions", new XVar( "row", new XVar( "action", "noaction" ),
"fields", new XVar(  ) ),
"geoCoding", new XVar( "enabled", false,
"latField", "",
"lonField", "",
"addressFields", XVar.Array() ),
"whereTabs", XVar.Array(),
"labels", new XVar(  ),
"chartSettings", new XVar(  ),
"dataSourceOperations", new XVar( "selectList", new XVar( "type", "selectList",
"subtype", "sql",
"enabled", true,
"sql", "SELECT * FROM tableName" ) ),
"calendarSettings", new XVar( "categoryColors", XVar.Array() ),
"ganttSettings", new XVar( "categoryColors", XVar.Array() ) ), "WORLD LINE");
			if(XVar.Equals(XVar.Pack(CommonFunctions.mlang_getcurrentlang()), XVar.Pack("English")))
			{
				GlobalVars.runnerTableLabels.InitAndSetArrayItem(new XVar( "tableCaption", "WORLD LINE",
"fieldLabels", new XVar(  ),
"fieldTooltips", new XVar(  ),
"fieldPlaceholders", new XVar(  ),
"pageTitles", new XVar(  ) ), "WORLD LINE");
			}
		}
	}

}
