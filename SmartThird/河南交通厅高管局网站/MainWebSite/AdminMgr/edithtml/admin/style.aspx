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

sPosition = sPosition & "样式管理"

If sAction = "STYLEPREVIEW" Then
	Call InitStyle()
	Call ShowStylePreview()
	Response.End
End If


Call Header()
Call ShowPosition()
Call Content()
Call Footer()

%>

<script language="vb" runat="server">
Dim sStyleID, sStyleName, sStyleDir, sStyleCSS, sStyleUploadDir, sStyleWidth, sStyleHeight, sStyleMemo, nStyleIsSys, sStyleStateFlag, sStyleDetectFromWord, sStyleInitMode, sStyleBaseUrl, sStyleUploadObject, sStyleAutoDir, sStyleBaseHref, sStyleContentPath, sStyleAutoRemote, sStyleShowBorder, sAutoDetectLanguage, sDefaultLanguage
Dim sStyleFileExt, sStyleFlashExt, sStyleImageExt, sStyleMediaExt, sStyleRemoteExt, sStyleFileSize, sStyleFlashSize, sStyleImageSize, sStyleMediaSize, sStyleRemoteSize
Dim sToolBarID, sToolBarName, sToolBarOrder, sToolBarButton

Dim nStyleID

Sub Content()
	Select Case sAction
	Case "UPDATECONFIG"
		Call DoUpdateConfig()
	Case "COPY"
		Call InitStyle()
		Call DoCopy()
		Call ShowStyleList()
	Case "STYLEADD"
		Call ShowStyleForm("ADD")
	Case "STYLESET"
		Call InitStyle()
		Call ShowStyleForm("SET")
	Case "STYLEADDSAVE"
		Call CheckStyleForm()
		Call DoStyleAddSave()
	Case "STYLESETSAVE"
		Call CheckStyleForm()
		Call DoStyleSetSave()
	Case "STYLEDEL"
		Call InitStyle()
		Call DoStyleDel()
		Call ShowStyleList()
	Case "CODE"
		Call InitStyle()
		Call ShowStyleCode()
	Case "TOOLBAR"
		Call InitStyle()
		Call ShowToolBarList()
	Case "TOOLBARADD"
		Call InitStyle()
		Call DoToolBarAdd()
		Call ShowToolBarList()
	Case "TOOLBARMODI"
		Call InitStyle()
		Call DoToolBarModi()
		Call ShowToolBarList()
	Case "TOOLBARDEL"
		Call InitStyle()
		Call DoToolBarDel()
		Call ShowToolBarList()
	Case "BUTTONSET"
		Call InitStyle()
		Call InitToolBar()
		Call ShowButtonList()
	Case "BUTTONSAVE"
		Call InitStyle()
		Call InitToolBar()
		Call DoButtonSave()
	Case Else
		Call ShowStyleList()
	End Select
End Sub


Sub ShowPosition()
	Response.Write ("<table border=0 cellspacing=1 align=center class=navi>" & _
		"<tr><th>" & sPosition & "</th></tr>" & _
		"<tr><td align=center>[<a href='?'>所有样式列表</a>]&nbsp;&nbsp;&nbsp;&nbsp;[<a href='?action=styleadd'>新建一样式</a>]&nbsp;&nbsp;&nbsp;&nbsp;[<a href='?action=updateconfig'>更新所有样式的前台配置文件</a>]&nbsp;&nbsp;&nbsp;&nbsp;[<a href='#' onclick='history.back()'>返回前一页</a>]</td></tr>" & _
		"</table><br>")
End Sub

Sub ShowMessage(str)
	Response.Write ("<table border=0 cellspacing=1 align=center class=list><tr><td>" & str & "</td></tr></table><br>")
End Sub

Sub ShowStyleList()
	Call ShowMessage("<b class=blue>以下为当前所有样式列表：</b>")

	Response.Write ("<table border=0 cellpadding=0 cellspacing=1 class=list align=center>" & _
		"<form action='?action=del' method=post name=myform>" & _
		"<tr align=center>" & _
			"<th width='10%'>样式名</th>" & _
			"<th width='10%'>最佳宽度</th>" & _
			"<th width='10%'>最佳高度</th>" & _
			"<th width='45%'>说明</th>" & _
			"<th width='25%'>管理</th>" & _
		"</tr>")

	Dim sManage, i, aCurrStyle
	For i = 1 To Ubound(aStyle)
		aCurrStyle = Split(aStyle(i), "|||")
		sManage = "<a href='?action=stylepreview&id=" & i & "' target='_blank'>预览</a>|<a href='?action=code&id=" & i & "'>代码</a>|<a href='?action=styleset&id=" & i & "'>设置</a>|<a href='?action=toolbar&id=" & i & "'>工具栏</a>|<a href='?action=copy&id=" & i & "'>拷贝</a>|<a href='?action=styledel&id=" & i & "' onclick=""return confirm('提示：您确定要删除此样式吗？')"">删除</a>"
		Response.Write ("<tr align=center>" & _
			"<td>" & outHTML(aCurrStyle(0)) & "</td>" & _
			"<td>" & aCurrStyle(4) & "</td>" & _
			"<td>" & aCurrStyle(5) & "</td>" & _
			"<td align=left>" & outHTML(aCurrStyle(26)) & "</td>" & _
			"<td>" & sManage & "</td>" & _
			"</tr>")
	Next
	
	Response.Write ("</table><br>")

	Call ShowMessage("<b class=blue>提示：</b>你可以通过""拷贝""一样式以达到快速新建样式的目的。")

End Sub

Sub DoCopy()
	Dim i, b, sNewID, sNewName
	b = False
	i = 0
	Do While b = False
		i = i + 1
		sNewName = sStyleName & i
		If StyleName2ID(sNewName) = -1 Then
			b = True
		End If
	Loop

	Dim nNewStyleID
	nNewStyleID = Ubound(aStyle) + 1
	Redim Preserve aStyle(nNewStyleID)
	aStyle(nNewStyleID) = sNewName & Mid(aStyle(nStyleID), Len(sStyleName)+1)

	Dim nToolbarNum, nNewToolbarID, aCurrToolbar
	nToolbarNum = Ubound(aToolbar)
	For i = 1 To nToolbarNum
		aCurrToolbar = Split(aToolbar(i), "|||")
		If aCurrToolbar(0) = sStyleID Then
			nNewToolbarID = Ubound(aToolbar) + 1
			Redim Preserve aToolbar(nNewToolbarID)
			aToolbar(nNewToolbarID) = nNewStyleID & "|||" & aCurrToolbar(1) & "|||" & aCurrToolbar(2) & "|||" & aCurrToolbar(3)
		End If
	Next

	Call WriteConfig()
	Call WriteStyle(nNewStyleID)
	Call GoUrl("?")

End Sub

Function StyleName2ID(str)
	Dim i
	StyleName2ID = -1
	For i = 1 To UBound(aStyle)
		If Lcase(Split(aStyle(i), "|||")(0)) = Lcase(str) Then
			StyleName2ID = i
			Exit Function
		End If
	Next
End Function

Sub ShowStyleForm(sFlag)
	Dim s_Title, s_Button, s_Action
	Dim s_FormStateFlag, s_FormDetectFromWord, s_FormInitMode, s_FormBaseUrl, s_FormUploadObject, s_FormAutoDir, s_FormAutoRemote, s_FormShowBorder, s_FormAutoDetectLanguage, s_FormDefaultLanguage
	
	If sFlag = "ADD" Then
		sStyleID = ""
		sStyleName = ""
		sStyleDir = "standard"
		sStyleCSS = "office"
		sStyleUploadDir = "UploadFile/"
		sStyleBaseHref = "http://Localhost/eWebEditor/"
		sStyleContentPath = "UploadFile/"
		sStyleWidth = "600"
		sStyleHeight = "400"
		sStyleMemo = ""
		nStyleIsSys = 0
		s_Title = "新增样式"
		s_Action = "StyleAddSave"
		sStyleFileExt = "rar|zip|exe|doc|xls|chm|hlp"
		sStyleFlashExt = "swf"
		sStyleImageExt = "gif|jpg|jpeg|bmp"
		sStyleMediaExt = "rm|mp3|wav|mid|midi|ra|avi|mpg|mpeg|asf|asx|wma|mov"
		sStyleRemoteExt = "gif|jpg|bmp"
		sStyleFileSize = "500"
		sStyleFlashSize = "100"
		sStyleImageSize = "100"
		sStyleMediaSize = "100"
		sStyleRemoteSize = "100"
		sStyleStateFlag = "1"
		sStyleAutoRemote = "1"
		sStyleShowBorder = "0"
		sAutoDetectLanguage = "1"
		sDefaultLanguage = "zh-cn"
		sStyleUploadObject = "0"
		sStyleAutoDir = "0"
		sStyleDetectFromWord = "1"
		sStyleInitMode = "EDIT"
		sStyleBaseUrl = "0"
	Else
		sStyleName = inHTML(sStyleName)
		sStyleDir = inHTML(sStyleDir)
		sStyleCSS = inHTML(sStyleCSS)
		sStyleUploadDir = inHTML(sStyleUploadDir)
		sStyleBaseHref = inHTML(sStyleBaseHref)
		sStyleContentPath = inHTML(sStyleContentPath)
		sStyleMemo = inHTML(sStyleMemo)
		s_Title = "设置样式"
		s_Action = "StyleSetSave"
	End If

	s_FormStateFlag = InitSelect("d_stateflag", Split("显示|不显示", "|"), Split("1|0", "|"), sStyleStateFlag, "")
	s_FormAutoRemote = InitSelect("d_autoremote", Split("自动上传|不自动上传", "|"), Split("1|0", "|"), sStyleAutoRemote, "")
	s_FormShowBorder = InitSelect("d_showborder", Split("默认显示|默认不显示", "|"), Split("1|0", "|"), sStyleShowBorder, "")
	s_FormAutoDetectLanguage = InitSelect("d_autodetectlanguage", Split("自动检测|不自动检测", "|"), Split("1|0", "|"), sAutoDetectLanguage, "")
	s_FormDefaultLanguage = InitSelect("d_defaultlanguage", Split("简体中文|繁体中文|英文", "|"), Split("zh-cn|zh-tw|en", "|"), sDefaultLanguage, "")
	s_FormUploadObject = InitSelect("d_uploadobject", Split("ASP.net上传|ASPUpload上传组件|SA-FileUp上传组件|LyfUpload上传组件", "|"), Split("0|1|2|3", "|"), sStyleUploadObject, "")
	s_FormAutoDir = InitSelect("d_autodir", Split("不使用|年目录|年月目录|年月日目录", "|"), Split("0|1|2|3", "|"), sStyleAutoDir, "")
	s_FormDetectFromWord = InitSelect("d_detectfromword", Split("自动检测有提示|不自动检测", "|"), Split("1|0", "|"), sStyleDetectFromWord, "")
	s_FormInitMode = InitSelect("d_initmode", Split("代码模式|编辑模式|文本模式|预览模式", "|"), Split("CODE|EDIT|TEXT|VIEW", "|"), sStyleInitMode, "")
	s_FormBaseUrl = InitSelect("d_baseurl", Split("相对路径|绝对根路径|绝对全路径", "|"), Split("0|1|2", "|"), sStyleBaseUrl, "")

	s_Button = "<tr><td align=center colspan=4><input type=submit value='  提交  ' align=absmiddle>&nbsp;<input type=reset name=btnReset value='  重填  '></td></tr>"
	
	Response.Write ("<table border=0 cellpadding=0 cellspacing=1 align=center class=form>" & _
			"<form action='?action=" & s_Action & "&id=" & sStyleID & "' method=post name=myform>" & _
			"<tr><th colspan=4>&nbsp;&nbsp;" & s_Title & "（鼠标移到输入框可看说明，带*号为必填项）</th></tr>" & _
			"<tr><td width='15%'>样式名称：</td><td width='35%'><input type=text class=input size=20 name=d_name title='引用此样式的名字，不要加特殊符号，最大50个字符长度' value=""" & sStyleName & """> <span class=red>*</span></td><td width='15%'>初始模式：</td><td width='35%'>" & s_FormInitMode & " <span class=red>*</span></td></tr>" & _
			"<tr><td width='15%'>上传组件：</td><td width='35%'>" & s_FormUploadObject & " <span class=red>*</span></td><td width='15%'>自动目录：</td><td width='35%'>" & s_FormAutoDir & " <span class=red>*</span></td></tr>" & _
			"<tr><td width='15%'>图片目录：</td><td width='35%'><input type=text class=input size=20 name=d_dir title='存放此样式图片文件的目录名，必须在ButtonImage下，最大50个字符长度' value=""" & sStyleDir & """> <span class=red>*</span></td><td width='15%'>样式目录：</td><td width='35%'><input type=text class=input size=20 name=d_css title='存放此样式css文件的目录名，必须在CSS下，最大50个字符长度' value=""" & sStyleCSS & """> <span class=red>*</span></td></tr>" & _
			"<tr><td width='15%'>最佳宽度：</td><td width='35%'><input type=text class=input name=d_width size=20 title='最佳引用效果的宽度，数字型' value='" & sStyleWidth & "'> <span class=red>*</span></td><td width='15%'>最佳高度：</td><td width='35%'><input type=text class=input name=d_height size=20 title='最佳引用效果的高度，数字型' value='" & sStyleHeight & "'> <span class=red>*</span></td></tr>" & _
			"<tr><td width='15%'>状 态 栏：</td><td width='35%'>" & s_FormStateFlag & " <span class=red>*</span></td><td width='15%'>Word粘贴：</td><td width='35%'>" & s_FormDetectFromWord & " <span class=red>*</span></td></tr>" & _
			"<tr><td width='15%'>远程文件：</td><td width='35%'>" & s_FormAutoRemote & " <span class=red>*</span></td><td width='15%'>指导方针：</td><td width='35%'>" & s_FormShowBorder & " <span class=red>*</span></td></tr>" & _
			"<tr><td width='15%'>自动语言检测：</td><td width='35%'>" & s_FormAutoDetectLanguage & " <span class=red>*</span></td><td width='15%'>默认语言：</td><td width='35%'>" & s_FormDefaultLanguage & " <span class=red>*</span></td></tr>" & _
			"<tr><td colspan=4><span class=red>&nbsp;&nbsp;&nbsp;上传文件及系统文件路径相关设置（只有在使用相对路径模式时，才要设置显示路径和内容路径）：</span></td></tr>" & _
			"<tr><td width='15%'>路径模式：</td><td width='35%'>" & s_FormBaseUrl & " <span class=red>*</span> <a href='#baseurl'>说明</a></td><td width='15%'>上传路径：</td><td width='35%'><input type=text class=input size=20 name=d_uploaddir title='上传文件所存放路径，相对eWebEditor根目录文件的路径，最大50个字符长度' value=""" & sStyleUploadDir & """> <span class=red>*</span></td></tr>" & _
			"<tr><td width='15%'>显示路径：</td><td width='35%'><input type=text class=input size=20 name=d_basehref title='显示内容页所存放路径，必须以&quot;/&quot;开头，最大50个字符长度' value=""" & sStyleBaseHref & """></td><td width='15%'>内容路径：</td><td width='35%'><input type=text class=input size=20 name=d_contentpath title='实际保存在内容中的路径，相对显示路径的路径，不能以&quot;/&quot;开头，最大50个字符长度' value=""" & sStyleContentPath & """></td></tr>" & _
			"<tr><td colspan=4><span class=red>&nbsp;&nbsp;&nbsp;允许上传文件类型及文件大小设置（文件大小单位为KB，0表示没有限制）：</span></td></tr>" & _
			"<tr><td width='15%'>图片类型：</td><td width='35%'><input type=text class=input name=d_imageext size=20 title='用于图片相关的上传，最大250个字符长度' value='" & sStyleImageExt & "'></td><td width='15%'>图片限制：</td><td width='35%'><input type=text class=input name=d_imagesize size=20 title='数字型，单位KB' value='" & sStyleImageSize & "'></td></tr>" & _
			"<tr><td width='15%'>Flash类型：</td><td width='35%'><input type=text class=input name=d_flashext size=20 title='用于插入Flash动画，最大250个字符长度' value='" & sStyleFlashExt & "'></td><td width='15%'>Flash限制：</td><td width='35%'><input type=text class=input name=d_flashsize size=20 title='数字型，单位KB' value='" & sStyleFlashSize & "'></td></tr>" & _
			"<tr><td width='15%'>媒体类型：</td><td width='35%'><input type=text class=input name=d_mediaext size=20 title='用于插入媒体文件，最大250个字符长度' value='" & sStyleMediaExt & "'></td><td width='15%'>媒体限制：</td><td width='35%'><input type=text class=input name=d_mediasize size=20 title='数字型，单位KB' value='" & sStyleMediaSize & "'></td></tr>" & _
			"<tr><td width='15%'>其它类型：</td><td width='35%'><input type=text class=input name=d_fileext size=20 title='用于插入其它文件，最大250个字符长度' value='" & sStyleFileExt & "'></td><td width='15%'>其它限制：</td><td width='35%'><input type=text class=input name=d_filesize size=20 title='数字型，单位KB' value='" & sStyleFileSize & "'></td></tr>" & _
			"<tr><td width='15%'>远程类型：</td><td width='35%'><input type=text class=input name=d_remoteext size=20 title='用于自动上传远程文件，最大250个字符长度' value='" & sStyleRemoteExt & "'></td><td width='15%'>远程限制：</td><td width='35%'><input type=text class=input name=d_remotesize size=20 title='数字型，单位KB' value='" & sStyleRemoteSize & "'></td></tr>" & _
			"<tr><td>备注说明：</td><td colspan=3><input type=text name=d_memo size=90 title='此样式的说明，更有利于调用' value=""" & sStyleMemo & """></td></tr>" & s_Button & _
			"</form>" & _
			"</table><br>")

	Dim sMsg
	sMsg = "<a name=baseurl></a><p><span class=blue><b>路径模式设置说明：</b></span><br>" & _
		"<b>相对路径：</b>指所有的相关上传或自动插入文件路径，编辑后都以""UploadFile/...""或""../UploadFile/...""形式呈现，当使用此模式时，显示路径和内容路径必填，显示路径必须以""/""开头和结尾，内容路径设置中不能以""/""开头。<br>" & _
		"<b>绝对根路径：</b>指所有的相关上传或自动插入文件路径，编辑后都以""/eWebEditor/UploadFile/...""这种形式呈现，当使用此模式时，显示路径和内容路径不必填。<br>" & _
		"<b>绝对全路径：</b>指所有的相关上传或自动插入文件路径，编辑后都以""http://xxx.xxx.xxx/eWebEditor/UploadFile/...""这种形式呈现，当使用此模式时，显示路径和内容路径不必填。</p>"

	Call ShowMessage(sMsg)

End Sub

Sub InitStyle()
	Dim b, aCurrStyle
	b = False
	sStyleID = Trim(Request("id"))
	If IsNumeric(sStyleID) = True Then
		nStyleID = Clng(sStyleID)
		If nStyleID <= Ubound(aStyle) Then
			aCurrStyle = Split(aStyle(nStyleID), "|||")
			sStyleName = aCurrStyle(0)
			sStyleDir = aCurrStyle(1)
			sStyleCSS = aCurrStyle(2)
			sStyleUploadDir = aCurrStyle(3)
			sStyleBaseHref = aCurrStyle(22)
			sStyleContentPath = aCurrStyle(23)
			sStyleWidth = aCurrStyle(4)
			sStyleHeight = aCurrStyle(5)
			sStyleMemo = aCurrStyle(26)
			'nStyleIsSys = aCurrStyle()
			sStyleFileExt = aCurrStyle(6)
			sStyleFlashExt = aCurrStyle(7)
			sStyleImageExt = aCurrStyle(8)
			sStyleMediaExt = aCurrStyle(9)
			sStyleRemoteExt = aCurrStyle(10)
			sStyleFileSize = aCurrStyle(11)
			sStyleFlashSize = aCurrStyle(12)
			sStyleImageSize = aCurrStyle(13)
			sStyleMediaSize = aCurrStyle(14)
			sStyleRemoteSize = aCurrStyle(15)
			sStyleStateFlag = aCurrStyle(16)
			sStyleAutoRemote = aCurrStyle(24)
			sStyleShowBorder = aCurrStyle(25)
			sAutoDetectLanguage = aCurrStyle(27)
			sDefaultLanguage = aCurrStyle(28)
			sStyleUploadObject = aCurrStyle(20)
			sStyleAutoDir = aCurrStyle(21)
			sStyleDetectFromWord = aCurrStyle(17)
			sStyleInitMode = aCurrStyle(18)
			sStyleBaseUrl = aCurrStyle(19)
			b = True
		End If
	End If
	If b = False Then
		GoError ("无效的样式ID号，请通过页面上的链接进行操作！")
	End If
End Sub

Sub CheckStyleForm()
	sStyleName = Trim(Request("d_name"))
	sStyleDir = Trim(Request("d_dir"))
	sStyleCSS = Trim(Request("d_css"))
	sStyleUploadDir = Trim(Request("d_uploaddir"))
	sStyleBaseHref = Trim(Request("d_basehref"))
	sStyleContentPath = Trim(Request("d_contentpath"))
	sStyleWidth = Trim(Request("d_width"))
	sStyleHeight = Trim(Request("d_height"))
	sStyleMemo = Trim(Request("d_memo"))
	sStyleImageExt = Request("d_imageext")
	sStyleFlashExt = Request("d_flashext")
	sStyleMediaExt = Request("d_mediaext")
	sStyleRemoteExt = Request("d_remoteext")
	sStyleFileExt = Request("d_fileext")
	sStyleImageSize = Request("d_imagesize")
	sStyleFlashSize = Request("d_flashsize")
	sStyleMediaSize = Request("d_mediasize")
	sStyleRemoteSize = Request("d_remotesize")
	sStyleFileSize = Request("d_filesize")
	sStyleStateFlag = Request("d_stateflag")
	sStyleAutoRemote = Request("d_autoremote")
	sStyleShowBorder = Request("d_showborder")
	sAutoDetectLanguage = Request("d_autodetectlanguage")
	sDefaultLanguage = Request("d_defaultlanguage")
	sStyleUploadObject = Request("d_uploadobject")
	sStyleAutoDir = Request("d_autodir")
	sStyleDetectFromWord = Request("d_detectfromword")
	sStyleInitMode = Request("d_initmode")
	sStyleBaseUrl = Request("d_baseurl")

	sStyleUploadDir = Replace(sStyleUploadDir, "\", "/")
	sStyleBaseHref = Replace(sStyleBaseHref, "\", "/")
	sStyleContentPath = Replace(sStyleContentPath, "\", "/")
	If Right(sStyleUploadDir, 1) <> "/" Then sStyleUploadDir = sStyleUploadDir & "/"
	If Right(sStyleBaseHref, 1) <> "/" Then sStyleBaseHref = sStyleBaseHref & "/"
	If Right(sStyleContentPath, 1) <> "/" Then sStyleContentPath = sStyleContentPath & "/"

	If sStyleName = "" Or GetTrueLen(sStyleName) > 50 Then
		GoError ("样式名不能为空，且不大于50个字符长度！")
	End If
	If IsSafeStr(sStyleName) = False Then
		GoError ("样式名请勿包含特殊字符！")
	End If
	If sStyleDir = "" Or GetTrueLen(sStyleDir) > 50 Then
		GoError ("按钮图片目录名不能为空，且不大于50个字符长度！")
	End If
	If IsSafeStr(sStyleDir) = False Then
		GoError ("按钮图片目录名请勿包含特殊字符！")
	End If
	If sStyleCSS = "" Or GetTrueLen(sStyleCSS) > 50 Then
		GoError ("样式CSS目录名不能为空，且不大于50个字符长度！")
	End If
	If IsSafeStr(sStyleCSS) = False Then
		GoError ("样式CSS目录名请勿包含特殊字符！")
	End If

	If sStyleUploadDir = "" Or GetTrueLen(sStyleUploadDir) > 50 Then
		GoError ("上传路径不能为空，且不大于50个字符长度！")
	End If
	If IsSafeStr(sStyleUploadDir) = False Then
		GoError ("上传路径请勿包含特殊字符！")
	End If
	Select Case sStyleBaseUrl
	Case "0"
		If sStyleBaseHref = "" Or GetTrueLen(sStyleBaseHref) > 50 Then
			GoError ("当使用相对路径模式时，显示路径不能为空，且不大于50个字符长度！")
		End If
		If IsSafeStr(sStyleBaseHref) = False Then
			GoError ("当使用相对路径模式时，显示路径请勿包含特殊字符！")
		End If
		If Left(sStyleBaseHref, 1) <> "/" Then
			GoError ("当使用相对路径模式时，显示路径必须以&quot;/&quot;开头！")
		End If

		If sStyleContentPath = "" Or GetTrueLen(sStyleContentPath) > 50 Then
			GoError ("当使用相对路径模式时，内容路径不能为空，且不大于50个字符长度！")
		End If
		If IsSafeStr(sStyleContentPath) = False Then
			GoError ("当使用相对路径模式时，内容路径请勿包含特殊字符！")
		End If
		If Left(sStyleContentPath, 1) = "/" Then
			GoError ("当使用相对路径模式时，内容路径不能以&quot;/&quot;开头！")
		End If
	Case "1", "2"
		sStyleBaseHref = ""
		sStyleContentPath = ""
	End Select
	
	If IsNumeric(sStyleWidth) = False Then
		GoError ("请填写有效的最佳引用宽度！")
	End If
	If IsNumeric(sStyleHeight) = False Then
		GoError ("请填写有效的最佳引用高度！")
	End If

	If GetTrueLen(sStyleImageExt) > 250 Then
		GoError ("图片文件类型不能大于250个字符长度！")
	End If
	If GetTrueLen(sStyleFlashExt) > 250 Then
		GoError ("Flash文件类型不能大于250个字符长度！")
	End If
	If GetTrueLen(sStyleMediaExt) > 250 Then
		GoError ("媒体文件类型不能大于250个字符长度！")
	End If
	If GetTrueLen(sStyleFileExt) > 250 Then
		GoError ("其它文件类型不能大于250个字符长度！")
	End If
	If GetTrueLen(sStyleRemoteExt) > 250 Then
		GoError ("远程文件类型不能大于250个字符长度！")
	End If

	If IsNumeric(sStyleImageSize) = False Then
		GoError ("请填写有效的图片限制大小！")
	End If
	If IsNumeric(sStyleFlashSize) = False Then
		GoError ("请填写有效的Flash限制大小！")
	End If
	If IsNumeric(sStyleMediaSize) = False Then
		GoError ("请填写有效的媒体文件限制大小！")
	End If
	If IsNumeric(sStyleFileSize) = False Then
		GoError ("请填写有效的其它文件限制大小！")
	End If
	If IsNumeric(sStyleRemoteSize) = False Then
		GoError ("请填写有效的远程文件限制大小！")
	End If

End Sub

Sub DoStyleAddSave()

	If StyleName2ID(sStyleName) <> -1 Then
		GoError ("此样式名已经存在，请用另一个样式名！")
	End If

	Dim nNewStyleID
	nNewStyleID = Ubound(aStyle) + 1
	Redim Preserve aStyle(nNewStyleID)

	aStyle(nNewStyleID) = sStyleName & "|||" & sStyleDir & "|||" & sStyleCSS & "|||" & sStyleUploadDir & "|||" & sStyleWidth & "|||" & sStyleHeight & "|||" & sStyleFileExt & "|||" & sStyleFlashExt & "|||" & sStyleImageExt & "|||" & sStyleMediaExt & "|||" & sStyleRemoteExt & "|||" & sStyleFileSize & "|||" & sStyleFlashSize & "|||" & sStyleImageSize & "|||" & sStyleMediaSize & "|||" & sStyleRemoteSize & "|||" & sStyleStateFlag & "|||" & sStyleDetectFromWord & "|||" & sStyleInitMode & "|||" & sStyleBaseUrl & "|||" & sStyleUploadObject & "|||" & sStyleAutoDir & "|||" & sStyleBaseHref & "|||" & sStyleContentPath & "|||" & sStyleAutoRemote & "|||" & sStyleShowBorder & "|||" & sStyleMemo & "|||" & sAutoDetectLanguage & "|||" & sDefaultLanguage

	Call WriteConfig()
	Call WriteStyle(nNewStyleID)

	Call ShowMessage("<b><span class=red>样式增加成功！</span></b><li><a href='?action=toolbar&id=" & nNewStyleID & "'>设置此样式下的工具栏</a>")

End Sub

Sub DoUpdateConfig()
	Dim i
	Call WriteConfig()
	For i = 1 To UBound(aStyle)
		Call WriteStyle(i)
	Next
	Call ShowMessage("<b><span class=red>所有样式的前台配置文件更新操作成功！</span></b><li><a href='?'>返回所有样式列表</a>")
End Sub

Sub DoStyleSetSave()
	Dim n, s_OldStyleName
	sStyleID = Trim(Request("id"))
	If IsNumeric(sStyleID) = True Then
		n = StyleName2ID(sStyleName)
		If CStr(n) <> sStyleID And n <> -1 Then
			GoError ("此样式名已经存在，请用另一个样式名！")
		End If
		
		If Clng(sStyleID) < 1 And Clng(sStyleID)>UBound(aStyle) Then
			GoError ("无效的样式ID号，请通过页面上的链接进行操作！")
		End If

		s_OldStyleName = Split(aStyle(Clng(sStyleID)), "|||")(0)

		aStyle(Clng(sStyleID)) = sStyleName & "|||" & sStyleDir & "|||" & sStyleCSS & "|||" & sStyleUploadDir & "|||" & sStyleWidth & "|||" & sStyleHeight & "|||" & sStyleFileExt & "|||" & sStyleFlashExt & "|||" & sStyleImageExt & "|||" & sStyleMediaExt & "|||" & sStyleRemoteExt & "|||" & sStyleFileSize & "|||" & sStyleFlashSize & "|||" & sStyleImageSize & "|||" & sStyleMediaSize & "|||" & sStyleRemoteSize & "|||" & sStyleStateFlag & "|||" & sStyleDetectFromWord & "|||" & sStyleInitMode & "|||" & sStyleBaseUrl & "|||" & sStyleUploadObject & "|||" & sStyleAutoDir & "|||" & sStyleBaseHref & "|||" & sStyleContentPath & "|||" & sStyleAutoRemote & "|||" & sStyleShowBorder & "|||" & sStyleMemo & "|||" & sAutoDetectLanguage & "|||" & sDefaultLanguage

	Else
		GoError ("无效的样式ID号，请通过页面上的链接进行操作！")
	End If

	Call WriteConfig()
	If LCase(s_OldStyleName) <> LCase(sStyleName) Then
		Call DeleteFile(s_OldStyleName)
	End If
	Call WriteStyle(Clng(sStyleID))

	Call ShowMessage("<b><span class=red>样式修改成功！</span></b><li><a href='?action=stylepreview&id=" & sStyleID & "' target='_blank'>预览此样式</a><li><a href='?action=toolbar&id=" & sStyleID & "'>设置此样式下的工具栏</a>")

End Sub

Sub DoStyleDel()
	aStyle(Clng(sStyleID)) = ""
	Call WriteConfig()
	Call DeleteFile(sStyleName)
	Call GoUrl("?")
End Sub

Sub ShowStylePreview()
	Response.Write ("<html><head>" & _
		"<title>样式预览</title>" & _
		"<meta http-equiv='Content-Type' content='text/html; charset=gb2312'>" & _
		"</head><body>" & _
		"<input type=hidden name=content1  value=''>" & _
		"<iframe ID='eWebEditor1' src='../ewebeditor.htm?id=content1&style=" & sStyleName & "' frameborder=0 scrolling=no width='" & sStyleWidth & "' HEIGHT='" & sStyleHeight & "'></iframe>" & _
		"</body></html>")
End Sub

Sub ShowStyleCode()
	Response.Write ("<table border=0 cellspacing=1 align=center class=list>" & _
		"<tr><th>样式（" & outHTML(sStyleName) & "）的最佳调用代码如下（其中XXX按实际关联的表单项进行修改）：</th></tr>" & _
		"<tr><td><textarea rows=5 cols=65 style='width:100%'><IFRAME ID=""eWebEditor1"" SRC=""ewebeditor.htm?id=XXX&style=" & sStyleName & """ FRAMEBORDER=""0"" SCROLLING=""no"" WIDTH=""" & sStyleWidth & """ HEIGHT=""" & sStyleHeight & """></IFRAME></textarea></td></tr>" & _
		"</table>")
End Sub

Sub ShowToolBarList()

	Call ShowMessage("<b class=blue>样式（" & outHTML(sStyleName) & "）下的工具栏管理：</b>")

	Dim s_AddForm, s_ModiForm, i, aCurrToolbar

	If nStyleIsSys = 1 Then
		s_AddForm = ""
	Else
		Dim nMaxOrder
		nMaxOrder = 0
		For i = 1 To UBound(aToolbar)
			aCurrToolbar = Split(aToolbar(i), "|||")
			If aCurrToolbar(0) = sStyleID Then
				If Clng(aCurrToolbar(3)) > nMaxOrder Then
					nMaxOrder = Clng(aCurrToolbar(3))
				End If
			End If
		Next
		nMaxOrder = nMaxOrder + 1

		s_AddForm = "<hr width='80%' align=center size=1><table border=0 cellpadding=4 cellspacing=0 align=center>" & _
		"<form action='?id=" & sStyleID & "&action=toolbaradd' name='addform' method=post>" & _
		"<tr><td>工具栏名：<input type=text name=d_name size=20 class=input value='工具栏" & nMaxOrder & "'> 排序号：<input type=text name=d_order size=5 value='" & nMaxOrder & "' class=input> <input type=submit name=b1 value='新增工具栏'></td></tr>" & _
		"</form></table><hr width='80%' align=center size=1>"
	End If

	Dim s_Manage, s_SubmitButton
	s_ModiForm = "<form action='?id=" & sStyleID & "&action=toolbarmodi' name=modiform method=post>" & _
		"<table border=0 cellpadding=0 cellspacing=1 align=center class=form>" & _
		"<tr align=center><th>ID</th><th>工具栏名</th><th>排序号</th><th>操作</th></tr>"

	For i = 1 To UBound(aToolbar)
		aCurrToolbar = Split(aToolbar(i), "|||")
		If aCurrToolbar(0) = sStyleID Then
			s_Manage = "<a href='?id=" & sStyleID & "&action=buttonset&toolbarid=" & i & "'>按钮设置</a>"
			s_Manage = s_Manage & "|<a href='?id=" & sStyleID & "&action=toolbardel&delid=" & i & "'>删除</a>"
			s_ModiForm = s_ModiForm & "<tr align=center>" & _
				"<td>" & i & "</td>" & _
				"<td><input type=text name='d_name" & i & "' value=""" & inHTML(aCurrToolbar(2)) & """ size=30 class=input></td>" & _
				"<td><input type=text name='d_order" & i & "' value='" & aCurrToolbar(3) & "' size=5 class=input></td>" & _
				"<td>" & s_Manage & "</td>" & _
				"</tr>"
		End If
	Next

	s_SubmitButton = "<tr><td colspan=4 align=center><input type=submit name=b1 value='  修改  '></td></tr>"
	s_ModiForm = s_ModiForm & s_SubmitButton & "</table></form>"

	Response.Write (s_AddForm & s_ModiForm)

End Sub

Sub DoToolBarAdd()
	Dim s_Name, s_Order
	s_Name = Trim(Request("d_name"))
	s_Order = Trim(Request("d_order"))
	If s_Name = "" Or GetTrueLen(s_Name) > 50 Then
		GoError ("工具栏名不能为空，且长度不能大于50个字符长度！")
	End If
	If IsNumeric(s_Order) = False Then
		GoError ("无效的工具栏排序号，排序号必须为数字！")
	End If

	Dim nToolbarNum
	nToolbarNum = Ubound(aToolbar) + 1
	Redim Preserve aToolbar(nToolbarNum)
	aToolbar(nToolbarNum) = sStyleID & "||||||" & s_Name & "|||" & s_Order

	Call WriteConfig()
	Call WriteStyle(Clng(sStyleID))

	Response.Write ("<script language=javascript>alert(""工具栏（" & outHTML(s_Name) & "）增加操作成功！"");</s" & "cript>")
	Call GoUrl("?action=toolbar&id=" & sStyleID)
End Sub

Sub DoToolBarModi()
	Dim s_Name, s_Order, i, aCurrToolbar

	For i = 1 To UBound(aToolbar)
		aCurrToolbar = Split(aToolbar(i), "|||")
		If aCurrToolbar(0) = sStyleID Then
			s_Name = Trim(Request("d_name" & i))
			s_Order = Trim(Request("d_order" & i))
			If s_Name = "" Or IsNumeric(s_Order) = False Then 
				aCurrToolbar(0) = ""
				s_Name = ""
			End If
			aToolbar(i) = aCurrToolbar(0) & "|||" & aCurrToolbar(1) & "|||" & s_Name & "|||" & s_Order
		End If
	Next

	Call WriteConfig()
	Call WriteStyle(Clng(sStyleID))

	Response.Write ("<script language=javascript>alert('工具栏修改操作成功！');</s" & "cript>")
	Call GoUrl("?action=toolbar&id=" & sStyleID)

End Sub

Sub DoToolBarDel()
	Dim s_DelID
	s_DelID = Trim(Request("delid"))
	If IsNumeric(s_DelID) = True Then
		aToolbar(Clng(s_DelID)) = ""
		Call WriteConfig()
		Call WriteStyle(Clng(sStyleID))
		Response.Write ("<script language=javascript>alert('工具栏（ID：" & s_DelID & "）删除操作成功！');</s" & "cript>")
		Call GoUrl("?action=toolbar&id=" & sStyleID)
	End If
End Sub

Sub InitToolBar()
	Dim b, aCurrToolbar, nToolbarID
	b = False
	sToolBarID = Trim(Request("toolbarid"))
	If IsNumeric(sToolBarID) = True Then
		If Clng(sToolBarID) <= UBound(aToolbar) And Clng(sToolBarID) > 0 Then
			aCurrToolbar = Split(aToolbar(Clng(sToolbarID)), "|||")
			sToolBarName = aCurrToolbar(2)
			sToolBarOrder = aCurrToolbar(3)
			sToolBarButton = aCurrToolbar(1)
			b = True
		End If
	End If
	If b = False Then
		GoError ("无效的工具栏ID号，请通过页面上的链接进行操作！")
	End If
End Sub

Sub ShowButtonList()

	Call ShowMessage("<b class=blue>当前样式：<span class=red>" & outHTML(sStyleName) & "</span>&nbsp;&nbsp;当前工具栏：<span class=red>" & outHTML(sToolBarName) & "</span></b>")
	
	Dim i, n

	Dim s_Option1
	s_Option1 = ""
	For i = 1 To UBound(aButton, 1)
		If aButton(i, 8) = 1 Then
			s_Option1 = s_Option1 & "<option value='" & aButton(i, 1) & "'>" & aButton(i, 2) & "</option>"
		End If
	Next

	Dim aSelButton, s_Option2, s_Temp
	aSelButton = Split(sToolBarButton, "|")
	s_Option2 = ""
	For i = 0 To UBound(aSelButton)
		s_Temp = Code2Title(aSelButton(i))
		If s_Temp <> "" Then
			s_Option2 = s_Option2 & "<option value='" & aSelButton(i) & "'>" & s_Temp & "</option>"
		End If
	Next



	Response.Write ("<s" & "cript language=javascript>" & VBCrlf & _
	"function Add() {" & VBCrlf & _
	"	var sel1=document.myform.d_b1;" & VBCrlf & _
	"	var sel2=document.myform.d_b2;" & VBCrlf & _
	"	if (sel1.selectedIndex<0) {" & VBCrlf & _
	"		alert(""请选择一个待选按钮！"");" & VBCrlf & _
	"		return;" & VBCrlf & _
	"	}" & VBCrlf & _
	"	sel2.options[sel2.length]=new Option(sel1.options[sel1.selectedIndex].innerHTML,sel1.options[sel1.selectedIndex].value);" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"function Del() {" & VBCrlf & _
	"	var sel=document.myform.d_b2;" & VBCrlf & _
	"	var nIndex = sel.selectedIndex;" & VBCrlf & _
	"	var nLen = sel.length;" & VBCrlf & _
	"	if (nLen<1) return;" & VBCrlf & _
	"	if (nIndex<0) {" & VBCrlf & _
	"		alert(""请选择一个已选按钮！"");" & VBCrlf & _
	"		return;" & VBCrlf & _
	"	}" & VBCrlf & _
	"	for (var i=nIndex;i<nLen-1;i++) {" & VBCrlf & _
	"		sel.options[i].value=sel.options[i+1].value;" & VBCrlf & _
	"		sel.options[i].innerHTML=sel.options[i+1].innerHTML;" & VBCrlf & _
	"	}" & VBCrlf & _
	"	sel.length=nLen-1;" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"function Up() {" & VBCrlf & _
	"	var sel=document.myform.d_b2;" & VBCrlf & _
	"	var nIndex = sel.selectedIndex;" & VBCrlf & _
	"	var nLen = sel.length;" & VBCrlf & _
	"	if ((nLen<1)||(nIndex==0)) return;" & VBCrlf & _
	"	if (nIndex<0) {" & VBCrlf & _
	"		alert(""请选择一个要移动的已选按钮！"");" & VBCrlf & _
	"		return;" & VBCrlf & _
	"	}" & VBCrlf & _
	"	var sValue=sel.options[nIndex].value;" & VBCrlf & _
	"	var sHTML=sel.options[nIndex].innerHTML;" & VBCrlf & _
	"	sel.options[nIndex].value=sel.options[nIndex-1].value;" & VBCrlf & _
	"	sel.options[nIndex].innerHTML=sel.options[nIndex-1].innerHTML;" & VBCrlf & _
	"	sel.options[nIndex-1].value=sValue;" & VBCrlf & _
	"	sel.options[nIndex-1].innerHTML=sHTML;" & VBCrlf & _
	"	sel.selectedIndex=nIndex-1;" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"function Down() {" & VBCrlf & _
	"	var sel=document.myform.d_b2;" & VBCrlf & _
	"	var nIndex = sel.selectedIndex;" & VBCrlf & _
	"	var nLen = sel.length;" & VBCrlf & _
	"	if ((nLen<1)||(nIndex==nLen-1)) return;" & VBCrlf & _
	"	if (nIndex<0) {" & VBCrlf & _
	"		alert(""请选择一个要移动的已选按钮！"");" & VBCrlf & _
	"		return;" & VBCrlf & _
	"	}" & VBCrlf & _
	"	var sValue=sel.options[nIndex].value;" & VBCrlf & _
	"	var sHTML=sel.options[nIndex].innerHTML;" & VBCrlf & _
	"	sel.options[nIndex].value=sel.options[nIndex+1].value;" & VBCrlf & _
	"	sel.options[nIndex].innerHTML=sel.options[nIndex+1].innerHTML;" & VBCrlf & _
	"	sel.options[nIndex+1].value=sValue;" & VBCrlf & _
	"	sel.options[nIndex+1].innerHTML=sHTML;" & VBCrlf & _
	"	sel.selectedIndex=nIndex+1;" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"function checkform() {" & VBCrlf & _
	"	var sel=document.myform.d_b2;" & VBCrlf & _
	"	var nLen = sel.length;" & VBCrlf & _
	"	var str="""";" & VBCrlf & _
	"	for (var i=0;i<nLen;i++) {" & VBCrlf & _
	"		if (i>0) str+=""|"";" & VBCrlf & _
	"		str+=sel.options[i].value;" & VBCrlf & _
	"	}" & VBCrlf & _
	"	document.myform.d_button.value=str;" & VBCrlf & _
	"	return true;" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"</s" & "cript>")


	Dim s_SubmitButton
	If nStyleIsSys = 1 Then
		s_SubmitButton = ""
	Else
		s_SubmitButton = "<input type=submit name=b value=' 保存设置 '>"
	End If
	Response.Write ("<table border=0 cellpadding=5 cellspacing=0 align=center>" & _
		"<form action='?action=buttonsave&id=" & sStyleID & "&toolbarid=" & sToolBarID & "' method=post name=myform onsubmit='return checkform()'>" & _
		"<tr align=center><td>可选按钮</td><td></td><td>已选按钮</td><td></td></tr>" & _
		"<tr align=center>" & _
			"<td><select name='d_b1' size=20 style='width:250px' ondblclick='Add()'>" & s_Option1 & "</select></td>" & _
			"<td><input type=button name=b1 value=' → ' onclick='Add()'><br><br><input type=button name=b1 value=' ← ' onclick='Del()'></td>" & _
			"<td><select name='d_b2' size=20 style='width:250px' ondblclick='Del()'>" & s_Option2 & "</select></td>" & _
			"<td><input type=button name=b3 value='↑' onclick='Up()'><br><br><br><input type=button name=b4 value='↓' onclick='Down()'></td>" & _
		"</tr>" & _
		"<input type=hidden name='d_button' value=''>" & _
		"<tr><td colspan=4 align=right>" & s_SubmitButton & "</td></tr>" & _
		"</form></table>")


	Response.Write ("<table border=0 cellspacing=1 align=center class=list>" & _
		"<tr><th colspan=4>以下是按钮图片对照表（部分下拉框或特殊按钮可能没图）：</th></tr>")
	n = 0
	Dim m
	m = 0
	For i = 1 To UBound(aButton)
		If aButton(i, 8) = 1 Then
			m = m + 1
			n = m Mod 4
			If n = 1 Then
				Response.Write ("<tr>")
			End If
			Response.Write ("<td>")
			If aButton(i, 3) <> "" Then
				Response.Write ("<img border=0 align=absmiddle src='../buttonimage/standard/" & aButton(i, 3) & "'>")
			End If
			Response.Write (aButton(i, 2))
			Response.Write ("</td>")
			If n = 0 Then
				Response.Write ("</tr>")
			End If
		End If
	Next
	If n > 0 Then
		For i = 1 To 4 - n
			Response.Write ("<td>&nbsp;</td>")
		Next
		Response.Write ("</tr>")
	End if
	Response.Write ("</table>")
End Sub

Function Code2Title(s_Code)
	Dim i
	Code2Title = ""
	For i = 1 To UBound(aButton)
		If UCase(aButton(i, 1)) = UCase(s_Code) Then
			Code2Title = aButton(i, 2)
			Exit Function
		End If
	Next
End Function

Sub DoButtonSave()
	Dim s_Button, nToolBarID, aCurrToolbar
	s_Button = Trim(Request("d_button"))

	nToolBarID = Clng(sToolBarID)
	aCurrToolbar = Split(aToolbar(nToolBarID), "|||")
	aToolbar(nToolBarID) = aCurrToolbar(0) & "|||" & s_Button & "|||" & aCurrToolbar(2) & "|||" & aCurrToolbar(3)

	Call WriteConfig()
	Call WriteStyle(Clng(sStyleID))

	Call ShowMessage("<b><span class=red>工具栏按钮设置保存成功！</span></b><li><a href='?action=stylepreview&id=" & sStyleID & "' target='_blank'>预览此样式</a><li><a href='?action=toolbar&id=" & sStyleID & "'>返回工具栏管理</a><li><a href='?action=buttonset&id=" & sStyleID & "&toolbarid=" & sToolBarID & "'>重新设置此工具栏下的按钮</a>")

End Sub

Function InitSelect(s_FieldName, a_Name, a_Value, v_InitValue, s_AllName)
	Dim i
	InitSelect = "<select name='" & s_FieldName & "' size=1>"
	If s_AllName <> "" Then
		InitSelect = InitSelect & "<option value=''>" & s_AllName & "</option>"
	End If

	For i = 0 To UBound(a_Name)
		InitSelect = InitSelect & "<option value=""" & inHTML(a_Value(i)) & """"
		If a_Value(i) = v_InitValue Then
			InitSelect = InitSelect & " selected"
		End If
		InitSelect = InitSelect & ">" & outHTML(a_Name(i)) & "</option>"
	Next
	InitSelect = InitSelect & "</select>"
End Function



Sub WriteStyle(n_StyleID)
	Dim sConfig
	Dim aTmpStyle

	sConfig = ""
	aTmpStyle = Split(aStyle(n_StyleID), "|||")
	sConfig = sConfig & "config.ButtonDir = """ & aTmpStyle(1) & """;" & Vbcrlf
	sConfig = sConfig & "config.StyleUploadDir = """ & aTmpStyle(3) & """;" & Vbcrlf
	sConfig = sConfig & "config.InitMode = """ & aTmpStyle(18) & """;" & Vbcrlf
	sConfig = sConfig & "config.AutoDetectPasteFromWord = """ & aTmpStyle(17) & """;" & Vbcrlf
	sConfig = sConfig & "config.BaseUrl = """ & aTmpStyle(19) & """;" & Vbcrlf
	sConfig = sConfig & "config.BaseHref = """ & aTmpStyle(22) & """;" & Vbcrlf
	sConfig = sConfig & "config.AutoRemote = """ & aTmpStyle(24) & """;" & Vbcrlf
	sConfig = sConfig & "config.ShowBorder = """ & aTmpStyle(25) & """;" & Vbcrlf
	sConfig = sConfig & "config.StateFlag = """ & aTmpStyle(16) & """;" & Vbcrlf
	sConfig = sConfig & "config.CssDir = """ & aTmpStyle(2) & """;" & Vbcrlf
	sConfig = sConfig & "config.AutoDetectLanguage = """ & aTmpStyle(27) & """;" & Vbcrlf
	sConfig = sConfig & "config.DefaultLanguage = """ & aTmpStyle(28) & """;" & Vbcrlf
	sConfig = sConfig & Vbcrlf
	sConfig = sConfig & "function showToolbar(){" & Vbcrlf
	sConfig = sConfig & Vbcrlf

	sConfig = sConfig & chr(9) & "document.write ("""
	sConfig = sConfig & "<table border=0 cellpadding=0 cellspacing=0 width='100%' class='Toolbar' id='eWebEditor_Toolbar'>"

	Dim s_Order, s_ID, n, aTmpToolbar
	s_Order = ""
	s_ID = ""
	For n = 1 To UBound(aToolbar)
		If aToolbar(n) <> "" Then
			aTmpToolbar = Split(aToolbar(n), "|||")
			If aTmpToolbar(0) = CStr(n_StyleID) Then
				If s_ID <> "" Then
					s_ID = s_ID & "|"
					s_Order = s_Order & "|"
				End If
				s_ID = s_ID & CStr(n)
				s_Order = s_Order & aTmpToolbar(3)
			End If
		End If
	Next

	Dim a_ID, a_Order, aTmpButton, i
	If s_ID <> "" Then
		a_ID = Split(s_ID, "|")
		a_Order = Split(s_Order, "|")
		For n = 0 To UBound(a_Order)
			a_Order(n) = Clng(a_Order(n))
			a_ID(n) = Clng(a_ID(n))
		Next
		a_ID = Sort(a_ID, a_Order)
		For n = 0 To UBound(a_ID)
			aTmpToolbar = Split(aToolbar(a_ID(n)), "|||")
			aTmpButton = Split(aTmpToolbar(1), "|")

			sConfig = sConfig & "<tr><td><div class=yToolbar>"
			For i = 0 To UBound(aTmpButton)
				If UCase(aTmpButton(i)) = "MAXIMIZE" Then
					sConfig = sConfig & """);" & Vbcrlf
					sConfig = sConfig & Vbcrlf

					sConfig = sConfig & chr(9) & "if (sFullScreen==""1""){" & Vbcrlf
					sConfig = sConfig & chr(9) & chr(9) & "document.write (""" & Code2HTML("Minimize", aTmpStyle(1)) & """);" & Vbcrlf
					sConfig = sConfig & chr(9) & "}else{" & Vbcrlf
					sConfig = sConfig & chr(9) & chr(9) & "document.write (""" & Code2HTML(aTmpButton(i), aTmpStyle(1)) & """);" & Vbcrlf
					sConfig = sConfig & chr(9) & "}" & Vbcrlf
					sConfig = sConfig & Vbcrlf

					sConfig = sConfig & chr(9) & "document.write ("""
				Else
					sConfig = sConfig & Code2HTML(aTmpButton(i), aTmpStyle(1))
				End If
			Next
			sConfig = sConfig & "</div></td></tr>"
		Next
	Else
		sConfig = sConfig & "<tr><td></td></tr>"
	End If

	sConfig = sConfig & "</table>"");" & Vbcrlf
	sConfig = sConfig & Vbcrlf
	sConfig = sConfig & "}" & Vbcrlf	

	Call WriteFile("../style/" & LCase(aTmpStyle(0)) & ".js", sConfig)

End Sub

Function Code2HTML(s_Code, s_ButtonDir)
	Dim i
	Code2HTML = ""
	For i = 1 To UBound(aButton, 1)
		If UCase(aButton(i, 1)) = UCase(s_Code) Then
			Select Case aButton(i, 5)
			Case 0
				Code2HTML = "<DIV CLASS=" & aButton(i, 7) & " TITLE='""+lang[""" & aButton(i, 1) & """]+""' onclick=\""" & aButton(i, 6) & "\""><IMG CLASS=Ico SRC='buttonimage/" & s_ButtonDir & "/" & aButton(i, 3) & "'></DIV>"
			Case 1
				If aButton(i, 4) <> "" Then
					Code2HTML = "<SELECT CLASS=" & aButton(i, 7) & " onchange=\""" & aButton(i, 6) & "\"">" & aButton(i, 4) & "</SELECT>"
				Else
					Code2HTML = "<SELECT CLASS=" & aButton(i, 7) & " onchange=\""" & aButton(i, 6) & "\"">""+lang[""" & aButton(i, 1) & """]+""</SELECT>"
				End If
			Case 2
				Code2HTML = "<DIV CLASS=" & aButton(i, 7) & ">" & aButton(i, 4) & "</DIV>"
			End Select
			Exit Function
		End If
	Next
End Function

Sub DeleteFile(s_StyleName)
	On Error Resume Next
	Dim oFSO, sMapFileName
	oFSO = Server.CreateObject("Scripting.FileSystemObject")
	sMapFileName = Server.MapPath("../style/" & LCase(s_StyleName) & ".js")
	If oFSO.FileExists(sMapFileName) Then
		oFSO.DeleteFile(sMapFileName)
	End If
	oFSO = Nothing
End Sub

Sub GoUrl(url)
	Response.Write ("<script language=javascript>location.href=""" & url & """;</s" & "cript>")
	Response.End
End Sub

</script>