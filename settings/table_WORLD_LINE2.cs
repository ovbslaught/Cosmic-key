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
		public static void table_WORLD_LINE2()
		{
			GlobalVars.runnerTableSettings.InitAndSetArrayItem(new XVar( "name", "WORLD LINE chart1",
"type", 9,
"shortName", "WORLD_LINE2",
"pagesByType", new XVar( "chart", new XVar( 0, "chart" ) ),
"pageTypes", new XVar( "chart", "chart" ),
"defaultPages", new XVar( "chart", "chart" ),
"afterEditDetails", "WORLD LINE chart1",
"afterAddDetail", "WORLD LINE chart1",
"detailsBadgeColor", "e8926f",
"deviceHideFields", new XVar( "1", XVar.Array(),
"5", XVar.Array() ),
"originalTable", "",
"originalPagesByType", new XVar( "chart", new XVar( 0, "chart" ) ),
"originalPageTypes", new XVar( "chart", "chart" ),
"originalDefaultPages", new XVar( "chart", "chart" ),
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
"chartSettings", new XVar( "shape", "Column",
"style", "None",
"is100Stacked", false,
"logarithmic", false,
"legend", true,
"grid", false,
"names", true,
"values", true,
"currency", false,
"labelField", "",
"labelInterval", 0,
"groupChart", false,
"width", 700,
"height", 530,
"preview", false,
"animation", true,
"ID", "2d_column",
"typeNumber", 24,
"type", "2DColumn",
"is3D", false,
"stacked", false,
"chartRefresh", false,
"chartRefreshTime", 60,
"bubbleTransparent", false,
"accumInverted", false,
"accumulationAppearance", 0,
"gaugeAppearance", 0,
"lineStyle", 0,
"header", new XVar( "text", "",
"type", 0 ),
"footer", new XVar( "text", "",
"type", 0 ),
"yAxisLabel", new XVar( "text", "",
"type", 0 ),
"dataSeries", XVar.Array() ),
"dataSourceOperations", new XVar( "selectList", new XVar( "type", "selectList",
"subtype", "sql",
"enabled", true,
"sql", "SELECT * FROM tableName" ) ),
"calendarSettings", new XVar( "categoryColors", XVar.Array() ),
"ganttSettings", new XVar( "categoryColors", XVar.Array() ) ), "WORLD LINE chart1");
			if(XVar.Equals(XVar.Pack(CommonFunctions.mlang_getcurrentlang()), XVar.Pack("English")))
			{
				GlobalVars.runnerTableLabels.InitAndSetArrayItem(new XVar( "tableCaption", "WORLD LINE Chart1",
"fieldLabels", new XVar(  ),
"fieldTooltips", new XVar(  ),
"fieldPlaceholders", new XVar(  ),
"pageTitles", new XVar(  ) ), "WORLD LINE chart1");
			}
		}
	}

}
