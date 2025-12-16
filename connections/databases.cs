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
		public static void Databases()
		{
			GlobalVars.runnerDatabases = new XVar(new XVar( "conn", new XVar( "connId", "conn",
"connName", "localhost",
"dbType", 1,
"connStringType", "oracle",
"connInfo", new XVar( 0, "",
1, "",
2, "localhost" ) ) ));
			GlobalVars.runnerRestConnections = new XVar(new XVar(  ));
		}
	}

}
