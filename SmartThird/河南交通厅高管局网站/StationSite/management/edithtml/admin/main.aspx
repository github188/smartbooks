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
sPosition = sPosition & "后台管理首页"

Call Header()
Call Content()
Call Footer()

%>


<script language="vb" runat="server">

Sub Content()
	Response.Write ("<table border=0 cellspacing=1 align=center class=navi>" & _
		"<tr><th>" & sPosition & "</th></tr>" & _
		"</table>")

	Response.Write ("<br>")

	Response.Write ("<table border=0 cellspacing=1 align=center class=list>" & _
		"<tr><th colspan=2>eWebEditor 3.0 版权、常用联系方法、技术支持</th></tr>" & _
		"<tr>" & _
			"<td width='15%'>软件版本：</td>" & _
			"<td width='85%'>eWebEditor Version 3.0 简体中文专业版</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>版权所有：</td>" & _
			"<td width='85%'><a href='http://www.ewebsoft.com' target='_blank'>eWebSoft.com</a>&nbsp;&nbsp;已获得国家版权局颁发的《计算机软件著作权登记证书》,登记号:2004SR06549</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>程序制作：</td>" & _
			"<td width='85%'>eWeb开发团队</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>主页地址：</td>" & _
			"<td width='85%'><a href='http://www.eWebSoft.com' target=_blank>http://www.eWebSoft.com</a>&nbsp;&nbsp;&nbsp;<a href='http://www.webasp.net' target=_blank>http://www.webasp.net</a></td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>产品介绍：</td>" & _
			"<td width='85%'><a href='http://www.eWebSoft.com/Product/eWebEditor/' target=_blank>http://www.eWebSoft.com/Product/eWebEditor/</a></td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>论坛地址：</td>" & _
			"<td width='85%'><a href='http://bbs.webasp.net' target=_blank>http://bbs.webasp.net</a></td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>联系方式：</td>" & _
			"<td width='85%'>OICQ:589808&nbsp;&nbsp;&nbsp;&nbsp;Email:<a href='mailto:webmaster@webasp.net'>webmaster@webasp.net</a></td>" & _
		"</tr>" & _
		"</table>")

		Response.Write ("<br>")

		Response.Write ("<table border=0 cellspacing=1 align=center class=list>" & _
		"<tr><th colspan=2>服务器的有关参数</th><th colspan=2>组件支持有关参数</th></tr>" & _
		"<tr>" & _
			"<td width='15%'>服务器名：</td>" & _
			"<td width='45%'>" & Request.ServerVariables("SERVER_NAME") & "</td>" & _
			"<td width='20%'>ADO 数据对像：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("adodb.connection", 1) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>服务器IP：</td>" & _
			"<td width='45%'>" & Request.ServerVariables("LOCAL_ADDR") & "</td>" & _
			"<td width='20%'>FSO 文本文件读写：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("scripting.filesystemobject", 0) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>服务器端口：</td>" & _
			"<td width='45%'>" & Request.ServerVariables("SERVER_PORT") & "</td>" & _
			"<td width='20%'>Stream 文件流：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("Adodb.Stream", 0) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>服务器时间：</td>" & _
			"<td width='45%'>" & Now() & "</td>" & _
			"<td width='20%'>Jmail 邮件收发：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("JMail.SMTPMail", 1) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>IIS版本：</td>" & _
			"<td width='45%'>" & Request.ServerVariables("SERVER_SOFTWARE") & "</td>" & _
			"<td width='20%'>ASPmail 发信：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("SMTPsvg.Mailer", 1) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>服务器操作系统：</td>" & _
			"<td width='45%'>" & Request.ServerVariables("OS") & "</td>" & _
			"<td width='20%'>CDONTS 虚拟SMTP发信：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("CDONTS.NewMail", 1) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>脚本超时时间：</td>" & _
			"<td width='45%'>" & Server.ScriptTimeout & " 秒</td>" & _
			"<td width='20%'>LyfUpload 上传组件：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("LyfUpload.UploadFile", 1) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>站点物理路径：</td>" & _
			"<td width='45%'>" & request.ServerVariables("APPL_PHYSICAL_PATH") & "</td>" & _
			"<td width='20%'>AspUpload 上传组件：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("Persits.Upload.1", 1) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>服务器CPU数量：</td>" & _
			"<td width='45%'>" & Request.ServerVariables("NUMBER_OF_PROCESSORS") & " 个</td>" & _
			"<td width='20%'>SA-FileUp 上传组件：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("SoftArtisans.FileUp", 1) & "</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td width='15%'>服务器解译引擎：</td>" & _
			"<td width='45%'>" & ScriptEngine & "/" & ScriptEngineMajorVersion & "." & ScriptEngineMinorVersion & "." & ScriptEngineBuildVersion  & "</td>" & _
			"<td width='20%'>AspJpeg 图像处理组件：</td>" & _
			"<td width='20%'>" & Get_ObjInfo("Persits.Jpeg",1) & "</td>" & _
		"</tr>" & _
		"</table>")

	
End Sub

Function Get_ObjInfo(obj, ver)
	On Error Resume Next
	Dim objTest, sTemp
	objTest = Server.CreateObject(obj)
	If Err.Number <> 0 Then
		Err.Clear
		Get_ObjInfo = "<font class=red><b>×</b></font>&nbsp;<font class=gray>不支持</font>"
	Else
		sTemp = ""
		If ver = 1 Then
			sTemp = objTest.version
			If IsDBNull(sTemp) Then sTemp = objTest.about
			sTemp = Replace(sTemp, "Version", "")
			sTemp = "&nbsp;<font class=tims><font class=blue>" & sTemp & "</font></font>"
		End If
		Get_ObjInfo = "<b>√</b>&nbsp;<font class=gray>支持</font>" & sTemp
	End If
	objTest = Nothing
	If Err.Number <> 0 Then Err.Clear
End Function

</script>