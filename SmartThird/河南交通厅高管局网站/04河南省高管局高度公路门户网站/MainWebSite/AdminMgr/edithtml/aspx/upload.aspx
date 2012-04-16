<%@ Page language="VB" AutoEventWireup="false" aspCompat="True" validateRequest="False"%>

<!--#include file="config.aspx"-->

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

Call InitUpload()

sAction = UCase(Trim(Request.QueryString("action")))

Select Case sAction
Case "REMOTE"
	Call DoCreateNewDir()
	Call DoRemote()
Case "SAVE"
	Call ShowForm()
	Call DoCreateNewDir()
	Call DoSave()
Case Else
	Call ShowForm()
End Select

%>

<script language="vb" runat="server">
Dim sAction
Dim sType, sStyleName, sCharset
Dim sAllowExt, nAllowSize, sUploadDir, nUploadObject, nAutoDir, sBaseUrl, sContentPath
Dim sFileExt, sOriginalFileName, sSaveFileName, sPathFileName, nFileNum

Sub ShowForm()
	Response.Write ("<HTML>" & _
	"<HEAD>" & _
	"<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>" & _
	"<TITLE>eWebEditor</TITLE>" & _
	"<link href='../dialog/dialog.css' type='text/css' rel='stylesheet'>" & _
	"<script language=""javascript"" src=""../dialog/dialog.js""></s" & "cript>" & _
	"</head>" & _
	"<body class=upload>")

	Response.Write ("<form action='?action=save&type=" & sType & "&style=" & sStyleName & "&charset=" & sCharset & "' method=post name=myform enctype='multipart/form-data'>" & _
	"<input type=file name=uploadfile size=1 style='width:100%' >" & _
	"</form>")

	Response.Write ("<script language=javascript>" & VBCrlf & _
	"" & VBCrlf & _
	"var sAllowExt = """ & sAllowExt & """;" & VBCrlf & _
	"" & VBCrlf & _
	"function CheckUploadForm() {" & VBCrlf & _
	"	if (!IsExt(document.myform.uploadfile.value,sAllowExt)){" & VBCrlf & _
	"		parent.UploadError('lang[""ErrUploadInvalidExt""]+"":'+sAllowExt+'""');" & VBCrlf & _
	"		return false;" & VBCrlf & _
	"	}" & VBCrlf & _
	"	return true" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"var oForm = document.myform ;" & VBCrlf & _
	"oForm.attachEvent(""onsubmit"", CheckUploadForm) ;" & VBCrlf & _
	"if (! oForm.submitUpload) oForm.submitUpload = new Array() ;" & VBCrlf & _
	"oForm.submitUpload[oForm.submitUpload.length] = CheckUploadForm ;" & VBCrlf & _
	"if (! oForm.originalSubmit) {" & VBCrlf & _
	"	oForm.originalSubmit = oForm.submit ;" & VBCrlf & _
	"	oForm.submit = function() {" & VBCrlf & _
	"		if (this.submitUpload) {" & VBCrlf & _
	"			for (var i = 0 ; i < this.submitUpload.length ; i++) {" & VBCrlf & _
	"				this.submitUpload[i]() ;" & VBCrlf & _
	"			}" & VBCrlf & _
	"		}" & VBCrlf & _
	"		this.originalSubmit() ;" & VBCrlf & _
	"	}" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"try {" & VBCrlf & _
	"	parent.UploadLoaded();" & VBCrlf & _
	"}" & VBCrlf & _
	"catch(e){" & VBCrlf & _
	"}" & VBCrlf & _
	"" & VBCrlf & _
	"</s" & "cript>" & VBCrlf )

	Response.Write ("</body></html>")

End Sub 


Sub DoSave()

	Select Case nUploadObject
	Case 1
		Call DoUpload_ASPUpload()
	Case 2
		Call DoUpload_SAFileUP()
	Case 3
		Call DoUpload_LyfUpload()
	Case Else
		Call DoUpload_ASPDotNet()
	End Select
	
	sPathFileName = sContentPath & sSaveFileName
	Call OutScript("parent.UploadSaved('" & sPathFileName & "');var obj=parent.dialogArguments.dialogArguments;if (!obj) obj=parent.dialogArguments;try{obj.addUploadFile('" & sOriginalFileName & "', '" & sSaveFileName & "', '" & sPathFileName & "');} catch(e){}")

End Sub

Sub DoRemote()
	Dim sContent
	sContent = Request.Form("eWebEditor_UploadText")

	If sAllowExt <> "" Then
		sContent = ReplaceRemoteUrl(sContent, sAllowExt)
	End If

	Response.Write ("<HTML><HEAD><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'></head><body>" & _
		"<TITLE>eWebEditor</TITLE>" & _
		"<input type=hidden id=UploadText value=""" & inHTML(sContent) & """>" & _
		"</body></html>")

	Call OutScriptNoBack("parent.setHTML(UploadText.value);try{parent.addUploadFile('" & sOriginalFileName & "', '" & sSaveFileName & "', '" & sPathFileName & "');} catch(e){} parent.remoteUploadOK();")

End Sub

Sub DoCreateNewDir()

	Dim sCreateDir
	Select Case nAutoDir
	Case 1
		sCreateDir = Left(FormatTime(Now(), 4), 4)
	Case 2
		sCreateDir = Left(FormatTime(Now(), 4), 6)
	Case 3
		sCreateDir = Left(FormatTime(Now(), 4), 8)
	Case Else
		Exit Sub
	End Select
	sUploadDir = sUploadDir & sCreateDir & "/"
	sContentPath = sContentPath & sCreateDir & "/"
	
	Dim oDir As System.IO.Directory
	If oDir.Exists(Server.Mappath(sUploadDir)) = False Then
		oDir.CreateDirectory(Server.Mappath(sUploadDir))
	End If
End Sub

Sub DoUpload_LyfUpload()
	On Error Resume Next
	Dim oUpload, sResult, sOriginalFile
	oUpload = Server.CreateObject("LyfUpload.UploadFile")
	oUpload.ExtName = Replace(sAllowExt, "|", ",")
	oUpload.MaxSize = nAllowSize*1024
	sOriginalFile = oUpload.Request("originalfile")
	sOriginalFileName = Mid(sOriginalFile, InStrRev(sOriginalFile, "\") + 1)
	sFileExt = LCase(Mid(sOriginalFileName, InStrRev(sOriginalFileName, ".") + 1))
	Call CheckValidExt(sFileExt)
	sSaveFileName = GetRndFileName(sFileExt)
	sResult = oUpload.SaveFile("uploadfile", Server.Mappath(sUploadDir), True, sSaveFileName)

	Select Case sResult
	Case "0"
		Call OutScript("parent.UploadError('lang[""ErrUploadSizeLimit""]+"":" & nAllowSize & "KB""')")
	Case ""
		Call OutScript("parent.UploadError('lang[""ErrUploadInvalidFile""]')")
	Case "1"
		Call OutScript("parent.UploadError('lang[""ErrUploadInvalidExt""]+"":" & sAllowExt & """')")
	End Select
	
	oUpload = Nothing
End Sub

Sub DoUpload_SAFileUp()
	On Error Resume Next
	Dim oFileUp
	oFileUp = Server.CreateObject("SoftArtisans.FileUp")
	'oFileUp.MaxBytes = nAllowSize*1024
	oFileUp.Path = Server.MapPath(sUploadDir)

	If oFileUp.Form("uploadfile").TotalBytes > nAllowSize*1024 Then
		Err.Clear
		Call OutScript("parent.UploadError('lang[""ErrUploadSizeLimit""]+"":" & nAllowSize & "KB""')")
	End If
	If oFileUp.Form("uploadfile").IsEmpty Then
		Call OutScript("parent.UploadError('lang[""ErrUploadInvalidFile""]')")
	End If

	Dim sShortFileName
	sShortFileName = oFileUp.Form("uploadfile").ShortFileName
	sFileExt = LCase(Mid(sShortFileName, InStrRev(sShortFileName, ".") + 1))
	Call CheckValidExt(sFileExt)
	sOriginalFileName = sShortFileName
	sSaveFileName = GetRndFileName(sFileExt)
	oFileUp.Form("uploadfile").SaveAs(Server.Mappath(sUploadDir & sSaveFileName))
	
	oFileUp = Nothing
End Sub

Sub DoUpload_ASPUpload()
	On Error Resume Next
	Dim oUpload, oFile, nCount
	oUpload = Server.CreateObject("Persits.Upload")
	oUpload.SetMaxSize(nAllowSize*1024, True)
	nCount = oUpload.Save

	If nCount < 1 Then
		Call OutScript("parent.UploadError('lang[""ErrUploadInvalidFile""]')")
	End If
	If Err.Number = 8 Then
		Err.Clear
		Call OutScript("parent.UploadError('lang[""ErrUploadSizeLimit""]+"":" & nAllowSize & "KB""')")
	End If
	
	oFile = oUpload.Files("uploadfile")
	sFileExt = LCase(Mid(oFile.Ext, 2))
	Call CheckValidExt(sFileExt)
	sOriginalFileName = oFile.FileName
	sSaveFileName = GetRndFileName(sFileExt)
	oFile.SaveAs (Server.Mappath(sUploadDir & sSaveFileName))

	oFile = Nothing
	oUpload = Nothing
End Sub

Sub DoUpload_ASPDotNet()
	On Error Resume Next
	Dim oFiles As System.Web.HttpFileCollection = System.Web.HttpContext.Current.Request.Files
	Dim postedFile As System.Web.HttpPostedFile = oFiles(0)
	sOriginalFileName = System.IO.Path.GetFileName(postedFile.FileName)
	sFileExt = System.IO.Path.GetExtension(sOriginalFileName)
	sFileExt = LCase(Mid(sFileExt, 2))
	Call CheckValidExt(sFileExt)
	sSaveFileName = GetRndFileName(sFileExt)
	If PostedFile.ContentLength > nAllowSize*1024 Then
		Call OutScript("parent.UploadError('lang[""ErrUploadSizeLimit""]+"":" & nAllowSize & "KB""')")
	End If

	Dim str_Mappath
	str_Mappath = Server.Mappath(sUploadDir & sSaveFileName)
	sFileExt = LCase(Mid(str_Mappath, InstrRev(str_Mappath, ".") + 1))
	Call CheckValidExt(sFileExt)

	postedFile.SaveAs(str_Mappath)

	oFiles = Nothing
End Sub

Function GetRndFileName(sExt)
	Dim sRnd
	Randomize
	sRnd = Int(900 * Rnd) + 100
	GetRndFileName = year(now) & month(now) & day(now) & hour(now) & minute(now) & second(now) & sRnd & "." & sExt
End Function

Sub OutScript(str)
	Response.Write ("<script language=javascript>" & str & ";history.back()</s" & "cript>")
	Response.End
End Sub
Sub OutScriptNoBack(str)
	Response.Write ("<script language=javascript>" & str & "</s" & "cript>")
End Sub

Sub CheckValidExt(sExt)
	Dim b, i, aExt
	b = False
	aExt = Split(sAllowExt, "|")
	For i = 0 To UBound(aExt)
		If LCase(aExt(i)) = sExt Then
			b = True
			Exit For
		End If
	Next
	If b = False Then
		Call OutScript("parent.UploadError('lang[""ErrUploadInvalidExt""]+"":" & sAllowExt & """')")
	End If
End Sub

Sub InitUpload()
	sType = UCase(Trim(Request.QueryString("type")))
	sStyleName = Trim(Request.QueryString("style"))
	sCharset = Trim(Request.QueryString("charset"))

	Dim i, aStyleConfig, bValidStyle
	bValidStyle = False
	For i = 1 To Ubound(aStyle)
		aStyleConfig = Split(aStyle(i), "|||")
		If Lcase(sStyleName) = Lcase(aStyleConfig(0)) Then
			bValidStyle = True
			Exit For
		End If
	Next

	If bValidStyle = False Then
		OutScript("parent.UploadError('lang[""ErrInvalidStyle""]')")
	End If

	sBaseUrl = aStyleConfig(19)
	nUploadObject = Clng(aStyleConfig(20))
	nAutoDir = CLng(aStyleConfig(21))

	sUploadDir = aStyleConfig(3)
	If Left(sUploadDir, 1) <> "/" Then
		sUploadDir = "../" & sUploadDir
	End If

	Select Case sBaseUrl
	Case "0"
		sContentPath = aStyleConfig(23)
	Case "1"
		sContentPath = RelativePath2RootPath(sUploadDir)
	Case "2"
		sContentPath = RootPath2DomainPath(RelativePath2RootPath(sUploadDir))
	End Select

	Select Case sType
	Case "REMOTE"
		sAllowExt = aStyleConfig(10)
		nAllowSize = Clng(aStyleConfig(15))
	Case "FILE"
		sAllowExt = aStyleConfig(6)
		nAllowSize = Clng(aStyleConfig(11))
	Case "MEDIA"
		sAllowExt = aStyleConfig(9)
		nAllowSize = Clng(aStyleConfig(14))
	Case "FLASH"
		sAllowExt = aStyleConfig(7)
		nAllowSize = Clng(aStyleConfig(12))
	Case Else
		sAllowExt = aStyleConfig(8)
		nAllowSize = Clng(aStyleConfig(13))
	End Select
End Sub

Function RelativePath2RootPath(url)
	Dim sTempUrl
	sTempUrl = url
	If Left(sTempUrl, 1) = "/" Then
		RelativePath2RootPath = sTempUrl
		Exit Function
	End If

	Dim sWebEditorPath
	sWebEditorPath = Request.ServerVariables("SCRIPT_NAME")
	sWebEditorPath = Left(sWebEditorPath, InstrRev(sWebEditorPath, "/") - 1)
	Do While Left(sTempUrl, 3) = "../"
		sTempUrl = Mid(sTempUrl, 4)
		sWebEditorPath = Left(sWebEditorPath, InstrRev(sWebEditorPath, "/") - 1)
	Loop
	RelativePath2RootPath = sWebEditorPath & "/" & sTempUrl
End Function

Function RootPath2DomainPath(url)
	Dim sHost, sPort
	sHost = Split(Request.ServerVariables("SERVER_PROTOCOL"), "/")(0) & "://" & Request.ServerVariables("HTTP_HOST")
	sPort = Request.ServerVariables("SERVER_PORT")
	If sPort <> "80" Then
		sHost = sHost & ":" & sPort
	End If
	RootPath2DomainPath = sHost & url
End Function

Function ReplaceRemoteUrl(sHTML, sExt)
	Dim s_Content
	s_Content = sHTML
	If IsObjInstalled("Microsoft.XMLHTTP") = False then
		ReplaceRemoteUrl = s_Content
		Exit Function
	End If
	
	Dim SaveFileName, SaveFileType
	Dim re As Regex
	Dim RemoteFile As MatchCollection
	Dim RemoteFileurl As Match
	Dim strSearchPattern As String
	strSearchPattern = "((http|https|ftp|rtsp|mms):(\/\/|\\\\){1}(([A-Za-z0-9_-])+[.]){1,}(net|com|cn|org|cc|tv|[0-9]{1,3})([^ \f\n\r\t\v\""\'\>]*\/)(([^ \f\n\r\t\v\""\'\>])+[.]{1}(" & sExt & ")))"
	re = New Regex(strSearchPattern)
	RemoteFile = re.Matches(s_Content, RegexOptions.IgnoreCase)

	Dim a_RemoteUrl(), n, i, bRepeat
        n = 0
	' to no repeat array
	For Each RemoteFileurl in RemoteFile
		If n = 0 Then
			n = n + 1
			Redim a_RemoteUrl(n)
			a_RemoteUrl(n) = RemoteFileurl.Value.ToString
		Else
			bRepeat = False
			For i = 1 To UBound(a_RemoteUrl)
				If UCase(RemoteFileurl.Value.ToString) = UCase(a_RemoteUrl(i)) Then
					bRepeat = True
					Exit For
				End If
			Next
			If bRepeat = False Then
				n = n + 1
				Redim Preserve a_RemoteUrl(n)
				a_RemoteUrl(n) = RemoteFileurl.Value.ToString
			End If
		End If
	Next
	' start replace
	nFileNum = 0
	For i = 1 To n
		SaveFileType = Mid(a_RemoteUrl(i), InstrRev(a_RemoteUrl(i), ".") + 1)
		SaveFileName = GetRndFileName(SaveFileType)
		If SaveRemoteFile(SaveFileName, a_RemoteUrl(i)) = True Then
			nFileNum = nFileNum + 1
			If nFileNum > 0 Then
				sOriginalFileName = sOriginalFileName & "|"
				sSaveFileName = sSaveFileName & "|"
				sPathFileName = sPathFileName & "|"
			End If
			sOriginalFileName = sOriginalFileName & Mid(a_RemoteUrl(i), InstrRev(a_RemoteUrl(i), "/") + 1)
			sSaveFileName = sSaveFileName & SaveFileName
			sPathFileName = sPathFileName & sContentPath & SaveFileName
			s_Content = Replace(s_Content, a_RemoteUrl(i), sContentPath & SaveFileName, 1, -1, 1)
		End If
	Next

	ReplaceRemoteUrl = s_Content
End Function

Function SaveRemoteFile(s_LocalFileName, s_RemoteFileUrl)
	Dim Ads, Retrieval, GetRemoteData
	Dim bError
	bError = False
	SaveRemoteFile = False
	On Error Resume Next
	Retrieval = Server.CreateObject("Microsoft.XMLHTTP")
	With Retrieval
		.Open ("Get", s_RemoteFileUrl, False, "", "")
		.Send
		GetRemoteData = .ResponseBody
	End With
	Retrieval = Nothing

	If GetRemoteData.length > nAllowSize*1024 Then
		bError = True
	Else
		Ads = Server.CreateObject("Adodb.Stream")
		With Ads
			.Type = 1
			.Open
			.Write (GetRemoteData)
			.SaveToFile (Server.MapPath(sUploadDir & s_LocalFileName), 2)
			.Cancel()
			.Close()
		End With
		Ads=nothing
	End If

	If Err.Number = 0 And bError = False Then
		SaveRemoteFile = True
	Else
		Err.Clear
	End If
End Function

Function IsObjInstalled(strClassString)
	On Error Resume Next
	IsObjInstalled = False
	Err.Number = 0
	Dim xTestObj
	xTestObj = Server.CreateObject(strClassString)
	If 0 = Err.Number Then IsObjInstalled = True
	xTestObj = Nothing
	Err.Number = 0
End Function

Function inHTML(str)
	Dim sTemp
	sTemp = str
	inHTML = ""
	If IsDBNull(sTemp) = True Then
		Exit Function
	End If
	sTemp = Replace(sTemp, "&", "&amp;")
	sTemp = Replace(sTemp, "<", "&lt;")
	sTemp = Replace(sTemp, ">", "&gt;")
	sTemp = Replace(sTemp, Chr(34), "&quot;")
	inHTML = sTemp
End Function

Function FormatTime(s_Time, n_Flag)
	Dim y, m, d, h, mi, s
	FormatTime = ""
	If IsDate(s_Time) = False Then Exit Function
	y = cstr(year(s_Time))
	m = cstr(month(s_Time))
	If len(m) = 1 Then m = "0" & m
	d = cstr(day(s_Time))
	If len(d) = 1 Then d = "0" & d
	h = cstr(hour(s_Time))
	If len(h) = 1 Then h = "0" & h
	mi = cstr(minute(s_Time))
	If len(mi) = 1 Then mi = "0" & mi
	s = cstr(second(s_Time))
	If len(s) = 1 Then s = "0" & s
	Select Case n_Flag
	Case 1
		' yyyy-mm-dd hh:mm:ss
		FormatTime = y & "-" & m & "-" & d & " " & h & ":" & mi & ":" & s
	Case 2
		' yyyy-mm-dd
		FormatTime = y & "-" & m & "-" & d
	Case 3
		' hh:mm:ss
		FormatTime = h & ":" & mi & ":" & s
	Case 4
		' yyyymmdd
		FormatTime = y & m & d
	End Select
End Function

</script>