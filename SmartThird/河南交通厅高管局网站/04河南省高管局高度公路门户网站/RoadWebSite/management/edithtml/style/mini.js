config.ButtonDir = "standard";
config.StyleUploadDir = "uploadfile/";
config.InitMode = "EDIT";
config.AutoDetectPasteFromWord = "1";
config.BaseUrl = "1";
config.BaseHref = "";
config.AutoRemote = "1";
config.ShowBorder = "0";
config.StateFlag = "1";
config.CssDir = "coolblue";
config.AutoDetectLanguage = "1";
config.DefaultLanguage = "zh-cn";

function showToolbar(){

	document.write ("<table border=0 cellpadding=0 cellspacing=0 width='100%' class='Toolbar' id='eWebEditor_Toolbar'><tr><td><div class=yToolbar><DIV CLASS=TBHandle></DIV><SELECT CLASS=TBGen onchange=\"format('FormatBlock',this[this.selectedIndex].value);this.selectedIndex=0\">"+lang["FormatBlock"]+"</SELECT><SELECT CLASS=TBGen onchange=\"format('fontname',this[this.selectedIndex].value);this.selectedIndex=0\">"+lang["FontName"]+"</SELECT><SELECT CLASS=TBGen onchange=\"format('fontsize',this[this.selectedIndex].value);this.selectedIndex=0\">"+lang["FontSize"]+"</SELECT><SELECT CLASS=TBGen onchange=\"doZoom(this[this.selectedIndex].value)\"><option value='10'>10%</option><option value='25'>25%</option><option value='50'>50%</option><option value='75'>75%</option><option value='100' selected>100%</option><option value='150'>150%</option><option value='200'>200%</option><option value='500'>500%</option></SELECT><DIV CLASS=TBSep></DIV><DIV CLASS=Btn TITLE='"+lang["EditMenu"]+"' onclick=\"showToolMenu('edit')\"><IMG CLASS=Ico SRC='buttonimage/standard/editmenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["FontMenu"]+"' onclick=\"showToolMenu('font')\"><IMG CLASS=Ico SRC='buttonimage/standard/fontmenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["ParagraphMenu"]+"' onclick=\"showToolMenu('paragraph')\"><IMG CLASS=Ico SRC='buttonimage/standard/paragraphmenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["ComponentMenu"]+"' onclick=\"showToolMenu('component')\"><IMG CLASS=Ico SRC='buttonimage/standard/componentmenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["ObjectMenu"]+"' onclick=\"showToolMenu('object')\"><IMG CLASS=Ico SRC='buttonimage/standard/objectmenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["ToolMenu"]+"' onclick=\"showToolMenu('tool')\"><IMG CLASS=Ico SRC='buttonimage/standard/toolmenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["FormMenu"]+"' onclick=\"showToolMenu('form')\"><IMG CLASS=Ico SRC='buttonimage/standard/formmenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["TableMenu"]+"' onclick=\"showToolMenu('table')\"><IMG CLASS=Ico SRC='buttonimage/standard/tablemenu.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["FileMenu"]+"' onclick=\"showToolMenu('file')\"><IMG CLASS=Ico SRC='buttonimage/standard/filemenu.gif'></DIV>");

	if (sFullScreen=="1"){
		document.write ("<DIV CLASS=Btn TITLE='"+lang["Minimize"]+"' onclick=\"parent.Minimize()\"><IMG CLASS=Ico SRC='buttonimage/standard/minimize.gif'></DIV>");
	}else{
		document.write ("<DIV CLASS=Btn TITLE='"+lang["Maximize"]+"' onclick=\"Maximize()\"><IMG CLASS=Ico SRC='buttonimage/standard/maximize.gif'></DIV>");
	}

	document.write ("</div></td></tr></table>");

}
