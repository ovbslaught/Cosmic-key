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
		public static void pages()
		{
			GlobalVars.runnerPageInfo = new XVar(new XVar( "allPages", new XVar( "<global>", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ),
"menu", new XVar( 0, "menu" ) ),
"mother brain chart", new XVar( "chart", new XVar( 0, "chart" ) ),
"Nomadz Central", new XVar( "dashboard", new XVar( 0, "dashboard" ) ),
"COSMIC KEY", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ) ),
"COSMIC KEY chart", new XVar( "chart", new XVar( 0, "chart" ) ),
"WORLD LINE", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ) ),
"WORLD LINE chart", new XVar( "chart", new XVar( 0, "chart" ) ),
"WORLD LINE chart1", new XVar( "chart", new XVar( 0, "chart" ) ),
"COSMIC KEY OS", new XVar( "dashboard", new XVar( 0, "dashboard" ) ),
"sqlView", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ) ),
"WORLD LINE view", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ) ) ),
"tableMasks", new XVar( "mother brain chart", "S",
"sqlView", "ADSPI",
"WORLD LINE view", "ADSPI",
"Nomadz Central", "S",
"COSMIC KEY", "ADSPI",
"COSMIC KEY chart", "S",
"WORLD LINE chart1", "S",
"WORLD LINE", "ADSPI",
"COSMIC KEY OS", "S",
"WORLD LINE chart", "S",
"<global>", "S" ) ));
		}
	}

}
