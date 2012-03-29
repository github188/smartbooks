config.ButtonDir = "standard";
config.StyleUploadDir = "../uploadfile/";
config.InitMode = "EDIT";
config.AutoDetectPasteFromWord = "1";
config.BaseUrl = "1";
config.BaseHref = "";
config.AutoRemote = "1";
config.ShowBorder = "1";
config.StateFlag = "1";
config.CssDir = "blue";
config.AutoDetectLanguage = "1";
config.DefaultLanguage = "zh-cn";

function showToolbar(){

	document.write ("<table border=0 cellpadding=0 cellspacing=0 width='100%' class='Toolbar' id='eWebEditor_Toolbar'><tr><td><div class=yToolbar><SELECT CLASS=TBGen onchange=\"format('fontname',this[this.selectedIndex].value);this.selectedIndex=0\">"+lang["FontName"]+"</SELECT><DIV CLASS=Btn TITLE='"+lang["ForeColor"]+"' onclick=\"showDialog('selcolor.htm?action=forecolor', true)\"><IMG CLASS=Ico SRC='buttonimage/standard/forecolor.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["FontMenu"]+"' onclick=\"showToolMenu('font')\"><IMG CLASS=Ico SRC='buttonimage/standard/fontmenu.gif'></DIV><SELECT CLASS=TBGen onchange=\"format('fontsize',this[this.selectedIndex].value);this.selectedIndex=0\">"+lang["FontSize"]+"</SELECT><DIV CLASS=Btn TITLE='"+lang["Bold"]+"' onclick=\"format('bold')\"><IMG CLASS=Ico SRC='buttonimage/standard/bold.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["Italic"]+"' onclick=\"format('italic')\"><IMG CLASS=Ico SRC='buttonimage/standard/italic.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["UnderLine"]+"' onclick=\"format('underline')\"><IMG CLASS=Ico SRC='buttonimage/standard/underline.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["StrikeThrough"]+"' onclick=\"format('StrikeThrough')\"><IMG CLASS=Ico SRC='buttonimage/standard/strikethrough.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["JustifyLeft"]+"' onclick=\"format('justifyleft')\"><IMG CLASS=Ico SRC='buttonimage/standard/justifyleft.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["JustifyCenter"]+"' onclick=\"format('justifycenter')\"><IMG CLASS=Ico SRC='buttonimage/standard/justifycenter.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["JustifyRight"]+"' onclick=\"format('justifyright')\"><IMG CLASS=Ico SRC='buttonimage/standard/justifyright.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["JustifyFull"]+"' onclick=\"format('JustifyFull')\"><IMG CLASS=Ico SRC='buttonimage/standard/justifyfull.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["OrderedList"]+"' onclick=\"format('insertorderedlist')\"><IMG CLASS=Ico SRC='buttonimage/standard/insertorderedlist.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["UnOrderedList"]+"' onclick=\"format('insertunorderedlist')\"><IMG CLASS=Ico SRC='buttonimage/standard/insertunorderedlist.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["Image"]+"' onclick=\"showDialog('img.htm', true)\"><IMG CLASS=Ico SRC='buttonimage/standard/img.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["Flash"]+"' onclick=\"showDialog('flash.htm', true)\"><IMG CLASS=Ico SRC='buttonimage/standard/flash.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["Media"]+"' onclick=\"showDialog('media.htm', true)\"><IMG CLASS=Ico SRC='buttonimage/standard/media.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["File"]+"' onclick=\"showDialog('file.htm', true)\"><IMG CLASS=Ico SRC='buttonimage/standard/file.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["Emot"]+"' onclick=\"showDialog('emot.htm', true)\"><IMG CLASS=Ico SRC='buttonimage/standard/emot.gif'></DIV><DIV CLASS=Btn TITLE='"+lang["ParagraphMenu"]+"' onclick=\"showToolMenu('paragraph')\"><IMG CLASS=Ico SRC='buttonimage/standard/paragraphmenu.gif'></DIV></div></td></tr></table>");

}
