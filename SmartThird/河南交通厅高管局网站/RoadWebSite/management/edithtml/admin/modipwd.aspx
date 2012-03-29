<!--#include file = "private.aspx"-->

<%
'######################################
' eWebEditor v3.00 - Advanced online web based WYSIWYG HTML editor.
' Copyright (c) 2003-2004 eWebSoft.com
'
' For further information go to http://www.ewebsoft.com/
' This copyright notice MUST stay intact for use.
'######################################
%>

<%

sPosition = sPosition & "修改用户名及密码"

Call Header()
Call Content()
Call Footer()

%>

<script language="vb" runat="server">

Sub Content()
	Select Case sAction
	Case "MODI"
		Call DoModi()
	Case Else
		Call ShowForm()
	End Select
End Sub


Sub ShowForm()

	Response.Write ("<script language=javascript>" & VBcrlf & _
	"function checklogin() {" & VBcrlf & _
		"var obj;" & VBcrlf & _
		"obj=document.myform.newusr;" & VBcrlf & _
		"obj.value=BaseTrim(obj.value);" & VBcrlf & _
		"if (obj.value=="""") {" & VBcrlf & _
			"BaseAlert(obj, ""新用户名不能为空！"");" & VBcrlf & _
			"return false;" & VBcrlf & _
		"}" & VBcrlf & _
		"obj=document.myform.newpwd1;" & VBcrlf & _
		"obj.value=BaseTrim(obj.value);" & VBcrlf & _
		"if (obj.value=="""") {" & VBcrlf & _
			"BaseAlert(obj, ""新密码不能为空！"");" & VBcrlf & _
			"return false;" & VBcrlf & _
		"}" & VBcrlf & _
		"if (document.myform.newpwd1.value!=document.myform.newpwd2.value){" & VBcrlf & _
			"BaseAlert(document.myform.newpwd1, ""新密码和确认密码不相同！"");" & VBcrlf & _
			"return false;" & VBcrlf & _
		"}" & VBcrlf & _
		"return true;" & VBcrlf & _
	"}" & VBcrlf & _
	"</s" & "cript>")

	Response.Write ("<table border=0 cellspacing=1 align=center class=navi>" & _
	"<tr><th><%=sPosition%></th></tr>" & _
	"</table>")

	Response.Write ("<br>")

	Response.Write ("<table border=0 cellspacing=1 align=center class=form>" & _
	"<form action='?action=modi' method=post name=myform onsubmit=""return checklogin()"">" & _
	"<tr>" & _
		"<th>设置名称</th>" & _
		"<th>基本参数设置</th>" & _
		"<th>设置说明</th>" & _
	"</tr>" & _
	"<tr>" & _
		"<td width=""15%"">新用户名：</td>" & _
		"<td width=""55%""><input type=text class=input size=20 name=newusr value=""" & inHTML(Session("eWebEditor_User")) & """></td>" & _
		"<td width=""30%""><span class=red>*</span>&nbsp;&nbsp;旧用户名：<span class=blue>" & outHTML(Session("eWebEditor_User")) & "</span></td>" & _
	"</tr>" & _
	"<tr>" & _
		"<td width=""15%"">新 密 码：</td>" & _
		"<td width=""55%""><input type=password class=input size=20 name=newpwd1 maxlength=30></td>" & _
		"<td width=""30%""><span class=red>*</span></td>" & _
	"</tr>" & _
	"<tr>" & _
		"<td width=""15%"">确认密码：</td>" & _
		"<td width=""55%""><input type=password class=input size=20 name=newpwd2 maxlength=30></td>" & _
		"<td width=""30%""><span class=red>*</span></td>" & _
	"</tr>" & _
	"<tr><td align=center colspan=3><input type=submit name=bSubmit value=""  提交  ""></a>&nbsp;<input type=reset name=bReset value=""  重填  ""></td></tr>" & _
	"</form>" & _
	"</table>")

End Sub

Sub DoModi()

	Dim sNewUsr, sNewPwd1, sNewPwd2
	sNewUsr = Trim(Request("newusr"))
	sNewPwd1 = Trim(Request("newpwd1"))
	sNewPwd2 = Trim(Request("newpwd2"))

	If sNewUsr = "" Then
		GoError ("新用户名不能为空！")
	End If
	If sNewPwd1 = "" then
		GoError ("新密码不能为空！")
	End If
	If sNewPwd1 <> sNewPwd2 Then
		GoError ("新密码和确认密码不相同！")
	End If

	sUsername = sNewUsr
	sPassword = sNewPwd1

	Call WriteConfig()

	Response.Write("<table border=0 cellspacing=1 align=center class=navi>" & _
	"<tr><th>" & sPosition & "</th></tr>" & _
	"</table>")

	Response.Write ("<br>")

	Response.Write ("<table border=0 cellspacing=1 align=center class=list>" & _
	"<tr>" & _
		"<td>登录用户名及密码修改成功！</td>" & _
	"</tr>" & _
	"</table>")

End Sub

</script>