<HTML>
<HEAD>
<TITLE>eWebEditor在线编辑器 - 使用例子</TITLE>
<META http-equiv=Content-Type content="text/html; charset=gb2312">
<style>
body,td,input,textarea {font-size:9pt}
</style>
</HEAD>
<BODY>





<p><b>eWebEditor 标准调用示例：</b></p>

<FORM method="POST" name="myform1" action="submit.aspx">
<TABLE border="0" cellpadding="2" cellspacing="1">
<TR>
	<TD>编辑内容：</TD>
	<TD>
		<INPUT type="hidden" name="content1" value="<P align=center><FONT color=#ff0000><FONT face='Arial Black' size=7><STRONG>eWeb<FONT color=#0000ff>Editor</FONT><FONT color=#000000><SUP>&trade;</SUP></FONT></STRONG></FONT></FONT></P><P align=right><FONT style='BACKGROUND-COLOR: #ffff00' color=#ff0000><STRONG>Version 3.0 简体中文专业版</STRONG></FONT></P><P>本样式为系统默认样式（coolblue），最佳调用宽度550px，高度350px！</FONT></P><P>下面为一些高级调用功能的例子，你可以用脚本方便的对编辑器进行一系列操作。</P><P><B><TABLE borderColor=#ff9900 cellSpacing=2 cellPadding=3 align=center bgColor=#ffffff border=1 heihgt=''><TBODY><TR><TD bgColor=#00ff00><STRONG>&nbsp;看到这些内容，且没有错误提示，说明安装已经正确完成！</STRONG></TD></TR></TBODY></TABLE></B></P>">
		<IFRAME ID="eWebEditor1" src="../ewebeditor.htm?id=content1&style=coolblue" frameborder="0" scrolling="no" width="550" height="350"></IFRAME>
	</TD>
</TR>
<TR>
	<TD colspan=2 align=right>
	<INPUT type=submit name=b1 value="提交"> 
	<INPUT type=reset name=b2 value="重填"> 
	<INPUT type=button name=b3 value="查看源文件" onclick="location.replace('view-source:'+location)"> 
	</TD>
</TR>
<TR>
	<TD>取到内容：</TD>
	<TD><TEXTAREA cols=50 rows=5 id=myTextArea style="width:550px">点击“取值”按钮，看一下效果！</TEXTAREA></TD>
</TR>
<TR>
	<TD colspan=2 align=right>
	<INPUT type=button name=b4 value="取值" onclick="myTextArea.value=eWebEditor1.getHTML()"> 
	<INPUT type=button name=b5 value="赋值" onclick="eWebEditor1.setHTML('<b>Hello My World!</b>')">
	<INPUT type=button name=b6 value="代码状态" onclick="eWebEditor1.setMode('CODE')">
	<INPUT type=button name=b7 value="设计状态" onclick="eWebEditor1.setMode('EDIT')">
	<INPUT type=button name=b8 value="文本状态" onclick="eWebEditor1.setMode('TEXT')">
	<INPUT type=button name=b8 value="预览状态" onclick="eWebEditor1.setMode('VIEW')">
	<INPUT type=button name=b9 value="当前位置插入" onclick="eWebEditor1.insertHTML('This is Insert Function!')">
	<INPUT type=button name=b10 value="尾部追加" onclick="eWebEditor1.appendHTML('This is Append Function!')">
	</TD>
</TR>
</TABLE>
</FORM>





<hr>





<Script Language=JavaScript>
function eWebEditorPopUp(form, field, width, height) {
	window.open("../popup.htm?style=popup&form="+form+"&field="+field, "", "width="+width+",height="+height+",toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=no");
}
</Script>

<p><b>eWebEditor 弹窗调用示例：</b></p>

<TABLE border="0" cellpadding="2" cellspacing="1">
<TR>
	<TD>编辑内容：</TD>
	<TD>
		<FORM ACTION="" METHOD="" NAME="myform2">
		<TEXTAREA NAME="myField" COLS="50" ROWS="10" style="width:550px">&lt;i&gt;eWebEditor 弹窗调用示例&lt;/i&gt;</TEXTAREA><br>
		<INPUT TYPE="BUTTON" NAME="btn" VALUE="HTML编辑" ONCLICK="eWebEditorPopUp('myform2', 'myField', 580, 380)">
		</FORM>
	</TD>
</TR>
<TR>
	<TD align=right colspan=2>
	<INPUT type=button name=b3 value="查看源文件" onclick="location.replace('view-source:'+location)"> 
	</TD>
</TR>
</TABLE>
<p><b>点击“HTML编辑”按钮，在弹出窗口编辑一些内容，然后点“保存返回”按钮，看一下效果！</b></p>



</BODY>
</HTML>
