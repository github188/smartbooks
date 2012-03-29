/*
*######################################
* eWebEditor v3.00 - Advanced online web based WYSIWYG HTML editor.
* Copyright (c) 2003-2004 eWebSoft.com
*
* For further information go to http://www.ewebsoft.com/
* This copyright notice MUST stay intact for use.
*######################################
*/

var sPath = document.location.pathname;
sPath = sPath.substr(0, sPath.length-14);
config.StyleMenuHeader = "<head><link href='"+sPath+"css/"+config.CssDir+"/menuarea.css' type='text/css' rel='stylesheet'></head><body scroll='no' onConTextMenu='event.returnValue=false;'>";

var sBaseHref = "";
if(config.BaseHref!=""){
	sBaseHref = "<base href='" + document.location.protocol + "//" + document.location.host + config.BaseHref + "'>";
}
config.StyleEditorHeader = "<head><link href='" + sPath + "css/" + config.CssDir + "/editorarea.css' type='text/css' rel='stylesheet'>" + sBaseHref + "</head><body MONOSPACE>" ;

document.write ("<title>eWebEditor</title><link href='css/" + config.CssDir + "/editor.css' type='text/css' rel='stylesheet'>");

document.write ("<script type='text/javascript' src='js/editor.js'><\/script>");
document.write ("<script type='text/javascript' src='js/table.js'><\/script>");
document.write ("<script type='text/javascript' src='js/menu.js'><\/script>");

document.write ("</head>");
document.write ("<body SCROLLING=no onConTextMenu='event.returnValue=false;'>");

document.write ("<script type='text/javascript' src='js/show.js'><\/script>");

document.write ("</body></html>");
