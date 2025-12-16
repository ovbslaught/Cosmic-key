
		// COSMIC KEY
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
			public static partial class Options_COSMIC_KEY_export
			{
				static public XVar options()
				{
					return new XVar( "fields", new XVar( "gridFields", XVar.Array(),
"exportFields", XVar.Array(),
"searchRequiredFields", XVar.Array(),
"searchPanelFields", XVar.Array(),
"fieldItems", new XVar(  ) ),
"pageLinks", new XVar( "edit", false,
"add", false,
"view", false,
"print", false ),
"layoutHelper", new XVar( "formItems", new XVar( "formItems", new XVar( "supertop", XVar.Array(),
"top", new XVar( 0, "export_header" ),
"grid", XVar.Array(),
"footer", new XVar( 0, "export_export",
1, "export_cancel" ) ),
"formXtTags", new XVar( "supertop", XVar.Array(),
"grid", XVar.Array() ),
"itemForms", new XVar( "export_header", "top",
"export_export", "footer",
"export_cancel", "footer" ),
"itemLocations", new XVar(  ),
"itemVisiblity", new XVar(  ) ),
"itemsByType", new XVar( "export_header", new XVar( 0, "export_header" ),
"export_export", new XVar( 0, "export_export" ),
"export_cancel", new XVar( 0, "export_cancel" ) ),
"cellMaps", new XVar(  ) ),
"page", new XVar( "verticalBar", false,
"labeledButtons", new XVar( "update_records", new XVar(  ),
"print_pages", new XVar(  ),
"register_activate_message", new XVar(  ),
"details_found", new XVar(  ) ),
"hasCustomButtons", false,
"customButtons", XVar.Array(),
"codeSnippets", XVar.Array(),
"clickHandlerSnippets", XVar.Array(),
"hasNotifications", false,
"menus", XVar.Array(),
"calcTotalsFor", 1,
"hasCharts", false ),
"events", new XVar( "maps", XVar.Array(),
"mapsData", new XVar(  ),
"buttons", XVar.Array() ),
"export", new XVar( "format", 2,
"selectFields", false,
"delimiter", ",",
"selectDelimiter", false,
"exportFileTypes", new XVar( "excel", true,
"word", true,
"csv", true,
"xml", false ) ) );
				}
				static public XVar page()
				{
					return new XVar( "id", "export",
"type", "export",
"layoutId", "first",
"disabled", false,
"default", 0,
"forms", new XVar( "supertop", new XVar( "modelId", "panel-top",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", XVar.Array() ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"top", new XVar( "modelId", "export-header",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", new XVar( 0, "export_header" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"grid", new XVar( "modelId", "export-grid",
"grid", XVar.Array(),
"cells", new XVar(  ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ),
"footer", new XVar( "modelId", "export-footer",
"grid", new XVar( 0, new XVar( "cells", new XVar( 0, new XVar( "cell", "c1" ),
1, new XVar( "cell", "c2" ) ),
"section", "" ) ),
"cells", new XVar( "c1", new XVar( "model", "c1",
"items", XVar.Array() ),
"c2", new XVar( "model", "c2",
"items", new XVar( 0, "export_export",
1, "export_cancel" ) ) ),
"deferredItems", XVar.Array(),
"recsPerRow", 1 ) ),
"items", new XVar( "export_header", new XVar( "type", "export_header" ),
"export_export", new XVar( "type", "export_export" ),
"export_cancel", new XVar( "type", "export_cancel" ) ),
"dbProps", new XVar(  ),
"version", 13,
"imageItem", new XVar( "type", "page_image" ),
"imageBgColor", "#f2f2f2",
"controlsBgColor", "white",
"imagePosition", "right",
"listTotals", 1,
"title", new XVar(  ),
"exportFormat", 2,
"exportDelimiter", ",",
"exportSelectDelimiter", false,
"exportSelectFields", false );
				}
			}
		}