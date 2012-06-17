<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrafficReported.aspx.cs" Inherits="SmartHyd.ManageCenter.Traffic.TrafficReported" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路况信息上报</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    
    <style type="text/css">
        body
        {
        	 margin:0px;
        	 padding:0px;
        	 font-size:12px;
        }
        .titlebar{ height:20px; line-height:20px; font-size:12px; background-color:#ccc; color:#000; padding-left:5px;}
        .td_title{ width:100px; height:24px;line-height:24px; text-align:right; font-weight:bold;}
        .td_content{height:24px; line-height:24px;}
    </style>
    <script type="text/javascript">
        function GoBack() {
            history.go(-1);
        }

        function addAttach() {
            var filebutton = '<br><input type="file" size="50" name="File" />';
            document.getElementById('FileList').insertAdjacentHTML("beforeEnd", filebutton);
        }     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
            <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：高速路况》路况信息上报</span></div>
            <div class="ReturnPreview"><span id="buttons" onclick="GoBack()"><img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
