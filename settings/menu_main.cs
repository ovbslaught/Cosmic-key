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
		public static void menu_main()
		{
			GlobalVars.runnerMenus.InitAndSetArrayItem(new XVar( "name", "main",
"id", "main",
"treeLike", true,
"root", new XVar( "id", "",
"parent", "",
"children", new XVar( 0, new XVar( "id", "4",
"parent", "",
"children", XVar.Array(),
"data", new XVar( "name", new XVar( "table", "COSMIC KEY",
"type", 6 ),
"comments", new XVar( "text", "",
"type", 0 ),
"style", "",
"href", "",
"params", "",
"pageId", "",
"itemType", 2,
"linkType", 0,
"openType", 0,
"iconType", 2,
"iconName", "glyphicon-hand-right",
"iconStyle", 0,
"showIconType", 2,
"linkToAnotherApp", false,
"table", 2642,
"pageType", "list" ) ),
1, new XVar( "id", "5",
"parent", "",
"children", XVar.Array(),
"data", new XVar( "name", new XVar( "table", "COSMIC KEY chart",
"type", 6 ),
"comments", new XVar( "text", "",
"type", 0 ),
"style", "",
"href", "",
"params", "",
"pageId", "",
"itemType", 2,
"linkType", 0,
"openType", 0,
"iconType", 2,
"iconName", "glyphicon-hand-right",
"iconStyle", 0,
"showIconType", 2,
"linkToAnotherApp", false,
"table", 2671,
"pageType", "chart" ) ),
2, new XVar( "id", "6",
"parent", "",
"children", XVar.Array(),
"data", new XVar( "name", new XVar( "table", "sqlView",
"type", 6 ),
"comments", new XVar( "text", "",
"type", 0 ),
"style", "",
"href", "",
"params", "",
"pageId", "",
"itemType", 2,
"linkType", 0,
"openType", 0,
"iconType", 2,
"iconName", "glyphicon-headphones",
"iconStyle", 0,
"showIconType", 2,
"linkToAnotherApp", false,
"table", 3011,
"pageType", "list" ) ) ),
"data", new XVar( "name", new XVar( "text", "",
"type", 0 ),
"comments", new XVar( "text", "",
"type", 0 ),
"style", "",
"href", "",
"params", "",
"pageId", "",
"itemType", 0,
"linkType", 2,
"openType", 0,
"iconType", 0,
"iconName", "",
"iconStyle", 0,
"showIconType", 1,
"linkToAnotherApp", false ) ) ), "main");
		}
	}

}
