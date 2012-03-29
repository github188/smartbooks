<%@ Page language="VB" AutoEventWireup="false" validateRequest="False"%>
<!--#include file = "../aspx/config.aspx"-->
<!--#include file = "button.aspx"-->

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
If Session("eWebEditor_User") = "" Then
	Response.Write("<s" & "cript language=javascript>top.location.href='login.aspx';</s" & "cript>")
	Response.End
End If


sAction = UCase(Trim(Request.QueryString("action")))
sPosition = "当前位置："

%>

<script language="vb" runat="server">
Dim sAction, sPosition

Sub Header()
	Response.Write("<html><head>")
	
	Response.Write ("<meta http-equiv='Content-Type' content='text/html; charset=gb2312'>" & _
		"<meta name='Author' content='Andy.m'>" & _
		"<link rev=MADE href='mailto:webmaster@webasp.net'>" & _
		"<title>eWebEditor在线编辑器 - 后台管理</title>" & _
		"<link rel='stylesheet' type='text/css' href='private.css'>" & _
		"<s" & "cript language='javascript' src='private.js'></s" & "cript>")

	Response.Write("</head>")
	Response.Write("<body>")
	Response.Write("<a name=top></a>")
End Sub

Sub Footer()
	Response.Write ("<table border=0 cellpadding=0 cellspacing=0 align=center width='100%'>" & _
		"<tr><td height=40></td></tr>" & _
		"<tr><td><hr size=1 color=#000000 width='60%' align=center></td></tr>" & _
		"<tr>" & _
			"<td align=center>Copyright  &copy;  2003-2004  <b>webasp<font color=#CC0000>.net</font></b> <b>eWebSoft<font color=#CC0000>.com</font></b>, All Rights Reserved .</td>" & _
		"</tr>" & _
		"<tr>" & _
			"<td align=center><a href='mailto:webmaster@webasp.net'>webmaster@webasp.net</a></td>" & _
		"</tr>" & _
		"</table>")

	Response.Write ("</body></html>")
End Sub

Function IsSafeStr(str)
	Dim s_BadStr, n, i
	s_BadStr = "' 　&<>?%,;:()`~!@#$^*{}[]|+-=" & Chr(34) & Chr(9) & Chr(32)
	n = Len(s_BadStr)
	IsSafeStr = True
	For i = 1 To n
		If Instr(str, Mid(s_BadStr, i, 1)) > 0 Then
			IsSafeStr = False
			Exit Function
		End If
	Next
End Function

Function outHTML(str)
	Dim sTemp
	sTemp = str
	outHTML = ""
	If IsDBNull(sTemp) = True Then
		Exit Function
	End If
	sTemp = Replace(sTemp, "&", "&amp;")
	sTemp = Replace(sTemp, "<", "&lt;")
	sTemp = Replace(sTemp, ">", "&gt;")
	sTemp = Replace(sTemp, Chr(34), "&quot;")
	sTemp = Replace(sTemp, Chr(10), "<br>")
	outHTML = sTemp
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

Sub GoError(str)
	Response.Write ("<s" & "cript language=javascript>alert('" & str & "\n\n系统将自动返回前一页面...');history.back();</s" & "cript>")
	Response.End
End Sub

Function GetTrueLen(str)
	Dim l, t, c, i
	l = Len(str)
	t = l
	For i = 1 To l
		c = Asc(Mid(str, i, 1))
		If c < 0 Then c = c + 65536
		If c > 255 Then t = t + 1
	Next
	GetTrueLen = t
End Function

Sub WriteConfig()
	Dim i, n, sConfig
	sConfig = ""
	sConfig = sConfig & "<script language=""vb"" runat=""server"">" & VBCrlf
	sConfig = sConfig & "Dim sUsername, sPassword" & VBCrlf
	sConfig = sConfig & "Dim aStyle()" & VBCrlf
	sConfig = sConfig & "Dim aToolbar()" & VBCrlf
	sConfig = sConfig & "</s" & "cript>" & VBCrlf
	sConfig = sConfig & Vbcrlf

	sConfig = sConfig & "<" & "%" & Vbcrlf
	sConfig = sConfig & "sUsername = """ & sUsername & """" & Vbcrlf
	sConfig = sConfig & "sPassword = """ & sPassword & """" & Vbcrlf
	sConfig = sConfig & Vbcrlf

	Dim nConfigStyle, sConfigStyle, aTmpStyle
	Dim nConfigToolbar, sConfigToolbar, aTmpToolbar, sTmpToolbar
	Dim s_Order, s_ID, a_Order, a_ID

	nConfigStyle = 0
	sConfigStyle = ""
	nConfigToolbar = 0
	sConfigToolbar = ""

	For i = 1 To UBound(aStyle)
		If aStyle(i) <> "" Then
			aTmpStyle = Split(aStyle(i), "|||")
			If aTmpStyle(0) <> "" Then
				nConfigStyle = nConfigStyle + 1
				sConfigStyle = sConfigStyle & "aStyle(" & nConfigStyle & ") = """ & aStyle(i) & """" & Vbcrlf

				s_Order = ""
				s_ID = ""
				For n = 1 To UBound(aToolbar)
					If aToolbar(n) <> "" Then
						aTmpToolbar = Split(aToolbar(n), "|||")
						If aTmpToolbar(0) = CStr(i) Then
							If s_ID <> "" Then
								s_ID = s_ID & "|"
								s_Order = s_Order & "|"
							End If
							s_ID = s_ID & CStr(n)
							s_Order = s_Order & aTmpToolbar(3)
						End If
					End If
				Next

				If s_ID <> "" Then
					a_ID = Split(s_ID, "|")
					a_Order = Split(s_Order, "|")
					For n = 0 To UBound(a_Order)
						a_Order(n) = Clng(a_Order(n))
						a_ID(n) = Clng(a_ID(n))
					Next
					a_ID = Sort(a_ID, a_Order)
					For n = 0 To UBound(a_ID)
						nConfigToolbar = nConfigToolbar + 1
						aTmpToolbar = Split(aToolbar(a_ID(n)), "|||")
						sTmpToolbar = nConfigStyle & "|||" & aTmpToolbar(1) & "|||" & aTmpToolbar(2) & "|||" & aTmpToolbar(3)
						sConfigToolbar = sConfigToolbar & "aToolbar(" & nConfigToolbar & ") = """ & sTmpToolbar & """" & Vbcrlf
					Next
				End If

			End If
		End If
	Next
	sConfigStyle = "Redim aStyle(" & nConfigStyle & ")" & Vbcrlf & sConfigStyle
	sConfigToolbar = "Redim aToolbar(" & nConfigToolbar & ")" & Vbcrlf & sConfigToolbar
	sConfig = sConfig & sConfigStyle & Vbcrlf & sConfigToolbar & "%" & ">"

	Call WriteFile("../aspx/config.aspx", sConfig)

End Sub

Sub WriteFile(s_FileName, s_Text)
	On Error Resume Next
	Dim oStreamWriter As System.IO.StreamWriter  
	oStreamWriter = System.IO.File.CreateText(Server.MapPath(s_FileName))
	oStreamWriter.Write(s_Text)
	oStreamWriter.Close
End Sub

Function Sort(aryValue, aryOrder)
	Dim i, KeepChecking
	Dim FirstOrder, SecondOrder
	Dim FirstValue, SecondValue
	KeepChecking = TRUE
	Do Until KeepChecking = FALSE
		KeepChecking = FALSE
		For i = 0 to UBound(aryOrder)
			If i = UBound(aryOrder) Then Exit For
			If aryOrder(i) > aryOrder(i+1) Then
				FirstOrder = aryOrder(i)
				SecondOrder = aryOrder(i+1)
				aryOrder(i) = SecondOrder
				aryOrder(i+1) = FirstOrder 
				FirstValue = aryValue(i)
				SecondValue = aryValue(i+1)
				aryValue(i) = SecondValue
				aryValue(i+1) = FirstValue
				KeepChecking = TRUE 
			End If
		Next
	Loop
	Sort = aryValue
End Function 

</script>
