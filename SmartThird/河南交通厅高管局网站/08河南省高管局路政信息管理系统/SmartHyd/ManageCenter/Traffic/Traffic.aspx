<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Traffic.aspx.cs" Inherits="SmartHyd.ManageCenter.Traffic.Traffic" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
     body{
        	margin:0px;
        	padding:0px;
        	font-size:12px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style=" width:100%; height:100%;font-size:12px;">
            <tr>
                <td width="0" valign="top">
                </td>
                <td>
                    <iframe id="SecurityMapFrame" name="SecurityMapFrame" src="../../MapFrame.aspx" frameborder="0" scrolling="no" height="100%" width="100%"></iframe>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
